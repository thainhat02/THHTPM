namespace Bai9._1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [Key]
        public int MaSP { get; set; }

        [StringLength(50)]
        public string TenSP { get; set; }

        public int? DonGia { get; set; }

        public int? MaDanhMuc { get; set; }
        public virtual DanhMuc DanhMuc { get; set; }
    }
}
