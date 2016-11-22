﻿using System.Linq;
using System.Web.Mvc;
using AnThinhPhat.Entities;
using AnThinhPhat.Services.Abstracts;
using AnThinhPhat.Utilities;
using AnThinhPhat.ViewModel.CongViec;
using Ninject;
using System.Collections.Generic;
using AnThinhPhat.Entities.Results;
using AnThinhPhat.ViewModel;
using PagedList;
using System;
using System.IO;

namespace AnThinhPhat.WebUI.Controllers
{
    [Authorize(Roles = RoleConstant.PHONGNOIVU)]
    public class CongViecController : OfficeController
    {
        [Inject]
        public IUsersRepository UsersRepository { get; set; }

        [Inject]
        public ICongViecQuaTrinhXuLyRepository QuaTrinhXuLyRepository { get; set; }

        [Inject]
        public ILinhVucCongViecRepository LinhVucCongViecRepository { get; set; }

        [Inject]
        public ITrangThaiCongViecRepository TrangThaiCongViecRepository { get; set; }

        [Inject]
        public IHoSoCongViecRepository HoSoCongViecRepository { get; set; }

        [Inject]
        public ICoQuanRepository CoQuanRepository { get; set; }

        [Inject]
        public ITapTinCongViecRepository TapTinCongViecRepository { get; set; }

        [Inject]
        public ICongViecVanBanRepository CongViecVanBanRepository { get; set; }

        [Inject]
        public ICongViecPhoiHopRepository CongViecPhoiHopRepository { get; set; }

        [HttpGet]
        public ActionResult Index(int? userId, int? role, int? trangThaiCongViecId, int? linhVucCongViecId, string noiDungCongViec)
        {
            var init = InitModel();

            var model = new InitCongViecViewModel
            {
                UsersInfos = init.UsersInfos,
                LinhVucCongViecInfos = init.LinhVucCongViecInfos,
                TrangThaiCongViecInfos = init.TrangThaiCongViecInfos,
            };

            if (model.ValueSearch == null)
                model.ValueSearch = new ValueSearchViewModel();

            if (userId == null)
            {
                model.UserId = UserId;
                model.ValueSearch.UserId = UserId;//set current user 
            }
            else
                model.ValueSearch.UserId = userId;

            if (role != null)
                model.ValueSearch.Role = (EnumRoleExecute)role;
            else
                model.ValueSearch.Role = EnumRoleExecute.TATCA;

            if (trangThaiCongViecId != null)
                model.ValueSearch.TrangThaiCongViecId = trangThaiCongViecId;
            //else
            //    model.ValueSearch.TrangThaiCongViecId = EnumStatus.TATCA;

            model.ValueSearch.LinhVucCongViecId = linhVucCongViecId;
            model.ValueSearch.NoiDungCongViec = noiDungCongViec;
            model.ValueSearch.Page = 1;

            return View(model);
        }

        public ActionResult List(ValueSearchViewModel model)
        {
            if (model.UserId == null)
                //Get current UserId
                model.UserId = UserId;

            var result = Find(model);

            return View("_PartialPageList", result);
        }

        [HttpGet]
        public ActionResult Statistic()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            var init = InitModel();
            var model = new AddCongViecViewModel
            {
                UsersInfos = init.UsersInfos,
                LinhVucCongViecInfos = init.LinhVucCongViecInfos,
                TrangThaiCongViecInfos = init.TrangThaiCongViecInfos,
                VanBanLienQuanViewModel = new List<InitVanBanViewModel>
                {
                    new InitVanBanViewModel
                    {
                        CoQuanInfos = CoQuanRepository.GetAll().Select(x => x.ToDataInfo()),
                    }
                },
                QuaTrinhXuLyViewModel = new List<InitQuaTrinhXuLyViewModel>
                {
                   new InitQuaTrinhXuLyViewModel
                   {
                       Gio=0,
                       Ngay=new System.DateTime(),
                       NoiDung =string.Empty,
                       NguoiThem=UserName,
                   },
                },
                Guid = Guid.NewGuid().ToString()
            };

            return View(model);
        }

