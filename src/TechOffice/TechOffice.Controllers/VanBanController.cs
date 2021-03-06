﻿using System.Linq;
using System.Web.Mvc;
using AnThinhPhat.Entities;
using AnThinhPhat.Services.Abstracts;
using AnThinhPhat.ViewModel.VanBan;
using Ninject;
using AnThinhPhat.Entities.Results;
using PagedList;
using AnThinhPhat.Utilities;
using System.Web;
using System.IO;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace AnThinhPhat.WebUI.Controllers
{
    public class VanBanController : OfficeController
    {
        [Inject]
        public ILoaiVanBanRepository LoaiVanBanRepository { get; set; }

        [Inject]
        public ILinhVucVanBanRepository LinhVucVanRepository { get; set; }

        [Inject]
        public ICoQuanBanHanhVanBanRepository CoQuanBanHanhVanBanRepository { get; set; }

        [Inject]
        public IVanBanRepository VanBanRepository { get; set; }

        [Inject]
        public ITapTinVanBanRepository FilesRepository { get; set; }

        //public ActionResult Index(int? linhVucVanBanId, int? loaiVanBan, int? coQuanBanHanhVanBanId, int? namBanHanhId, int pagingNumberId = 20,
        //    string tenVanBan = "",
        //    bool timTrongSoHieu = false,
        //    bool timTrongTrichYeu = false,
        //    bool timTrongNoiDung = false)
        //{
        //    var model = CreateVanBanModel(linhVucVanBanId,
        //        loaiVanBan,
        //        coQuanBanHanhVanBanId,
        //        namBanHanhId,
        //        pagingNumberId,
        //        tenVanBan,
        //        timTrongSoHieu,
        //        timTrongTrichYeu,
        //        timTrongNoiDung);
        //    return View(model);
        //}
        public ActionResult Index(int?[] linhVucVanBanIds, int?[] loaiVanBanIds, int?[] coQuanBanHanhVanBanIds, int?[] namBanHanhIds, int pagingNumberId = 20,
           string tenVanBan = "",
           bool timTrongSoHieu = false,
           bool timTrongTrichYeu = false,
           bool timTrongNoiDung = false)
        {
            var model = CreateVanBanModel(linhVucVanBanIds,
                loaiVanBanIds,
                coQuanBanHanhVanBanIds,
                namBanHanhIds,
                pagingNumberId,
                tenVanBan,
                timTrongSoHieu,
                timTrongTrichYeu,
                timTrongNoiDung);
            return View(model);
        }

        public ActionResult List(ValueSearchViewModel search)
        {
            return ExecuteWithErrorHandling(() =>
            {
                var model = Find(search);
                return PartialView("_PartialPageList", model);
            });
        }

        [Authorize]
        public ActionResult ViewVanBan()
        {
            return View();
        }

        public ActionResult ViewList(int? page)
        {
            return ExecuteWithErrorHandling(() =>
            {
                var model = Find(new ValueSearchViewModel
                {
                    Page = page ?? 1
                });
                return PartialView("_ViewList", model);
            });
        }

        public PartialViewResult Detail(int id)
        {
            var model = VanBanRepository.Single(id);
            return PartialView("_PartialPageDetail", model);
        }

        [HttpGet, Authorize]
        public ActionResult Add()
        {
            var model = new AddVanBanViewModel();
            var init = InitViewModel();
            model.CoQuanBanHanhVanBanInfos = init.CoQuanBanHanhVanBanInfos;
            model.LoaiVanBanInfos = init.LoaiVanBanInfos;
            model.LinhVucVanBanInfos = init.LinhVucVanBanInfos;

            return View(model);
        }

        [HttpPost, Authorize]
        public ActionResult Add(AddVanBanViewModel model)
        {
            var dataSave = new VanBanResult
            {
                TenVanBan = model.SoVanBan,
                NoiDung = model.NoiDungVanBan,
                TrichYeu = model.TrichYeuVanBan,
                LinhVucVanBanId = model.LinhVucVanBanId,
                LoaiVanBanId = model.LoaiVanBanId,
                CoQuanBanHanhId = model.CoQuanBanhHanhVanBanId,
                NgayBanHanh = model.NgayBanHanh,
                SoVanBan = model.SoVanBan,
                CreatedBy = UserName,
            };

            var result = VanBanRepository.Add(dataSave);

            if (result == Services.SaveResult.SUCCESS && dataSave.Id > 0)
                SaveFiles(dataSave.Id, model.Files);

            return RedirectToRoute(UrlLink.VANBAN_EDIT, new { sovanban = dataSave.SoVanBan.RejectMarks(), id = dataSave.Id });
        }

        [Authorize, HttpGet]
        public ActionResult Edit(int id)
        {
            return ExecuteWithErrorHandling(() =>
            {
                var data = VanBanRepository.Single(id);
                var init = InitViewModel();
                var model = new EditVanBanViewModel
                {
                    CoQuanBanHanhVanBanInfos = init.CoQuanBanHanhVanBanInfos,
                    LoaiVanBanInfos = init.LoaiVanBanInfos,
                    LinhVucVanBanInfos = init.LinhVucVanBanInfos,
                    LinhVucVanBanId = data.LinhVucVanBanId,
                    CoQuanBanhHanhVanBanId = data.CoQuanBanHanhId,
                    LoaiVanBanId = data.LoaiVanBanId,
                    NgayBanHanh = data.NgayBanHanh,
                    NoiDungVanBan = data.NoiDung,
                    SoVanBan = data.SoVanBan,
                    TrichYeuVanBan = data.TrichYeu,
                    TapTinVanBanResults = data.Files,
                };
                return View(model);
            });
        }

        [Authorize, HttpPost]
        public ActionResult Edit(int id, EditVanBanViewModel model)
        {
            var data = VanBanRepository.Single(id);
            data.LinhVucVanBanId = model.LinhVucVanBanId;
            data.CoQuanBanHanhId = model.CoQuanBanhHanhVanBanId;
            data.LoaiVanBanId = model.LoaiVanBanId;
            data.NgayBanHanh = model.NgayBanHanh;
            data.NoiDung = model.NoiDungVanBan;
            data.SoVanBan = model.SoVanBan;
            data.TrichYeu = model.TrichYeuVanBan;
            data.LastUpdatedBy = UserName;

            var result = VanBanRepository.Update(data);
            if (result == Services.SaveResult.SUCCESS)
                SaveFiles(id, model.Files);

            return RedirectToRoute(UrlLink.VANBAN);
        }

        [Authorize, HttpPost, ActionName("Delete")]
        public async Task<JsonResult> DeleteConfirmed(int id)
        {
            return await ExecuteWithErrorHandling(async () =>
            {
                if (id == 0)
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return Json("Bad Request", JsonRequestBehavior.AllowGet);
                }

                return await ExecuteResultAsync(async () => await VanBanRepository.DeleteByAsync(id));
            });
        }

        //private InitVanBanViewModel CreateVanBanModel(int? linhVucVanBanId = null,
        //    int? loaiVanBan = null,
        //    int? coQuanBanHanhVanBanId = null,
        //    int? namBanHanhId = null,
        //    int pagingNumberId = 20,
        //    string tenVanBan = "",
        //    bool timTrongSoHieu = false,
        //    bool timTrongTrichYeu = false,
        //    bool timTrongNoiDung = false)
        //{
        //    var model = new InitVanBanViewModel
        //    {
        //        CoQuanBanHanhVanBanInfos = CoQuanBanHanhVanBanRepository.GetAll().Select(x => x.ToDataInfo()),
        //        LinhVucVanBanInfos = LinhVucVanRepository.GetAll().Select(x => x.ToDataInfo()),
        //        LoaiVanBanInfos = LoaiVanBanRepository.GetAll().Select(x => x.ToDataInfo()),

        //        ValueSearch = new ValueSearchViewModel
        //        {
        //            LinhVucVanBanId = linhVucVanBanId,
        //            LoaiVanBanId = loaiVanBan,
        //            CoQuanBanHanhVanBanId = coQuanBanHanhVanBanId,
        //            NamBanHanhId = namBanHanhId,
        //            PagingNumberId = pagingNumberId,
        //            TenVanBan = tenVanBan,
        //            TimTrongNoiDung = timTrongNoiDung,
        //            TimTrongSoHieu = timTrongSoHieu,
        //            TimTrongTrichYeu = timTrongTrichYeu,
        //            Page = 1,
        //        },
        //        CoQuanBanHanhVanBanId = coQuanBanHanhVanBanId,
        //        LinhVucVanBanId = linhVucVanBanId,
        //    };

        //    return model;
        //}


        private InitVanBanViewModel CreateVanBanModel(int?[] linhVucVanBanIds = null,
           int?[] loaiVanBans = null,
           int?[] coQuanBanHanhVanBanIds = null,
           int?[] namBanHanhIds = null,
           int pagingNumberId = 20,
           string tenVanBan = "",
           bool timTrongSoHieu = false,
           bool timTrongTrichYeu = false,
           bool timTrongNoiDung = false)
        {
            var model = new InitVanBanViewModel
            {
                CoQuanBanHanhVanBanInfos = CoQuanBanHanhVanBanRepository.GetAll().Select(x => x.ToDataInfo()),
                LinhVucVanBanInfos = LinhVucVanRepository.GetAll().Select(x => x.ToDataInfo()),
                LoaiVanBanInfos = LoaiVanBanRepository.GetAll().Select(x => x.ToDataInfo()),

                ValueSearch = new ValueSearchViewModel
                {
                    LinhVucVanBanIds = linhVucVanBanIds,
                    LoaiVanBanIds = loaiVanBans,
                    CoQuanBanHanhVanBanIds = coQuanBanHanhVanBanIds,
                    NamBanHanhIds = namBanHanhIds,
                    PagingNumberId = pagingNumberId,
                    TenVanBan = tenVanBan,
                    TimTrongNoiDung = timTrongNoiDung,
                    TimTrongSoHieu = timTrongSoHieu,
                    TimTrongTrichYeu = timTrongTrichYeu,
                    Page = 1,
                },
                CoQuanBanHanhVanBanIds = coQuanBanHanhVanBanIds,
                LinhVucVanBanIds = linhVucVanBanIds,
            };

            return model;
        }

        private InitVanBanViewModel InitViewModel()
        {
            return new InitVanBanViewModel
            {
                LoaiVanBanInfos = LoaiVanBanRepository.GetAll().Select(x => x.ToDataInfo()),
                CoQuanBanHanhVanBanInfos = CoQuanBanHanhVanBanRepository.GetAll().Select(x => x.ToDataInfo()),
                LinhVucVanBanInfos = LinhVucVanRepository.GetAll().Select(x => x.ToDataInfo()),
            };
        }

        private IPagedList<VanBanResult> Find(ValueSearchViewModel model)
        {
            var seachAll = VanBanRepository.GetAll();

            //if (model.CoQuanBanHanhVanBanId.HasValue)
            //    seachAll = seachAll.Where(x => x.CoQuanBanHanhId == model.CoQuanBanHanhVanBanId);

            //if (model.LoaiVanBanId.HasValue)
            //    seachAll = seachAll.Where(x => x.LoaiVanBanId == model.LoaiVanBanId);

            //if (model.LinhVucVanBanId.HasValue)
            //    seachAll = seachAll.Where(x => x.LinhVucVanBanId == model.LinhVucVanBanId);

            //if (model.NamBanHanhId.HasValue)
            //    seachAll = seachAll.Where(x => x.NgayBanHanh.Year == model.NamBanHanhId);

            if (model.CoQuanBanHanhVanBanIds != null && model.CoQuanBanHanhVanBanIds.Any())
                seachAll = seachAll.Where(x => model.CoQuanBanHanhVanBanIds.Any(y => y == x.CoQuanBanHanhId));

            if (model.LoaiVanBanIds != null && model.LoaiVanBanIds.Any())
                seachAll = seachAll.Where(x => model.LoaiVanBanIds.Any(y => y == x.LoaiVanBanId));

            if (model.LinhVucVanBanIds != null && model.LinhVucVanBanIds.Any())
                seachAll = seachAll.Where(x => model.LinhVucVanBanIds.Any(y => y == x.LinhVucVanBanId));

            if (model.NamBanHanhIds != null && model.NamBanHanhIds.Any())
                seachAll = seachAll.Where(x => model.NamBanHanhIds.Any(y => y == x.NgayBanHanh.Year));

            if (!string.IsNullOrEmpty(model.TenVanBan))
            {
                if (model.TimTrongNoiDung)
                    seachAll = seachAll.Where(x => x.NoiDung.Contains(model.TenVanBan));

                if (model.TimTrongSoHieu)
                    seachAll = seachAll.Where(x => x.SoVanBan.Contains(model.TenVanBan));

                if (model.TimTrongTrichYeu)
                    seachAll = seachAll.Where(x => x.TrichYeu.Contains(model.TenVanBan));
            }

            return seachAll.ToPagedList(model.Page, TechOfficeConfig.PAGESIZE);
        }

        private void SaveFiles(int id, IEnumerable<HttpPostedFileBase> files)
        {
            ExecuteTryLogException(() =>
            {
                foreach (var file in files)
                {
                    SaveFilesVanBan(file, id);
                    FilesRepository.Add(new TapTinVanBanResult
                    {
                        VanBanId = id,
                        CreatedBy = UserName,
                        UserUploadId = UserId,
                        Url = Path.Combine(TechOfficeConfig.FOLDER_VB, id.ToString().PadLeft(TechOfficeConfig.LENGTHFOLDER, TechOfficeConfig.PAD_CHAR), file.FileName),
                    });
                }
            });
        }

        private void SaveFilesVanBan(HttpPostedFileBase file, int vanBanId)
        {
            var folderVanBan = EnsureFolderVanBan(vanBanId);
            var savedFileName = Path.Combine(folderVanBan, Path.GetFileName(file.FileName));
            try
            {
                file.SaveAs(savedFileName); // Save the file
            }
            catch (Exception ex)
            {
                LogService.Error($"Has error in while save file {file.FileName}", ex);
            }
        }

        private string EnsureFolderVanBan(int id)
        {
            try
            {
                //1. Get folder upload
                string folderUpload = Server.MapPath(TechOfficeConfig.FOLDER_UPLOAD_VB);
                EnsureFolder(folderUpload);

                string folderVanBan = Path.Combine(folderUpload, id.ToString().PadLeft(TechOfficeConfig.LENGTHFOLDER, TechOfficeConfig.PAD_CHAR));
                EnsureFolder(folderVanBan);

                return folderVanBan;
            }
            catch (Exception ex)
            {
                LogService.Error("Has error in while create new Temp folder upload", ex);
                throw;
            }
        }

        private void EnsureFolder(string folder)
        {
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);
        }
    }
}