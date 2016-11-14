﻿using System;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AnThinhPhat.Services;
using AnThinhPhat.Utilities;
using Microsoft.Owin.Security;
using Ninject;
using AnThinhPhat.Services.Abstracts;
using AnThinhPhat.Entities.Infos;
using AnThinhPhat.Entities.Results;

namespace AnThinhPhat.WebUI.Controllers
{
    public class OfficeController : Controller
    {
        protected IAuthenticationManager AuthenticationManager
        {
            get
            {
                var ctx = Request.GetOwinContext();
                return ctx.Authentication;
            }
        }

        [Inject]
        public IUsersRepository UserRepository { get; set; }

        protected string UserName
        {
            get
            {
#if DEBUG
                return "admin";
#endif
                var claim = User as ClaimsPrincipal;
                if (claim != null)
                    return claim.FindFirst(ClaimTypes.Name).Value;
                return string.Empty;
            }
        }

        protected string UserId
        {
            get
            {
#if DEBUG
                return "1";
#endif
                var claim = User as ClaimsPrincipal;
                if (claim != null)
                    return claim.FindFirst(ClaimTypes.NameIdentifier).Value;
                return string.Empty;
            }
        }

        [Inject]
        public ILogService LogService { get; set; }

        protected JsonResult ExecuteWithErrorHandling(Func<JsonResult> action)
        {
            CheckModelState();

            if (action != null)
            {
                try
                {
                    return action();
                }
                catch (Exception ex)
                {
                    LogService.Error(ex);
                }
            }

            return new JsonResult
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = new { code = "SB02" }
            };
        }

        protected async Task<JsonResult> ExecuteWithErrorHandling(Func<Task<JsonResult>> action)
        {
            CheckModelState();

            if (action != null)
            {
                try
                {
                    return await action();
                }
                catch (Exception ex)
                {
                    LogService.Error(ex);
                }
            }

            return new JsonResult
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = new { code = "SB02" }
            };
        }

        protected async Task<JsonResult> ExecuteResultAsync(Func<Task<SaveResult>> func)
        {
            if (func == null)
                throw new Exception();

            var result = await func();

            switch (result)
            {
                case SaveResult.SUCCESS:
                    Response.StatusCode = (int)HttpStatusCode.OK;
                    return new JsonResult
                    {
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                        Data = new { code = "SB01" }
                    };
                default:
                    return new JsonResult
                    {
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                        Data = new { code = "SB02" }
                    };
            }
        }

        protected JsonResult ExecuteResult(Func<SaveResult> func)
        {
            if (func == null)
                throw new Exception();

            var result = func();

            switch (result)
            {
                case SaveResult.SUCCESS:
                    Response.StatusCode = (int)HttpStatusCode.OK;
                    return new JsonResult
                    {
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                        Data = new { code = "SB01" }
                    };
                default:
                    return new JsonResult
                    {
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                        Data = new { code = "SB02" }
                    };
            }
        }

        protected ActionResult ExecuteWithErrorHandling(Func<ActionResult> action)
        {
            CheckModelState();

            if (action != null)
            {
                try
                {
                    return action();
                }
                catch (Exception ex)
                {
                    LogService.Error(ex);
                }
            }
            return RedirectToRoute(Utilities.UrlLink.ERROR_NOTFOUND404);
        }

        protected UserResult AuthInfo()
        {
            return UserRepository.Single(Convert.ToInt32(UserId));
        }

        private void CheckModelState()
        {
            if (!ModelState.IsValid)
            {
                throw new ArgumentException();
            }
        }
    }
}