//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLDT.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            this.ChiTietDHs = new HashSet<ChiTietDH>();
        }
    
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public string MoTa { get; set; }
        public Nullable<decimal> GiaTien { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public string AnhBia { get; set; }
        public Nullable<int> MaHSX { get; set; }
        public Nullable<int> MaHDH { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDH> ChiTietDHs { get; set; }
        public virtual HangSanXuat HangSanXuat { get; set; }
        public virtual HeDieuHanh HeDieuHanh { get; set; }
    }
}
