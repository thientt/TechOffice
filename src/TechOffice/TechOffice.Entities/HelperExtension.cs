﻿using System.Linq;
using AnThinhPhat.Entities.Infos;
using AnThinhPhat.Entities.Results;
using System.Data.Entity;
using System.Threading.Tasks;
using System;
using AnThinhPhat.Utilities.Enums;
using AnThinhPhat.Entities;

namespace AnThinhPhat.Entities
{
    public static class HelperExtension
    {
        public static T[] MakeQueryToDatabase<T>(this IQueryable<T> source)
        {
            return source.ToArray();
        }

        public async static Task<T[]> MakeQueryToDatabaseAsync<T>(this IQueryable<T> source)
        {
            return await source.ToArrayAsync();
        }
    }

    public static class ChucVuExtension
    {
        public static ChucVuResult ToIfNotNullDataResult(this ChucVu entity)
        {
            return entity?.ToDataResult();
        }

        public static ChucVuResult ToDataResult(this ChucVu entity)
        {
            return new ChucVuResult
            {
                Id = entity.Id,
                Ten = entity.Ten,
                MoTa = entity.MoTa,
                CreateDate = entity.CreateDate,
                CreatedBy = entity.CreatedBy,
                IsDeleted = entity.IsDeleted,
                LastUpdated = entity.LastUpdated,
                LastUpdatedBy = entity.LastUpdatedBy
            };
        }

        public static ChucVuInfo ToIfNotNullDataInfo(this ChucVuResult entity)
        {
            return entity?.ToDataInfo();
        }

        public static ChucVuInfo ToDataInfo(this ChucVuResult entity)
        {
            return new ChucVuInfo
            {
                Id = entity.Id,
                Name = entity.Ten
            };
        }

        public static ChucVuInfo ToIfNotNullDataInfo(this ChucVu entity)
        {
            return entity?.ToDataInfo();
        }

        public static ChucVuInfo ToDataInfo(this ChucVu entity)
        {
            return new ChucVuInfo
            {
                Id = entity.Id,
                Name = entity.Ten
            };
        }
    }

    public static class CoQuanExtension
    {
        public static CoQuanResult ToIfNotNullDataResult(this CoQuan entity)
        {
            return entity?.ToDataResult();
        }

        public static CoQuanResult ToDataResult(this CoQuan entity)
        {
            return new CoQuanResult
            {
                Id = entity.Id,
                Ten = entity.Ten,
                MoTa = entity.MoTa,
                NhomCoQuanId = entity.NhomCoQuanId,
                NhomCoQuan = entity.NhomCoQuan.ToDataResult().ToDataInfo(),
                CreateDate = entity.CreateDate,
                CreatedBy = entity.CreatedBy,
                IsDeleted = entity.IsDeleted,
                LastUpdated = entity.LastUpdated,
                LastUpdatedBy = entity.LastUpdatedBy
            };
        }

        public static CoQuanInfo ToIfNotNullDataInfo(this CoQuanResult entity)
        {
            return entity?.ToDataInfo();
        }

        public static CoQuanInfo ToDataInfo(this CoQuanResult entity)
        {
            return new CoQuanInfo
            {
                Id = entity.Id,
                Name = entity.Ten,
                NhomCoQuanId = entity.NhomCoQuanId,
            };
        }

        public static CoQuanInfo ToIfNotNullDataInfo(this CoQuan entity)
        {
            return entity?.ToDataInfo();
        }

        public static CoQuanInfo ToDataInfo(this CoQuan entity)
        {
            return new CoQuanInfo
            {
                Id = entity.Id,
                Name = entity.Ten,
                NhomCoQuanId = entity.NhomCoQuanId,
            };
        }
    }

    public static class CongViecPhoiHopExtension
    {
        public static CongViecPhoiHopResult ToIfNotNullDataResult(this CongViec_PhoiHop entity)
        {
            return entity?.ToDataResult();
        }

        public static CongViecPhoiHopResult ToDataResult(this CongViec_PhoiHop entity)
        {
            return new CongViecPhoiHopResult
            {
                Id = entity.Id,
                HoSoCongViec = entity.HoSoCongViec.ToDataInfo(),
                HoSoCongViecId = entity.HoSoCongViecId,
                UserInfo = entity.User.ToDataInfo(),
                UserId = entity.UserId,
                CreateDate = entity.CreateDate,
                CreatedBy = entity.CreatedBy,
                IsDeleted = entity.IsDeleted,
                LastUpdated = entity.LastUpdated,
                LastUpdatedBy = entity.LastUpdatedBy
            };
        }
    }

    public static class CongViecQuaTrinhXuLyExtension
    {
        public static CongViecQuaTrinhXuLyResult ToIfNotNullDataResult(this CongViec_QuaTrinhXuLy entity)
        {
            return entity?.ToDataResult();
        }

        public static CongViecQuaTrinhXuLyResult ToDataResult(this CongViec_QuaTrinhXuLy entity)
        {
            return new CongViecQuaTrinhXuLyResult
            {
                Id = entity.Id,
                HoSoCongViec = entity.HoSoCongViec.ToDataInfo(),
                HoSoCongViecId = entity.HoSoCongViecId,
                PhutBanHanh = entity.PhutBanHanh,
                GioBanHanh = entity.GioBanHanh,
                NgayBanHanh = entity.NgayBanHanh,
                NguoiThem = entity.NguoiThem,
                NhacNho = entity.NhacNho,
                NoiDung = entity.NoiDung,
                CreateDate = entity.CreateDate,
                CreatedBy = entity.CreatedBy,
                IsDeleted = entity.IsDeleted,
                LastUpdated = entity.LastUpdated,
                LastUpdatedBy = entity.LastUpdatedBy
            };
        }
    }

