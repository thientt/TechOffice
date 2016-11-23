﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AnThinhPhat.Entities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class TechOfficeEntities : DbContext
    {
        public TechOfficeEntities()
            : base("name=TechOfficeEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ChucVu> ChucVus { get; set; }
        public virtual DbSet<CongViec_PhoiHop> CongViec_PhoiHop { get; set; }
        public virtual DbSet<CongViec_QuaTrinhXuLy> CongViec_QuaTrinhXuLy { get; set; }
        public virtual DbSet<CoQuan> CoQuans { get; set; }
        public virtual DbSet<LinhVucCongViec> LinhVucCongViecs { get; set; }
        public virtual DbSet<LinhVucTacNghiep> LinhVucTacNghieps { get; set; }
        public virtual DbSet<LinhVucThuTuc> LinhVucThuTucs { get; set; }
        public virtual DbSet<LinhVucVanBan> LinhVucVanBans { get; set; }
        public virtual DbSet<LoaiVanBan> LoaiVanBans { get; set; }
        public virtual DbSet<MucDoHoanThanh> MucDoHoanThanhs { get; set; }
        public virtual DbSet<MucTin> MucTins { get; set; }
        public virtual DbSet<NhomCoQuan> NhomCoQuans { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<TacNghiep> TacNghieps { get; set; }
        public virtual DbSet<TacNghiep_TinhHinhThucHien> TacNghiep_TinhHinhThucHien { get; set; }
        public virtual DbSet<TacNghiep_YKienCoQuan> TacNghiep_YKienCoQuan { get; set; }
        public virtual DbSet<TapTinCongViec> TapTinCongViecs { get; set; }
        public virtual DbSet<TapTinTacNghiep> TapTinTacNghieps { get; set; }
        public virtual DbSet<TapTinThuTuc> TapTinThuTucs { get; set; }
        public virtual DbSet<TapTinVanBan> TapTinVanBans { get; set; }
        public virtual DbSet<TapTinYKienCoQuan> TapTinYKienCoQuans { get; set; }
        public virtual DbSet<ThuTuc> ThuTucs { get; set; }
        public virtual DbSet<TrangThaiCongViec> TrangThaiCongViecs { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<VanBan> VanBans { get; set; }
        public virtual DbSet<CongViec_VanBan> CongViec_VanBan { get; set; }
        public virtual DbSet<HoSoCongViec> HoSoCongViecs { get; set; }
    
        public virtual ObjectResult<Statictis_Result> Statictis(Nullable<int> noiVuId, Nullable<System.DateTime> from, Nullable<System.DateTime> to)
        {
            var noiVuIdParameter = noiVuId.HasValue ?
                new ObjectParameter("NoiVuId", noiVuId) :
                new ObjectParameter("NoiVuId", typeof(int));
    
            var fromParameter = from.HasValue ?
                new ObjectParameter("From", from) :
                new ObjectParameter("From", typeof(System.DateTime));
    
            var toParameter = to.HasValue ?
                new ObjectParameter("To", to) :
                new ObjectParameter("To", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Statictis_Result>("Statictis", noiVuIdParameter, fromParameter, toParameter);
        }
    }
}
