namespace Bai9._1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DanhMuc")]
    public partial class DanhMuc
    {
        [Key]
        public int MaDanhMuc { get; set; }

        [StringLength(50)]
        public string TenDanhMuc { get; set; }
        public virtual ICollection<SanPham> sanPhams { get; set; }
    }
}