    public static class CongViecVanVanLienQuanExtension
    {
        public static CongViecVanBanResult ToIfNotNullDataResult(this CongViec_VanBan entity)
        {
            return entity?.ToDataResult();
        }

        public static CongViecVanBanResult ToDataResult(this CongViec_VanBan entity)
        {
            return new CongViecVanBanResult
            {
                Id = entity.Id,
                HoSoCongViecId = entity.HoSoCongViecId,
                HoSoCongViec = entity.HoSoCongViec.ToDataInfo(),
                SoVanBan = entity.SoVanBan,
                CoQuanId = entity.CoQuanId,
                CoQuanIfo = entity.CoQuan.ToDataInfo(),
                NgayBanHanh = entity.NgayBanHanh,
                NoiDung = entity.NoiDung,
                IsDeleted = entity.IsDeleted,
                CreateDate = entity.CreateDate,
                CreatedBy = entity.CreatedBy,
                LastUpdatedBy = entity.LastUpdatedBy,
                LastUpdated = entity.LastUpdated
            };
        }
    }

    public static class VanBanExtension
    {
        public static VanBanResult ToIfNotNullDataResult(this VanBan entity)
        {
            return entity?.ToDataResult();
        }

        public static VanBanResult ToDataResult(this VanBan entity)
        {
            return new VanBanResult
            {
                Id = entity.Id,
                SoVanBan = entity.SoVanBan,
                TenVanBan = entity.TenVanBan,
                NoiDung = entity.NoiDung,
                TrichYeu = entity.TrichYeu,
                NgayBanHanh = entity.NgayBanHanh,
                CoQuanBanHanhId = entity.CoQuanBanHanhId,
                CoQuanBanHanhVanBanInfo = entity.CoQuanBanHanhVanBan.ToDataInfo(),
                LinhVucVanBanId = entity.LinhVucVanBanId,
                LinhVucVanBanInfo = entity.LinhVucVanBan.ToDataInfo(),
                LoaiVanBanId = entity.LoaiVanBanId,
                LoaiVanBanInfo = entity.LoaiVanBan.ToDataInfo(),
                Files = entity.TapTinVanBans.Select(x => x.ToDataResult()).ToList(),
                CreateDate = entity.CreateDate,
                CreatedBy = entity.CreatedBy,
                IsDeleted = entity.IsDeleted,
                LastUpdated = entity.LastUpdated,
                LastUpdatedBy = entity.LastUpdatedBy
            };
        }

        public static VanBanInfo ToIfNotNullDataInfo(this VanBanResult entity)
        {
            return entity?.ToDataInfo();
        }

        public static VanBanInfo ToDataInfo(this VanBanResult entity)
        {
            return new VanBanInfo
            {
                Id = entity.Id,
                SoVanBan = entity.SoVanBan,
                TenVanBan = entity.TenVanBan
            };
        }

        public static VanBanInfo ToIfNotNullDataInfo(this VanBan entity)
        {
            return entity?.ToDataInfo();
        }

        public static VanBanInfo ToDataInfo(this VanBan entity)
        {
            return new VanBanInfo
            {
                Id = entity.Id,
                SoVanBan = entity.SoVanBan,
                TenVanBan = entity.TenVanBan
            };
        }
    }

    public static class TapTinVanBanExtension
    {
        public static TapTinVanBanResult ToIfNotNullDataResult(this TapTinVanBan entity)
        {
            return entity?.ToDataResult();
        }

        public static TapTinVanBanResult ToDataResult(this TapTinVanBan entity)
        {
            return new TapTinVanBanResult
            {
                Id = entity.Id,
                VanBanId = entity.VanBanId,
                VanBanInfo = entity.VanBan.ToDataInfo(),
                Url = entity.Url,
                FileName = System.IO.Path.GetFileName(entity.Url),
                Path = System.IO.Path.GetDirectoryName(entity.Url),
                UserUploadId = entity.UserUploadId,
                UserInfo = entity.User.ToDataInfo(),
                CreateDate = entity.CreateDate,
                CreatedBy = entity.CreatedBy,
                IsDeleted = entity.IsDeleted,
                LastUpdated = entity.LastUpdated,
                LastUpdatedBy = entity.LastUpdatedBy
            };
        }
    }

    public static class HoSoCongViecExtension
    {
        public static HoSoCongViecResult ToIfNotNullDataResult(this HoSoCongViec entity)
        {
            return entity?.ToDataResult();
        }

