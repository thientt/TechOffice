//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            this.CongViec_PhoiHop = new HashSet<CongViec_PhoiHop>();
            this.HoSoCongViecs = new HashSet<HoSoCongViec>();
            this.HoSoCongViecs1 = new HashSet<HoSoCongViec>();
            this.TapTinCongViecs = new HashSet<TapTinCongViec>();
            this.TapTinTacNghieps = new HashSet<TapTinTacNghiep>();
            this.TapTinThuTucs = new HashSet<TapTinThuTuc>();
            this.TapTinVanBans = new HashSet<TapTinVanBan>();
            this.TapTinYKienCoQuans = new HashSet<TapTinYKienCoQuan>();
            this.UserRoles = new HashSet<UserRole>();
            this.TacNghiep_YKienCoQuan = new HashSet<TacNghiep_YKienCoQuan>();
        }
    
        public int Id { get; set; }
        public string HoVaTen { get; set; }
        public string UserName { get; set; }
        public int ChucVuId { get; set; }
        public string Password { get; set; }
        public bool IsLocked { get; set; }
        public bool IsDeleted { get; set; }
        public System.DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> LastUpdated { get; set; }
        public string LastUpdatedBy { get; set; }
        public int CoQuanId { get; set; }
    
        public virtual ChucVu ChucVu { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CongViec_PhoiHop> CongViec_PhoiHop { get; set; }
        public virtual CoQuan CoQuan { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoSoCongViec> HoSoCongViecs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoSoCongViec> HoSoCongViecs1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TapTinCongViec> TapTinCongViecs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TapTinTacNghiep> TapTinTacNghieps { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TapTinThuTuc> TapTinThuTucs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TapTinVanBan> TapTinVanBans { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TapTinYKienCoQuan> TapTinYKienCoQuans { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserRole> UserRoles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TacNghiep_YKienCoQuan> TacNghiep_YKienCoQuan { get; set; }
    }
}
