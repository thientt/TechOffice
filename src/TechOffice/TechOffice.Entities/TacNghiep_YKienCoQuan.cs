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
    
    public partial class TacNghiep_YKienCoQuan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TacNghiep_YKienCoQuan()
        {
            this.TapTinYKienCoQuans = new HashSet<TapTinYKienCoQuan>();
        }
    
        public int Id { get; set; }
        public int TacNghiepId { get; set; }
        public int CoQuanId { get; set; }
        public string NoiDung { get; set; }
        public bool IsDeleted { get; set; }
        public System.DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> LastUpdated { get; set; }
        public string LastUpdatedBy { get; set; }
        public string NoiDungTraLoi { get; set; }
        public Nullable<int> UserIdTraLoi { get; set; }
    
        public virtual CoQuan CoQuan { get; set; }
        public virtual TacNghiep TacNghiep { get; set; }
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TapTinYKienCoQuan> TapTinYKienCoQuans { get; set; }
    }
}