        public static HoSoCongViecResult ToDataResult(this HoSoCongViec entity)
        {
            return new HoSoCongViecResult
            {
                Id = entity.Id,
                NoiDung = entity.NoiDung,
                NgayHetHan = entity.NgayHetHan,
                NgayTao = entity.NgayTao,
                TrangThaiCongViecId = entity.TrangThaiCongViecId,
                TrangThaiCongViecInfo = entity.TrangThaiCongViec.ToIfNotNullDataInfo(),
                LinhVucCongViecId = entity.LinhVucCongViecId,
                LinhVucCongViec = entity.LinhVucCongViec.ToDataInfo(),
                DanhGiaCongViec = entity.DanhGiaCongViec,
                UserPhuTrachId = entity.UserPhuTrachId,
                UserPhuTrach = entity.User.ToDataInfo(),
                UserXuLyId = entity.UserXuLyId,
                UserXyLy = entity.User1.ToDataInfo(),
                CongViecPhoiHopResult = entity.CongViec_PhoiHop.Where(x => !x.IsDeleted).Select(x => x.ToDataResult()).ToList(),
                CongViecQuaTrinhXuLyResult = entity.CongViec_QuaTrinhXuLy.Where(x => !x.IsDeleted).Select(x => x.ToDataResult()).ToList(),
                CongViecVanBanResults = entity.CongViec_VanBan.Where(x => !x.IsDeleted).Select(x => x.ToDataResult()).ToList(),
                CreateDate = entity.CreateDate,
                CreatedBy = entity.CreatedBy,
                IsDeleted = entity.IsDeleted,
                LastUpdated = entity.LastUpdated,
                LastUpdatedBy = entity.LastUpdatedBy
            };
        }

        public static HoSoCongViecInfo ToIfNotNullDataInfo(this HoSoCongViecResult entity)
        {
            return entity?.ToDataInfo();
        }

        public static HoSoCongViecInfo ToDataInfo(this HoSoCongViecResult entity)
        {
            return new HoSoCongViecInfo
            {
                Id = entity.Id,
                NgayHetHan = entity.NgayHetHan,
                NoiDung = entity.NoiDung,
                TrangThai = entity.TrangThaiCongViecInfo,
            };
        }

        public static HoSoCongViecInfo ToIfNotNullDataInfo(this HoSoCongViec entity)
        {
            return entity?.ToDataInfo();
        }

        public static HoSoCongViecInfo ToDataInfo(this HoSoCongViec entity)
        {
            return new HoSoCongViecInfo
            {
                Id = entity.Id,
                NgayHetHan = entity.NgayHetHan,
                TrangThai = entity.TrangThaiCongViec.ToIfNotNullDataInfo(),
                NoiDung = entity.NoiDung
            };
        }
    }

    public static class UserExtension
    {
        public static UserResult ToIfNotNullDataResult(this User entity)
        {
            return entity?.ToDataResult();
        }

        public static UserResult ToDataResult(this User entity)
        {
            return new UserResult
            {
                Id = entity.Id,
                HoVaTen = entity.HoVaTen,
                IsLocked = entity.IsLocked,
                UserName = entity.UserName,
                ChucVuId = entity.ChucVuId,
                ChucVuInfo = entity.ChucVu.ToDataInfo(),
                CoQuanId = entity.CoQuanId,
                CoQuanInfo = entity.CoQuan.ToDataInfo(),
                CreateDate = entity.CreateDate,
                CreatedBy = entity.CreatedBy,
                IsDeleted = entity.IsDeleted,
                LastUpdated = entity.LastUpdated,
                LastUpdatedBy = entity.LastUpdatedBy
            };
        }

        public static UserInfo ToIfNotNullDataInfo(this UserResult entity)
        {
            return entity?.ToDataInfo();
        }

        public static UserInfo ToDataInfo(this UserResult entity)
        {
            return new UserInfo
            {
                Id = entity.Id,
                UserName = entity.UserName,
                HoVaTen = entity.HoVaTen
            };
        }

        public static UserInfo ToIfNotNullDataInfo(this User entity)
        {
            return entity?.ToDataInfo();
        }

        public static UserInfo ToDataInfo(this User entity)
        {
            return new UserInfo
            {
                Id = entity.Id,
                UserName = entity.UserName,
                HoVaTen = entity.HoVaTen
            };
        }
    }

    public static class UserRoleExtension
    {
        public static UserRoleResult ToIfNotNullDataResult(this UserRole entity)
        {
            return entity?.ToDataResult();
        }

        public static UserRoleResult ToDataResult(this UserRole entity)
        {
            return new UserRoleResult
            {
                Id = entity.Id,
                UserId = entity.UserId,
                UserResult = entity.User.ToDataResult(),
                RoleId = entity.RoleId,
                RoleInfo = entity.Role.ToDataInfo(),
                CreateDate = entity.CreateDate,
                CreatedBy = entity.CreatedBy,
                IsDeleted = entity.IsDeleted,
                LastUpdated = entity.LastUpdated,
                LastUpdatedBy = entity.LastUpdatedBy
            };
        }

        public static UserRoleInfo ToIfNotNullDataInfo(this UserRole entity)
        {
            return entity?.ToDataInfo();
        }

        public static UserRoleInfo ToDataInfo(this UserRole entity)
        {
            return new UserRoleInfo
            {
                Id = entity.Id,
                UserInfo = entity.User.ToIfNotNullDataInfo(),
                RoleInfo = entity.Role.ToIfNotNullDataInfo()
            };
        }
    }

    public static class LinhVucVanBanExtension
    {
        public static LinhVucVanBanResult ToIfNotNullDataResult(this LinhVucVanBan entity)
        {
            return entity?.ToDataResult();
        }

        public static LinhVucVanBanResult ToDataResult(this LinhVucVanBan entity)
        {
            return new LinhVucVanBanResult
            {
                Id = entity.Id,
                Ten = entity.Ten,
                MoTa = entity.MoTa,
                CreateDate = entity.CreateDate,
                CreatedBy = entity.CreatedBy,
                IsDeleted = entity.IsDeleted,
                LastUpdated = entity.LastUpdated,
                LastUpdatedBy = entity.LastUpdatedBy
            };
        }

