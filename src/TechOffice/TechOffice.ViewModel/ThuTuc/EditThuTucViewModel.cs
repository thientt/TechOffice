﻿using AnThinhPhat.Entities.Infos;
using AnThinhPhat.Entities.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;

namespace AnThinhPhat.ViewModel.ThuTuc
{
    public class EditThuTucViewModel : ThuTucViewModel
    {
        [AllowHtml]
        [Required(ErrorMessageResourceName = ("ThuTuc_AddThuTuc_NoiDung"), ErrorMessageResourceType = typeof(Resources.Messages))]
        public string NoiDung { get; set; }

        [Required(ErrorMessageResourceName = ("ThuTuc_AddThuTuc_NgayBanHanh"), ErrorMessageResourceType = typeof(Resources.Messages))]
        public DateTime? NgayBanHanh { get; set; }

        [MaxLength(1024, ErrorMessageResourceType = typeof(Resources.Messages), ErrorMessageResourceName = "ThuTuc_AddThuTuc_TenThuTuc_MaxLength")]
        [Required(ErrorMessageResourceName = ("ThuTuc_AddThuTuc_TenThuTuc"), ErrorMessageResourceType = typeof(Resources.Messages))]
        public string TenThuTuc { get; set; }

        [Required(ErrorMessageResourceName = ("ThuTuc_AddThuTuc_CoQuanThucHien"), ErrorMessageResourceType = typeof(Resources.Messages))]
        public int[] CoQuanThucHienIds { get; set; }

        [Required(ErrorMessageResourceName = ("ThuTuc_AddThuTuc_LinhVucThuTuc"), ErrorMessageResourceType = typeof(Resources.Messages))]
        public int LinhVucThuTucId { get; set; }

        public IEnumerable<HttpPostedFileBase> Files { get; set; }

        public IEnumerable<TapTinThuTucResult> TapTinThuTucResults { get; set; }
    }
}
