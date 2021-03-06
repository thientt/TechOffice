﻿using System.Web.Mvc;
using System.Web.Routing;
using AnThinhPhat.Utilities;

namespace AnThinhPhat.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(UrlLink.TRANGCHU, UrlLink.TRANGCHU,
                new { controller = "Home", action = "Index" });

            routes.MapRoute(UrlLink.HISTORY, UrlLink.HISTORY,
                new { controller = "Intro", action = "Index" });

            routes.MapRoute(UrlLink.CHART, UrlLink.CHART,
                new { controller = "Intro", action = "Chart" });

            routes.MapRoute(UrlLink.VANBAN, UrlLink.VANBAN,
                new { controller = "VanBan", action = "Index" });

            routes.MapRoute(UrlLink.VANBAN_VIEW, UrlLink.VANBAN_VIEW,
               new { controller = "VanBan", action = "ViewVanBan" });

            routes.MapRoute(UrlLink.VANBAN_ADD, UrlLink.VANBAN_ADD,
              new { controller = "VanBan", action = "Add" });

            routes.MapRoute(UrlLink.VANBAN_DETAIL, UrlLink.VANBAN_DETAIL,
              new { controller = "VanBan", action = "Detail" },
              new { id = @"\d+" });

            routes.MapRoute(UrlLink.VANBAN_EDIT, UrlLink.VANBAN_EDIT,
             new { controller = "VanBan", action = "Edit" },
             new { id = @"\d+" });

            routes.MapRoute(UrlLink.THUTUC, UrlLink.THUTUC,
                new { controller = "ThuTuc", action = "Index" });

            routes.MapRoute(UrlLink.THUTUC_VIEW, UrlLink.THUTUC_VIEW,
               new { controller = "ThuTuc", action = "ViewThuTuc" });

            routes.MapRoute(UrlLink.THUTUC_ADD, UrlLink.THUTUC_ADD,
               new { controller = "ThuTuc", action = "Add" });

            routes.MapRoute(UrlLink.THUTUC_EDIT, UrlLink.THUTUC_EDIT,
             new { controller = "ThuTuc", action = "Edit" },
             new { id = @"\d+" });

            routes.MapRoute(UrlLink.THUTUC_DETAIL, UrlLink.THUTUC_DETAIL,
              new { controller = "ThuTuc", action = "Detail" },
              new { id = @"\d+" });

            routes.MapRoute(UrlLink.TACNGHIEP, UrlLink.TACNGHIEP,
                new { controller = "TacNghiep", action = "Index" });

            routes.MapRoute(UrlLink.CONGVIEC, UrlLink.CONGVIEC,
                 new { controller = "CongViec", action = "Index" });
            //new { controller = "CongViec", action = "Index", UserId = 0, Role = 0, TrangThaiCongViecId = -1, LinhVucCongViecId = 0, NoiDungCongViec = string.Empty },
            //new { userId = @"\d+", role = @"\d+", trangThaiCongViecId = @"\d+", linhVucCongViecId = @"\d+", });

            routes.MapRoute(UrlLink.TINTUC, UrlLink.TINTUC,
                new { controller = "Home", action = "Article" });

            routes.MapRoute(UrlLink.TACNGHIEP_THONGKE, UrlLink.TACNGHIEP_THONGKE,
               new { controller = "TacNghiep", action = "Statistic" });

            routes.MapRoute(UrlLink.TACNGHIEP_ADD, UrlLink.TACNGHIEP_ADD,
              new { controller = "TacNghiep", action = "Add" });

            routes.MapRoute(UrlLink.TACNGHIEP_DETAIL, UrlLink.TACNGHIEP_DETAIL,
            new { controller = "TacNghiep", action = "Detail" },
            new { id = @"\d+" });

            routes.MapRoute(UrlLink.CONGVIEC_THONGKE_TIMKIEM, UrlLink.CONGVIEC_THONGKE_TIMKIEM,
             new { controller = "CongViec", action = "StatisticAndSearch" });

            routes.MapRoute(UrlLink.CONGVIEC_THONGKE, UrlLink.CONGVIEC_THONGKE,
            new { controller = "CongViec", action = "Statistic" });

            routes.MapRoute(UrlLink.CONGVIEC_THONGKE_TONGHOP, UrlLink.CONGVIEC_THONGKE_TONGHOP,
            new { controller = "CongViec", action = "Summaries" });

            routes.MapRoute(UrlLink.CONGVIEC_TIMKIEM, UrlLink.CONGVIEC_TIMKIEM,
            new { controller = "CongViec", action = " Search" });

            routes.MapRoute(UrlLink.CONGVIEC_ADD, UrlLink.CONGVIEC_ADD,
              new { controller = "CongViec", action = "Add" });

            routes.MapRoute(UrlLink.CONGVIEC_DETAIL, UrlLink.CONGVIEC_DETAIL,
              new { controller = "CongViec", action = "Detail" },
              new { id = @"\d+" });

            routes.MapRoute(UrlLink.LIENHE, UrlLink.LIENHE, new { controller = "Home", action = "Contact" });
            routes.MapRoute(UrlLink.LOGIN, UrlLink.LOGIN, new { controller = "Account", action = "LogIn" });
            //Error
            routes.MapRoute("error", "error/internalserver",
                new { controller = "Error", action = "InternalServer" });

            routes.MapRoute(UrlLink.ERROR_NOTFOUND404, "error/notfound404",
                new { controller = "Error", action = "NotFound" });

            routes.MapRoute(UrlLink.ERROR_NOTFOUND405, "error/notfound405",
                new { controller = "Error", action = "NotFound405" });

            routes.MapRoute("ErrorUnauthorized", "error/unauthorized",
                new { controller = "Error", action = "Unauthorized" });

            routes.MapRoute("ErrorForbidenaccess", "error/forbidenaccess",
                new { controller = "Error", action = "ForbidenAccess" });

            //End Error

            //===========================================CRUD DATA=======================================//
            routes.MapRoute(UrlLink.CHUCVU, UrlLink.CHUCVU,
                new { controller = "ChucVu", action = "Index" });

            routes.MapRoute(UrlLink.COQUAN, UrlLink.COQUAN,
               new { controller = "CoQuan", action = "Index" });

            routes.MapRoute(UrlLink.NHOMCOQUAN, UrlLink.NHOMCOQUAN,
              new { controller = "NhomCoQuan", action = "Index" });

            routes.MapRoute(UrlLink.LINHVUCCONGVIEC, UrlLink.LINHVUCCONGVIEC,
             new { controller = "LinhVucCongViec", action = "Index" });

            routes.MapRoute(UrlLink.LINHVUCTHUTUC, UrlLink.LINHVUCTHUTUC,
             new { controller = "LinhVucThuTuc", action = "Index" });

            routes.MapRoute(UrlLink.LINHVUCVANBAN, UrlLink.LINHVUCVANBAN,
              new { controller = "LinhVucVanBan", action = "Index" });

            routes.MapRoute(UrlLink.LINHVUCTACNGHIEP, UrlLink.LINHVUCTACNGHIEP,
           new { controller = "LinhVucTacNghiep", action = "Index" });

            routes.MapRoute(UrlLink.LOAIVANBAN, UrlLink.LOAIVANBAN,
             new { controller = "LoaiVanBan", action = "Index" });

            routes.MapRoute(UrlLink.MUCDOHOANTHANH, UrlLink.MUCDOHOANTHANH,
             new { controller = "MucDoHoanThanh", action = "Index" });

            routes.MapRoute(UrlLink.COQUANBANHANHVANBAN, UrlLink.COQUANBANHANHVANBAN,
            new { controller = "CoQuanBanHanhVanBan", action = "Index" });

            routes.MapRoute(UrlLink.NEWSCATEGORY, UrlLink.NEWSCATEGORY,
            new { controller = "NewsCategory", action = "Index" });

            routes.MapRoute(UrlLink.NEWS_LIST, UrlLink.NEWS_LIST,
            new { controller = "News", action = "Index" });

            routes.MapRoute(UrlLink.NEWS_ADD, UrlLink.NEWS_ADD,
            new { controller = "News", action = "Add" });

            routes.MapRoute(UrlLink.NEWS_EDIT, UrlLink.NEWS_EDIT,
            new { controller = "News", action = "Edit" },
            new { id = @"\d+" });

            routes.MapRoute(UrlLink.NEWS, UrlLink.NEWS,
            new { controller = "Home", action = "ReadNews" },
            new { id = @"\d+" });
            //===========================================CRUD DATA=======================================//

            routes.MapRoute(UrlLink.ADMIN, UrlLink.ADMIN,
            new { controller = "Admin", action = "Index" });

            routes.MapRoute(UrlLink.USERS, UrlLink.USERS,
            new { controller = "Users", action = "Index" });

            routes.MapRoute(UrlLink.USERS_ADD, UrlLink.USERS_ADD,
            new { controller = "Users", action = "Create" });

            routes.MapRoute(UrlLink.USERS_EDIT, UrlLink.USERS_EDIT,
            new { controller = "Users", action = "Edit" },
            new { id = @"\d+" });

            routes.MapRoute(UrlLink.ACCOUNT_CHANGEPASSWORD, UrlLink.ACCOUNT_CHANGEPASSWORD,
          new { controller = "Account", action = "ChangePassword" });

            routes.MapRoute("Default", "{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional });
        }
    }
}