        public static LinhVucVanBanInfo ToIfNotNullDataInfo(this LinhVucVanBanResult entity)
        {
            return entity?.ToDataInfo();
        }

        public static LinhVucVanBanInfo ToDataInfo(this LinhVucVanBanResult entity)
        {
            return new LinhVucVanBanInfo
            {
                Id = entity.Id,
                Name = entity.Ten
            };
        }

        public static LinhVucVanBanInfo ToIfNotNullDataInfo(this LinhVucVanBan entity)
        {
            return entity?.ToDataInfo();
        }

        public static LinhVucVanBanInfo ToDataInfo(this LinhVucVanBan entity)
        {
            return new LinhVucVanBanInfo
            {
                Id = entity.Id,
                Name = entity.Ten
            };
        }
    }

    public static class LinhVucCongViecExtension
    {
        public static LinhVucCongViecResult ToIfNotNullDataResult(this LinhVucCongViec entity)
        {
            return entity?.ToDataResult();
        }

        public static LinhVucCongViecResult ToDataResult(this LinhVucCongViec entity)
        {
            return new LinhVucCongViecResult
            {
                Id = entity.Id,
                Ten = entity.Ten,
                MoTa = entity.MoTa,
                CreateDate = entity.CreateDate,
                CreatedBy = entity.CreatedBy,
                IsDeleted = entity.IsDeleted,
                LastUpdated = entity.LastUpdated,
                LastUpdatedBy = entity.LastUpdatedBy
            };
        }

        public static LinhVucCongViecInfo ToIfNotNullDataInfo(this LinhVucCongViecResult entity)
        {
            return entity?.ToDataInfo();
        }

        public static LinhVucCongViecInfo ToDataInfo(this LinhVucCongViecResult entity)
        {
            return new LinhVucCongViecInfo
            {
                Id = entity.Id,
                Name = entity.Ten
            };
        }

        public static LinhVucCongViecInfo ToIfNotNullDataInfo(this LinhVucCongViec entity)
        {
            return entity?.ToDataInfo();
        }

        public static LinhVucCongViecInfo ToDataInfo(this LinhVucCongViec entity)
        {
            return new LinhVucCongViecInfo
            {
                Id = entity.Id,
                Name = entity.Ten
            };
        }
    }

    public static class TrangThaiCongViecExtension
    {
        public static TrangThaiCongViecResult ToIfNotNullDataResult(this TrangThaiCongViec entity)
        {
            return entity?.ToDataResult();
        }

        public static TrangThaiCongViecResult ToDataResult(this TrangThaiCongViec entity)
        {
            return new TrangThaiCongViecResult
            {
                Id = entity.Id,
                Ten = entity.Ten,
                MoTa = entity.MoTa,
                CreateDate = entity.CreateDate,
                CreatedBy = entity.CreatedBy,
                IsDeleted = entity.IsDeleted,
                LastUpdated = entity.LastUpdated,
                LastUpdatedBy = entity.LastUpdatedBy
            };
        }

        public static TrangThaiCongViecInfo ToIfNotNullDataInfo(this TrangThaiCongViecResult entity)
        {
            return entity?.ToDataInfo();
        }

        public static TrangThaiCongViecInfo ToDataInfo(this TrangThaiCongViecResult entity)
        {
            return new TrangThaiCongViecInfo
            {
                Id = entity.Id,
                Name = entity.Ten
            };
        }

        public static TrangThaiCongViecInfo ToIfNotNullDataInfo(this TrangThaiCongViec entity)
        {
            return entity?.ToDataInfo();
        }

        public static TrangThaiCongViecInfo ToDataInfo(this TrangThaiCongViec entity)
        {
            return new TrangThaiCongViecInfo
            {
                Id = entity.Id,
                Name = entity.Ten
            };
        }
    }

    public static class LinhVucThuTucExtension
    {
        public static LinhVucThuTucResult ToIfNotNullDataResult(this LinhVucThuTuc entity)
        {
            return entity?.ToDataResult();
        }

        public static LinhVucThuTucResult ToDataResult(this LinhVucThuTuc entity)
        {
            return new LinhVucThuTucResult
            {
                Id = entity.Id,
                Ten = entity.Ten,
                MoTa = entity.MoTa,
                ParentId = entity.ParentId,
                CreateDate = entity.CreateDate,
                CreatedBy = entity.CreatedBy,
                IsDeleted = entity.IsDeleted,
                LastUpdated = entity.LastUpdated,
                LastUpdatedBy = entity.LastUpdatedBy
            };
        }

        public static LinhVucThuTucInfo ToIfNotNullDataInfo(this LinhVucThuTucResult entity)
        {
            return entity?.ToDataInfo();
        }

        public static LinhVucThuTucInfo ToDataInfo(this LinhVucThuTucResult entity)
        {
            return new LinhVucThuTucInfo
            {
                Id = entity.Id,
                Name = entity.Ten
            };
        }
    }

    public static class LinhVucTacNghiepExtension
    {
        public static LinhVucTacNghiepResult ToIfNotNullDataResult(this LinhVucTacNghiep entity)
        {
            return entity?.ToDataResult();
        }

