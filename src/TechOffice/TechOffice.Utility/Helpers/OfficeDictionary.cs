﻿using System.ComponentModel;

namespace AnThinhPhat.Utilities
{
    public enum EnumRoleExecute
    {
        [Description("Tất cả")] TATCA = 1,

        [Description("Phụ trách")] PHUTRACH = 2,

        [Description("Xử lý chính")] XULYCHINH = 3,

        [Description("Phối hợp")] PHOIHOP = 4
    }

    public enum EnumStatus
    {
        [Description("Tất cả")] TATCA = 1,

        [Description("Chưa xử lý")] CHUAXULY = 2,

        [Description("Đang xử lý")] DANGXYLY = 3,

        [Description("Đã xử lý")] DAXULY = 4
    }

    public enum EnumNhacNho
    {
        [Description("-- Nhắc nhở --")]
        LEVEL0 = 1,

        [Description("Mức 1")]
        LEVEL1 = 2,

        [Description("Mức 2")]
        LEVEL2 = 3,
    }
}