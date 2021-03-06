﻿using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using AnThinhPhat.Entities;
using AnThinhPhat.Entities.Results;
using AnThinhPhat.Services.Abstracts;
using AnThinhPhat.Utilities;
using AnThinhPhat.ViewModel;
using AnThinhPhat.ViewModel.CoQuan;
using Ninject;
using PagedList;

namespace AnThinhPhat.WebUI.Controllers
{
    [Authorize(Roles = (RoleConstant.SUPPER_ADMIN + TechOfficeConfig.SEPARATE_CHAR + RoleConstant.ADMIN))]
    public class CoQuanController : OfficeController
    {
        [Inject]
        public ICoQuanRepository CoQuanRepository { get; set; }

        [Inject]
        public INhomCoQuanRepository NhomCoQuanRepository { get; set; }

        public ActionResult Index()
        {
            var nhom = NhomCoQuanRepository.GetAll().Select(x => x.ToIfNotNullDataInfo());
            var model = new CoQuanViewModel {NhomCoQuanInfos = nhom};

            return View(model);
        }

        /// <summary>
        ///     Lists the specified page.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <returns></returns>
        [HttpGet]
        public PartialViewResult List(int? page)
        {
            var nhom = NhomCoQuanRepository.GetAll().Select(x => x.ToDataInfo());
            var items = CoQuanRepository.GetAll().Select(x => x.ToDataViewModel().Update(u =>
            {
                u.NhomCoQuanInfos = nhom;
                u.NhomCoQuanInfo = NhomCoQuanRepository.GetById(x.NhomCoQuanId).ToDataInfo();
            })).ToList();

            var pageNumber = page ?? 1;
            return PartialView(items.ToPagedList(pageNumber, TechOfficeConfig.PAGESIZE));
        }

        [HttpPost]
        public async Task<JsonResult> Create(CoQuanViewModel model)
        {
            return await ExecuteWithErrorHandling(async () =>
            {
                var result = model.ToDataResult<CoQuanResult>().Update(u =>
                {
                    u.NhomCoQuanId = model.NhomCoQuanId;
                    u.CreatedBy = UserName;
                });

                return await ExecuteResultAsync(async () => await CoQuanRepository.AddAsync(result));
            });
        }

        [HttpGet]
        public PartialViewResult Edit(int id)
        {
            var nhom = NhomCoQuanRepository.GetAll().Select(x => x.ToDataInfo());
            var data = CoQuanRepository.Single(id).ToDataViewModel().Update(u => { u.NhomCoQuanInfos = nhom; });

            return PartialView("Edit", data);
        }

        [HttpPost]
        public async Task<JsonResult> Edit(int id, CoQuanViewModel model)
        {
            return await ExecuteWithErrorHandling(async () =>
            {
                var cv = model.ToDataResult<CoQuanResult>().Update(u =>
                {
                    u.Id = id;
                    u.NhomCoQuanId = model.NhomCoQuanId;
                    u.LastUpdatedBy = UserName;
                });

                return await ExecuteResultAsync(async () => await CoQuanRepository.UpdateAsync(cv));
            });
        }

        [HttpPost, ActionName("Delete")]
        public async Task<JsonResult> DeleteConfirmed(int id)
        {
            return await ExecuteWithErrorHandling(async () =>
            {
                if (id == 0)
                {
                    Response.StatusCode = (int) HttpStatusCode.BadRequest;
                    return Json("Bad Request", JsonRequestBehavior.AllowGet);
                }

                return await ExecuteResultAsync(async () => await CoQuanRepository.DeleteByAsync(id));
            });
        }

        public JsonResult GetCoQuanByNhomCoQuan(int nhomCoQuanId)
        {
            return ExecuteWithErrorHandling(() =>
            {
                var result = CoQuanRepository.GetAllByNhomCoQuanId(nhomCoQuanId);
                var jsonResult = result.Aggregate("<option selected='selected' value>Tất cả</option>",
                    (current, item) => current + $"<option value={item.Id}>{item.Ten}</option>");

                return new JsonResult
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = jsonResult
                };
            });
        }
    }
}