        public static LinhVucTacNghiepResult ToDataResult(this LinhVucTacNghiep entity)
        {
            return new LinhVucTacNghiepResult
            {
                Id = entity.Id,
                Ten = entity.Ten,
                MoTa = entity.MoTa,
                CreateDate = entity.CreateDate,
                CreatedBy = entity.CreatedBy,
                IsDeleted = entity.IsDeleted,
                LastUpdated = entity.LastUpdated,
                LastUpdatedBy = entity.LastUpdatedBy
            };
        }

        public static LinhVucTacNghiepInfo ToIfNotNullDataInfo(this LinhVucTacNghiepResult entity)
        {
            return entity?.ToDataInfo();
        }

        public static LinhVucTacNghiepInfo ToDataInfo(this LinhVucTacNghiepResult entity)
        {
            return new LinhVucTacNghiepInfo
            {
                Id = entity.Id,
                Name = entity.Ten
            };
        }

        public static LinhVucTacNghiepInfo ToIfNotNullDataInfo(this LinhVucTacNghiep entity)
        {
            return entity?.ToDataInfo();
        }

        public static LinhVucTacNghiepInfo ToDataInfo(this LinhVucTacNghiep entity)
        {
            return new LinhVucTacNghiepInfo
            {
                Id = entity.Id,
                Name = entity.Ten
            };
        }
    }

    public static class LoaiVanBanExtension
    {
        public static LoaiVanBanResult ToIfNotNullDataResult(this LoaiVanBan entity)
        {
            return entity?.ToDataResult();
        }

        public static LoaiVanBanResult ToDataResult(this LoaiVanBan entity)
        {
            return new LoaiVanBanResult
            {
                Id = entity.Id,
                Ten = entity.Ten,
                MoTa = entity.MoTa,
                CreateDate = entity.CreateDate,
                CreatedBy = entity.CreatedBy,
                IsDeleted = entity.IsDeleted,
                LastUpdated = entity.LastUpdated,
                LastUpdatedBy = entity.LastUpdatedBy
            };
        }

        public static LoaiVanBanInfo ToIfNotNullDataInfo(this LoaiVanBanResult entity)
        {
            return entity?.ToDataInfo();
        }

        public static LoaiVanBanInfo ToDataInfo(this LoaiVanBanResult entity)
        {
            return new LoaiVanBanInfo
            {
                Id = entity.Id,
                Name = entity.Ten
            };
        }

        public static LoaiVanBanInfo ToIfNotNullDataInfo(this LoaiVanBan entity)
        {
            return entity?.ToDataInfo();
        }

        public static LoaiVanBanInfo ToDataInfo(this LoaiVanBan entity)
        {
            return new LoaiVanBanInfo
            {
                Id = entity.Id,
                Name = entity.Ten
            };
        }
    }

    public static class MucDoHoanThanhExtension
    {
        public static MucDoHoanThanhResult ToIfNotNullDataResult(this MucDoHoanThanh entity)
        {
            return entity?.ToDataResult();
        }

        public static MucDoHoanThanhResult ToDataResult(this MucDoHoanThanh entity)
        {
            return new MucDoHoanThanhResult
            {
                Id = entity.Id,
                Ten = entity.Ten,
                MoTa = entity.MoTa,
                CreateDate = entity.CreateDate,
                CreatedBy = entity.CreatedBy,
                IsDeleted = entity.IsDeleted,
                LastUpdated = entity.LastUpdated,
                LastUpdatedBy = entity.LastUpdatedBy
            };
        }
    }

    public static class MucTinExtension
    {
        public static MucTinResult ToIfNotNullDataResult(this MucTin entity)
        {
            return entity?.ToDataResult();
        }

        public static MucTinResult ToDataResult(this MucTin entity)
        {
            return new MucTinResult
            {
                Id = entity.Id,
                Ten = entity.Ten,
                MoTa = entity.MoTa,
                CreateDate = entity.CreateDate,
                CreatedBy = entity.CreatedBy,
                IsDeleted = entity.IsDeleted,
                LastUpdated = entity.LastUpdated,
                LastUpdatedBy = entity.LastUpdatedBy
            };
        }
    }

    public static class NhomCoQuanExtension
    {
        public static NhomCoQuanResult ToIfNotNullDataResult(this NhomCoQuan entity)
        {
            return entity?.ToDataResult();
        }

        public static NhomCoQuanResult ToDataResult(this NhomCoQuan entity)
        {
            return new NhomCoQuanResult
            {
                Id = entity.Id,
                Ten = entity.Ten,
                MoTa = entity.MoTa,
                CoQuanResult = entity.CoQuans.Select(x => x.ToIfNotNullDataResult()),
                CreateDate = entity.CreateDate,
                CreatedBy = entity.CreatedBy,
                IsDeleted = entity.IsDeleted,
                LastUpdated = entity.LastUpdated,
                LastUpdatedBy = entity.LastUpdatedBy
            };
        }

        public static NhomCoQuanInfo ToIfNotNullDataInfo(this NhomCoQuanResult entity)
        {
            return entity?.ToDataInfo();
        }

        public static NhomCoQuanInfo ToDataInfo(this NhomCoQuanResult entity)
        {
            return new NhomCoQuanInfo
            {
                Id = entity.Id,
                Name = entity.Ten
            };
        }
    }

    public static class CoQuanBanHanhVanBanExtension
    {
        public static CoQuanBanHanhVanBanResult ToIfNotNullDataResult(this CoQuanBanHanhVanBan entity)
        {
            return entity?.ToDataResult();
        }