        [HttpPost, ActionName("Add")]
        public JsonResult AddRecord(AddCongViecViewModel model)
        {
            return ExecuteWithErrorHandling(() =>
            {
                var data = new HoSoCongViecResult
                {
                    CongViecPhoiHopResult = model.UsersPhoiHopId.Select(x => new CongViecPhoiHopResult { UserId = x }),
                    CongViecQuaTrinhXuLyResult = model.QuaTrinhXuLyViewModel.Where(x => x.Gio != 0 && x.Phut != 0).Select(x => new CongViecQuaTrinhXuLyResult
                    {
                        GioBanHanh = (byte)x.Gio,
                        PhutBanHanh = (byte)x.Phut,
                        NgayBanHanh = x.Ngay,
                        NoiDung = x.NoiDung,
                        NguoiThem = x.NguoiThem,
                        NhacNho = (byte)x.NhacNho,
                        IsDeleted = false,
                    }),
                    CongViecVanBanResults = model.VanBanLienQuanViewModel.Where(x => x.CoQuanId.HasValue && x.CoQuanId != 0 && !string.IsNullOrEmpty(x.NoiDung)).Select(x => new CongViecVanBanResult
                    {
                        SoVanBan = x.SoVanBan,
                        NgayBanHanh = x.Ngay,
                        NoiDung = x.NoiDung,
                        CoQuanId = x.CoQuanId.Value,
                    }),
                    NgayHetHan = model.NgayHetHan,
                    NgayTao = model.NgayKhoiTao,
                    LinhVucCongViecId = model.LinhVucCongViecId,
                    UserPhuTrachId = model.UserPhuTrachId,
                    UserXuLyId = model.UserXuLyChinhId,
                    TrangThaiCongViecId = model.TrangThaiCongViecId,
                    NoiDung = model.NoiDungCongViec,
                    CreatedBy = UserName,
                };

                return ExecuteResult(() =>
                {
                    var saveResult = HoSoCongViecRepository.AddCongViecWithChildren(data);

                    if (data.Id > 0)
                    {
                        ExecuteTryLogException(() =>
                        {
                            MoveFiles(model.Guid, data.Id);
                        });
                    }
                    return saveResult;
                });
            });
        }

        [HttpGet]
        public ActionResult Detail(int id)
        {
            var hoso = HoSoCongViecRepository.Single(id);
            var init = InitModel();
            var coQuanInfos = CoQuanRepository.GetAll().Select(x => x.ToDataInfo());

            var model = new EditCongViecViewModel
            {
                Id = id,
                UsersInfos = init.UsersInfos,
                LinhVucCongViecInfos = init.LinhVucCongViecInfos,
                TrangThaiCongViecInfos = init.TrangThaiCongViecInfos,
                CoQuanInfos = coQuanInfos,

                LinhVucCongViecId = hoso.LinhVucCongViecId,
                VanBanLienQuanViewModel = hoso.CongViecVanBanResults.ToList(),
                QuaTrinhXuLyViewModel = hoso.CongViecQuaTrinhXuLyResult.ToList(),

                NgayHetHan = hoso.NgayHetHan,
                NgayKhoiTao = hoso.NgayTao,
                NoiDungCongViec = hoso.NoiDung,
                TrangThaiCongViecId = hoso.TrangThaiCongViecId,
                UserPhuTrachId = hoso.UserPhuTrachId,
                UserXuLyChinhId = hoso.UserXuLyId,
                UsersPhoiHopId = hoso.CongViecPhoiHopResult.Select(x => x.UserId).ToArray(),
            };
            return View(model);
        }

