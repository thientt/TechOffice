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
    
    public partial class DanhMucBaiViet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DanhMucBaiViet()
        {
            this.BaiViets = new HashSet<BaiViet>();
        }
    
        public int MaDanhMuc { get; set; }
        public int IdParent { get; set; }
        public string TenDanhMuc { get; set; }
        public string MoTa { get; set; }
        public string HinhAnh { get; set; }
        public string Meta_TieuDe { get; set; }
        public string Meta_TuKhoa { get; set; }
        public string Meta_MoTa { get; set; }
        public System.DateTime NgayTao { get; set; }
        public System.DateTime NgayCapNhat { get; set; }
        public string Url { get; set; }
        public bool TrangThai { get; set; }
        public string NoiDung { get; set; }
        public bool HienThiTrangChu { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaiViet> BaiViets { get; set; }
    }
}
