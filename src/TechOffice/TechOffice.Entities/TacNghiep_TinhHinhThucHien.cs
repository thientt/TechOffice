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
    
    public partial class TacNghiep_TinhHinhThucHien
    {
        public int Id { get; set; }
        public int TacNghiepId { get; set; }
        public int CoQuanId { get; set; }
        public int ThoiGian { get; set; }
        public string MucDoHoanThanh { get; set; }
        public bool IsDeleted { get; set; }
        public System.DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> LastUpdated { get; set; }
        public string LastUpdatedBy { get; set; }
    
        public virtual CoQuan CoQuan { get; set; }
        public virtual TacNghiep TacNghiep { get; set; }
    }
}