        public static CoQuanBanHanhVanBanResult ToDataResult(this CoQuanBanHanhVanBan entity)
        {
            return new CoQuanBanHanhVanBanResult
            {
                Id = entity.Id,
                Ten = entity.Ten,
                MoTa = entity.MoTa,
                CreateDate = entity.CreateDate,
                CreatedBy = entity.CreatedBy,
                IsDeleted = entity.IsDeleted,
                LastUpdated = entity.LastUpdated,
                LastUpdatedBy = entity.LastUpdatedBy
            };
        }

        public static CoQuanBanHanhVanBanInfo ToIfNotNullDataInfo(this CoQuanBanHanhVanBanResult entity)
        {
            return entity?.ToDataInfo();
        }

        public static CoQuanBanHanhVanBanInfo ToDataInfo(this CoQuanBanHanhVanBanResult entity)
        {
            return new CoQuanBanHanhVanBanInfo
            {
                Id = entity.Id,
                Name = entity.Ten
            };
        }

        public static CoQuanBanHanhVanBanInfo ToIfNotNullDataInfo(this CoQuanBanHanhVanBan entity)
        {
            return entity?.ToDataInfo();
        }

        public static CoQuanBanHanhVanBanInfo ToDataInfo(this CoQuanBanHanhVanBan entity)
        {
            return new CoQuanBanHanhVanBanInfo
            {
                Id = entity.Id,
                Name = entity.Ten
            };
        }
    }

    public static class RoleExtension
    {
        public static RoleResult ToIfNotNullDataResult(this Role entity)
        {
            return entity?.ToDataResult();
        }

        public static RoleResult ToDataResult(this Role entity)
        {
            return new RoleResult
            {
                Id = entity.Id,
                Ten = entity.Name,
                Display = entity.Display,
                MoTa = entity.Description,
                CreateDate = entity.CreateDate,
                CreatedBy = entity.CreatedBy,
                IsDeleted = entity.IsDeleted,
                LastUpdated = entity.LastUpdated,
                LastUpdatedBy = entity.LastUpdatedBy
            };
        }

        public static RoleInfo ToIfNotNullDataInfo(this RoleResult entity)
        {
            return entity?.ToDataInfo();
        }

        public static RoleInfo ToDataInfo(this RoleResult entity)
        {
            return new RoleInfo
            {
                Id = entity.Id,
                Name = entity.Ten
            };
        }

        public static RoleInfo ToIfNotNullDataInfo(this Role entity)
        {
            return entity?.ToDataInfo();
        }

        public static RoleInfo ToDataInfo(this Role entity)
        {
            return new RoleInfo
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }
    }

    public static class TacNghiepExtension
    {
        public static TacNghiepResult ToIfNotNullDataResult(this TacNghiep entity)
        {
            return entity?.ToDataResult();
        }

        public static TacNghiepResult ToDataResult(this TacNghiep entity)
        {
            return new TacNghiepResult
            {
                Id = entity.Id,
                LinhVucTacNghiepId = entity.LinhVucTacNghiepId,
                LinhVucTacNghiepInfo = entity.LinhVucTacNghiep.ToIfNotNullDataInfo(),
                NgayHetHan = entity.NgayHetHan,
                NgayHoanThanh = entity.NgayHoanThanh,
                NgayTao = entity.NgayTao,
                NoiDung = entity.NoiDung,
                NoiDungTraoDoi = entity.NoiDungTraoDoi,
                MucDoHoanThanhId = entity.MucDoHoanThanhId,
                CoQuanInfos = entity.TacNghiep_TinhHinhThucHien.Select(x => new CoQuanInfo { Id = x.CoQuanId, Name = x.CoQuan.Ten, NhomCoQuanId = x.CoQuan.NhomCoQuanId, MucDoHoanThanhId = x.MucDoHoanThanhId }).ToList(),
                CreateDate = entity.CreateDate,
                CreatedBy = entity.CreatedBy,
                IsDeleted = entity.IsDeleted,
                LastUpdated = entity.LastUpdated,
                LastUpdatedBy = entity.LastUpdatedBy
            };
        }

        public static TacNghiepInfo ToIfNotNullDataInfo(this TacNghiepResult entity)
        {
            return entity?.ToDataInfo();
        }

        public static TacNghiepInfo ToDataInfo(this TacNghiepResult entity)
        {
            return new TacNghiepInfo
            {
                Id = entity.Id,
                NoiDung = entity.NoiDung,
                NgayTao = entity.NgayTao,
                NgayHoanThanh = entity.NgayHoanThanh,
                NgayHetHan = entity.NgayHetHan,
                LinhVucTacNghiepInfo = entity.LinhVucTacNghiepInfo
            };
        }

        public static TacNghiepInfo ToIfNotNullDataInfo(this TacNghiep entity)
        {
            return entity?.ToDataInfo();
        }

        public static TacNghiepInfo ToDataInfo(this TacNghiep entity)
        {
            return new TacNghiepInfo
            {
                Id = entity.Id,
                NoiDung = entity.NoiDung,
                NgayTao = entity.NgayTao,
                NgayHoanThanh = entity.NgayHoanThanh,
                NgayHetHan = entity.NgayHetHan,
                LinhVucTacNghiepInfo = entity.LinhVucTacNghiep.ToIfNotNullDataInfo(),
            };
        }
    }

