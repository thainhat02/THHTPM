namespace Bai9._3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonVi")]
    public partial class DonVi
    {
        [Key]
        [StringLength(10)]
        public string MaDonVi { get; set; }

        [StringLength(50)]
        public string TenDonVi { get; set; }
        public virtual ICollection<NhanVien> NhanViens { get; set; }
    }
}
