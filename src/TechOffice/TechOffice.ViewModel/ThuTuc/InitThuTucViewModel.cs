﻿using System.Collections.Generic;
using AnThinhPhat.Entities.Infos;

namespace AnThinhPhat.ViewModel.ThuTuc
{
    public class InitThuTucViewModel
    {
        public string ThuTucCongViec { get; set; }

        public int? CoQuanId { get; set; }

        public IEnumerable<CoQuanInfo> CoQuanInfos { get; set; }

        public int? LinhVucThuTucId { get; set; }

        public IEnumerable<LinhVucThuTucInfo> LinhVucThuTucInfo { get; set; }

        public ValueSearchViewModel ValueSearch { get; set; }
    }
}