    public static class TacNghiepTinhHinhThucHienExtension
    {
        public static TacNghiepTinhHinhThucHienResult ToIfNotNullDataResult(this TacNghiep_TinhHinhThucHien entity)
        {
            return entity?.ToDataResult();
        }

        public static TacNghiepTinhHinhThucHienResult ToDataResult(this TacNghiep_TinhHinhThucHien entity)
        {
            return new TacNghiepTinhHinhThucHienResult
            {
                Id = entity.Id,
                MucDoHoanThanhId = entity.MucDoHoanThanhId,
                NgayHoanThanh = entity.NgayHoanThanh,
                MucDoHoanThanhInfo = entity.MucDoHoanThanh.ToIfNotNullDataResult(),
                ThoiGian = entity.ThoiGian,
                CoQuanId = entity.CoQuanId,
                CoQuanInfo = entity.CoQuan.ToDataInfo(),
                TacNghiepId = entity.TacNghiepId,
                TacNghiepInfo = entity.TacNghiep.ToDataInfo(),
                IsDaHoanThanh = (entity.MucDoHoanThanhId == (int)EnumMucDoHoanThanh.DAHOANHTHANH && entity.NgayHoanThanh.HasValue),
                CreateDate = entity.CreateDate,
                CreatedBy = entity.CreatedBy,
                IsDeleted = entity.IsDeleted,
                LastUpdated = entity.LastUpdated,
                LastUpdatedBy = entity.LastUpdatedBy
            };
        }
    }

    public static class TacNghiepYKienCoQuanExtension
    {
        public static TacNghiepYKienCoQuanResult ToIfNotNullDataResult(this TacNghiep_YKienCoQuan entity)
        {
            return entity?.ToDataResult();
        }

        public static TacNghiepYKienCoQuanResult ToDataResult(this TacNghiep_YKienCoQuan entity)
        {
            return new TacNghiepYKienCoQuanResult
            {
                Id = entity.Id,
                NoiDung = entity.NoiDung,
                NoiDungTraLoi = entity.NoiDungTraLoi,
                UserIdTraLoi = entity.UserIdTraLoi,
                CoQuanId = entity.CoQuanId,
                CoQuanInfo = entity.CoQuan.ToDataInfo(),
                TacNghiepId = entity.TacNghiepId,
                TacNghiepInfo = entity.TacNghiep.ToDataInfo(),
                CreateDate = entity.CreateDate,
                CreatedBy = entity.CreatedBy,
                IsDeleted = entity.IsDeleted,
                LastUpdated = entity.LastUpdated,
                LastUpdatedBy = entity.LastUpdatedBy
            };
        }

        public static YKienCoQuanInfo ToIfNotNullDataInfo(this TacNghiep_YKienCoQuan entity)
        {
            return entity?.ToDataInfo();
        }

        public static YKienCoQuanInfo ToDataInfo(this TacNghiep_YKienCoQuan entity)
        {
            return new YKienCoQuanInfo
            {
                Id = entity.Id,
                CoQuanId = entity.CoQuanId,
                TacNghiepId = entity.TacNghiepId,
            };
        }
    }

    public static class TapTinYKienCoQuanExtension
    {
        public static TapTinYKienCoQuanResult ToIfNotNullDataResult(this TapTinYKienCoQuan entity)
        {
            return entity?.ToDataResult();
        }

        public static TapTinYKienCoQuanResult ToDataResult(this TapTinYKienCoQuan entity)
        {
            return new TapTinYKienCoQuanResult
            {
                Id = entity.Id,
                YKienCoQuanId = entity.YKiencoQuanTacNghiepId,
                YKienCoQuanInfo = entity.TacNghiep_YKienCoQuan.ToDataInfo(),
                Url = entity.Url,
                UserUploadId = entity.UserUploadId,
                UserInfo = entity.User.ToIfNotNullDataInfo(),
                CreateDate = entity.CreateDate,
                CreatedBy = entity.CreatedBy,
                IsDeleted = entity.IsDeleted,
                LastUpdated = entity.LastUpdated,
                LastUpdatedBy = entity.LastUpdatedBy
            };
        }
    }

    public static class TapTinCongViecExtension
    {
        public static TapTinCongViecResult ToIfNotNullDataResult(this TapTinCongViec entity)
        {
            return entity?.ToDataResult();
        }

        public static TapTinCongViecResult ToDataResult(this TapTinCongViec entity)
        {
            return new TapTinCongViecResult
            {
                Id = entity.Id,
                HoSoCongViecId = entity.HoSoCongViecId,
                HoSoCongViecInfo = entity.HoSoCongViec.ToIfNotNullDataInfo(),
                Url = entity.Url,
                UserUploadId = entity.UserUploadId,
                UserInfo = entity.User.ToIfNotNullDataInfo(),
                CreateDate = entity.CreateDate,
                CreatedBy = entity.CreatedBy,
                IsDeleted = entity.IsDeleted,
                LastUpdated = entity.LastUpdated,
                LastUpdatedBy = entity.LastUpdatedBy
            };
        }
    }

    public static class TapTinTacNghiepExtension
    {
        public static TapTinTacNghiepResult ToIfNotNullDataResult(this TapTinTacNghiep entity)
        {
            return entity?.ToDataResult();
        }