        [HttpPost]
        public JsonResult Detail(int id, EditCongViecViewModel model)
        {
            return ExecuteWithErrorHandling(() =>
            {
                var congViec = HoSoCongViecRepository.Single(id);

                //Get all van ban lien quan
                AddOrUpdateXuLy(id, model);
                AddOrUpdateVanBan(id, model);

                if (User.IsInRole(RoleConstant.LANHDAO))
                {
                    congViec.NgayHetHan = model.NgayHetHan;
                    congViec.LinhVucCongViecId = model.LinhVucCongViecId;
                    congViec.UserPhuTrachId = model.UserPhuTrachId;
                    congViec.UserXuLyId = model.UserXuLyChinhId;
                    congViec.CongViecPhoiHopResult = model.UsersPhoiHopId.Select(x => new CongViecPhoiHopResult { UserId = x, HoSoCongViecId = id });
                }

                congViec.TrangThaiCongViecId = model.TrangThaiCongViecId;

                AddOrUpdatePhoiHop(id, congViec.CongViecPhoiHopResult);

                HoSoCongViecRepository.Update(congViec);

                return new JsonResult
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new { code = "SB01" }
                };
            });
        }

        [HttpPost]
        public JsonResult DeleteVanBanLienQuan(int vanBanLienQuanId)
        {
            return ExecuteWithErrorHandling(() =>
            {
                return ExecuteResult(() => CongViecVanBanRepository.DeleteBy(vanBanLienQuanId));
            });
        }

        [HttpPost]
        public JsonResult DeleteQuaTrinhXuLy(int quaTrinhXuLyId)
        {
            return ExecuteWithErrorHandling(() =>
            {
                return ExecuteResult(() => QuaTrinhXuLyRepository.DeleteBy(quaTrinhXuLyId));
            });
        }

        private void AddOrUpdateVanBan(int id, EditCongViecViewModel model)
        {
            var vanbanUpdate = model.VanBanLienQuanViewModel.Where(x => x.Id > 0);
            if (vanbanUpdate.Any())
            {
                CongViecVanBanRepository.UpdateRange(vanbanUpdate.Select(x => new CongViecVanBanResult
                {
                    Id = x.Id,
                    HoSoCongViecId = id,
                    SoVanBan = x.SoVanBan,
                    NgayBanHanh = x.NgayBanHanh,
                    NoiDung = x.NoiDung,
                    CoQuanId = x.CoQuanId,
                    LastUpdatedBy = UserName,
                    IsDeleted = false,
                }));
            }

            var vanBanAdd = model.VanBanLienQuanViewModel.Where(x => x.Id == 0);
            if (vanBanAdd.Any())
                CongViecVanBanRepository.AddRange(vanbanUpdate.Select(x => new CongViecVanBanResult
                {
                    HoSoCongViecId = id,
                    SoVanBan = x.SoVanBan,
                    NgayBanHanh = x.NgayBanHanh,
                    NoiDung = x.NoiDung,
                    CoQuanId = x.CoQuanId,
                    CreatedBy = UserName,
                    IsDeleted = false,
                }));
        }

        private void AddOrUpdateXuLy(int id, EditCongViecViewModel model)
        {
            var quaTrinhUpdate = model.QuaTrinhXuLyViewModel.Where(x => x.Id > 0);
            if (quaTrinhUpdate.Any())
                QuaTrinhXuLyRepository.UpdateRange(quaTrinhUpdate.Select(x => new CongViecQuaTrinhXuLyResult
                {
                    Id = x.Id,
                    HoSoCongViecId = model.Id,
                    GioBanHanh = x.GioBanHanh,
                    PhutBanHanh = x.PhutBanHanh,
                    NgayBanHanh = x.NgayBanHanh,
                    NoiDung = x.NoiDung,
                    NguoiThem = x.NguoiThem,
                    NhacNho = x.NhacNho,
                    IsDeleted = false,
                    LastUpdatedBy = UserName,
                }));

            var quaTrinhAdd = model.QuaTrinhXuLyViewModel.Where(x => x.Id == 0);
            if (quaTrinhAdd.Any())
                QuaTrinhXuLyRepository.AddRange(quaTrinhAdd.Select(x => new CongViecQuaTrinhXuLyResult
                {
                    HoSoCongViecId = model.Id,
                    GioBanHanh = x.GioBanHanh,
                    PhutBanHanh = x.PhutBanHanh,
                    NgayBanHanh = x.NgayBanHanh,
                    NoiDung = x.NoiDung,
                    NguoiThem = x.NguoiThem,
                    NhacNho = x.NhacNho,
                    IsDeleted = false,
                    CreatedBy = UserName,
                }));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Id: CongViecId</param>
        /// <param name="model"></param>
        private void AddOrUpdatePhoiHop(int id, IEnumerable<CongViecPhoiHopResult> model)
        {
            if (model.Any())
            {
                CongViecPhoiHopRepository.AddOrUpdate(id, model, UserName);
            }
        }

        private BaseCongViecViewModel InitModel()
        {
            var model = new BaseCongViecViewModel
            {
                UsersInfos = UsersRepository.GetUsersByCoQuanId(TechOfficeConfig.IDENTITY_PHONGNOIVU).Select(x => x.ToDataInfo()),
                LinhVucCongViecInfos = LinhVucCongViecRepository.GetAll().Select(x => x.ToDataInfo()),
                TrangThaiCongViecInfos = TrangThaiCongViecRepository.GetAll().Select(x => x.ToDataInfo()),
            };

            return model;
        }

        private IPagedList<HoSoCongViecResult> Find(ValueSearchViewModel model)
        {
            var query = HoSoCongViecRepository.Find(model.ToValueSearch());
            return query.ToPagedList(model.Page, TechOfficeConfig.PAGESIZE);
        }

        private void MoveFiles(string guid, int congViecId)
        {
            try
            {
                string folderTemp = Path.Combine(Server.MapPath(TechOfficeConfig.FOLDER_UPLOAD), guid);

                if (Directory.Exists(folderTemp) && Directory.GetFiles(folderTemp).Count() > 0)
                {
                    string folderTN = EnsureFolderCongViec(congViecId);
                    foreach (var item in Directory.GetFiles(folderTemp))
                    {
                        string dest = Path.Combine(folderTN, Path.GetFileNameWithoutExtension(item) + DateTime.Now.ToString("ddMMyyyy") + Path.GetExtension(item));
                        System.IO.File.Move(item, dest);
                        HistoryMoveFiles(congViecId, dest);
                    }

                    Directory.Delete(folderTemp);
                }
            }
            catch (Exception ex)
            {
                LogService.Error(string.Format("Has Error while move files from {0} to {1}", guid, congViecId), ex);
            }
        }

        private void HistoryMoveFiles(int congViecId, string url)
        {
            TapTinCongViecRepository.Add(new TapTinCongViecResult
            {
                HoSoCongViecId = congViecId,
                UserUploadId = UserId,
                Url = url,
                CreatedBy = UserName,
            });
        }

        private string EnsureFolderCongViec(int congViecId)
        {
            string folderParentCV = Server.MapPath(TechOfficeConfig.FOLDER_UPLOAD_CONGVIEC);
            EnsureFolder(folderParentCV);

            string folderCV = Path.Combine(folderParentCV, congViecId.ToString().PadLeft(TechOfficeConfig.LENGTHFOLDER, TechOfficeConfig.PADDING_CHAR));
            EnsureFolder(folderCV);

            return folderCV;
        }

        private void EnsureFolder(string folder)
        {
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);
        }
    }
}