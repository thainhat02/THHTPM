namespace OnThi13.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanVien")]
    public partial class NhanVien
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        [StringLength(10)]
        public string Ma { get; set; }

        [StringLength(50)]
        public string Ten { get; set; }

        public DateTime? NgaySinh { get; set; }

        [StringLength(50)]
        public string GioiTinh { get; set; }

        public int? HeSoLuong { get; set; }
    }
}