        public static TapTinTacNghiepResult ToDataResult(this TapTinTacNghiep entity)
        {
            return new TapTinTacNghiepResult
            {
                Id = entity.Id,
                TacNghiepId = entity.TacNghiepId,
                TacNghiepInfo = entity.TacNghiep.ToIfNotNullDataInfo(),
                Url = entity.Url,
                UserUploadId = entity.UserUploadId,
                UserInfo = entity.User.ToIfNotNullDataInfo(),
                CreateDate = entity.CreateDate,
                CreatedBy = entity.CreatedBy,
                IsDeleted = entity.IsDeleted,
                LastUpdated = entity.LastUpdated,
                LastUpdatedBy = entity.LastUpdatedBy
            };
        }
    }

    public static class TapTinThuTucExtension
    {
        public static TapTinThuTucResult ToIfNotNullDataResult(this TapTinThuTuc entity)
        {
            return entity?.ToDataResult();
        }

        public static TapTinThuTucResult ToDataResult(this TapTinThuTuc entity)
        {
            return new TapTinThuTucResult
            {
                Id = entity.Id,
                ThuTucId = entity.ThuTucId,
                ThuTucInfo = entity.ThuTuc.ToDataInfo(),
                Url = entity.Url,
                FileName = System.IO.Path.GetFileName(entity.Url),
                Path = System.IO.Path.GetDirectoryName(entity.Url),
                UserUploadId = entity.UserUploadId,
                UserInfo = entity.User.ToDataInfo(),
                CreateDate = entity.CreateDate,
                CreatedBy = entity.CreatedBy,
                IsDeleted = entity.IsDeleted,
                LastUpdated = entity.LastUpdated,
                LastUpdatedBy = entity.LastUpdatedBy
            };
        }
    }

    public static class ThuTucExtension
    {
        public static ThuTucResult ToIfNotNullDataResult(this ThuTuc entity)
        {
            return entity?.ToDataResult();
        }

        public static ThuTucResult ToDataResult(this ThuTuc entity)
        {
            return new ThuTucResult
            {
                Id = entity.Id,
                CoQuanThucHienIds = entity.ThuTuc_CoQuanThucHien.Select(x => x.CoQuanId).ToArray(),
                CoQuanInfos = entity.ThuTuc_CoQuanThucHien.Select(x => x.CoQuan.ToDataInfo()).ToList(),
                LoaiThuTucId = entity.LoaiThuTucId,
                LinhVucThuTucInfo = entity.LinhVucThuTuc.ToIfNotNullDataResult().ToDataInfo(),
                NoiDung = entity.NoiDung,
                NgayBanHanh = entity.NgayBanHanh,
                TenThuTuc = entity.TenThuTuc,
                Files = entity.TapTinThuTucs.Select(x => x.ToDataResult()).ToList(),
                CreateDate = entity.CreateDate,
                CreatedBy = entity.CreatedBy,
                IsDeleted = entity.IsDeleted,
                LastUpdated = entity.LastUpdated,
                LastUpdatedBy = entity.LastUpdatedBy
            };
        }

        public static ThuTucInfo ToIfNotNullDataInfo(this ThuTucResult entity)
        {
            return entity?.ToDataInfo();
        }

        public static ThuTucInfo ToDataInfo(this ThuTucResult entity)
        {
            return new ThuTucInfo
            {
                Id = entity.Id,
                MaThuTuc = entity.NoiDung,
                TenThuTuc = entity.TenThuTuc,
                NgayBanHanh = entity.NgayBanHanh
            };
        }

        public static ThuTucInfo ToIfNotNullDataInfo(this ThuTuc entity)
        {
            return entity?.ToDataInfo();
        }

        public static ThuTucInfo ToDataInfo(this ThuTuc entity)
        {
            return new ThuTucInfo
            {
                Id = entity.Id,
                MaThuTuc = entity.NoiDung,
                TenThuTuc = entity.TenThuTuc,
                NgayBanHanh = entity.NgayBanHanh
            };
        }
    }

    public static class NewsExtension
    {
        public static NewsCategoryResult ToDataResult(this NewsCategory news)
        {
            return news == null ? null : new NewsCategoryResult
            {
                Id = news.Id,
                CreateDate = news.CreateDate,
                CreatedBy = news.CreatedBy,
                IsDeleted = news.IsDeleted,
                LastUpdated = news.LastUpdated,
                LastUpdatedBy = news.LastUpdatedBy,
                MoTa = news.MoTa,
                Ten = news.Title,
            };
        }

        public static NewsResult ToIfNotNullDataResult(this News news)
        {
            return news?.ToDataResult();
        }
        public static NewsResult ToDataResult(this News news)
        {
            return news == null ? null : new NewsResult
            {
                Id = news.Id,
                CreateDate = news.CreateDate,
                CreatedBy = news.CreatedBy,
                IsDeleted = news.IsDeleted,
                LastUpdated = news.LastUpdated,
                LastUpdatedBy = news.LastUpdatedBy,
                Content = news.Content,
                Summary = news.Summary,
                NewsCategoryId = news.NewsCategoryId,
                Title = news.Title,
                UrlImage = news.UrlImage,
                NewsCategory = news.NewsCategory.ToDataResult(),
            };
        }

        public static NewsCategoryInfo ToIfNotNullDataInfo(this NewsCategory entity)
        {
            return entity?.ToDataInfo();
        }

        public static NewsCategoryInfo ToDataInfo(this NewsCategory entity)
        {
            return new NewsCategoryInfo
            {
                Id = entity.Id,
                Name = entity.Title,
            };
        }
    }
}