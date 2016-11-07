﻿using System;
using TechOffice.Entities.Infos;

namespace TechOffice.Entities.Results
{
    public class CongViecVanBanResult : BaseResult
    {
        public int HoSoCongViecId { get; set; }

        public string SoVanBan { get; set; }

        public DateTime? NgayBanHanh { get; set; }

        public string NoiDung { get; set; }

        public string TenCoQuan { get; set; }

        public HoSoCongViecInfo HoSoCongViec { get; set; }
    }
}