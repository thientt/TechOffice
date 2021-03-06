﻿using System;
using AnThinhPhat.Entities.Infos;

namespace AnThinhPhat.Entities.Results
{
    public class CongViecVanBanResult : BaseResult
    {
        public int HoSoCongViecId { get; set; }

        public string SoVanBan { get; set; }

        public DateTime? NgayBanHanh { get; set; }

        public string NoiDung { get; set; }

        public int CoQuanId { get; set; }

        public CoQuanInfo CoQuanIfo { get; set; }

        public HoSoCongViecInfo HoSoCongViec { get; set; }
    }
}