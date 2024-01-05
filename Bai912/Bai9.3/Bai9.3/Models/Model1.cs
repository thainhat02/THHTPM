using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Bai9._3.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<DonVi> DonVis { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DonVi>()
                .Property(e => e.MaDonVi)
                .IsFixedLength();

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.Ma)
                .IsFixedLength();

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.GioiTinh)
                .IsFixedLength();

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.MaDonVi)
                .IsFixedLength();

        }
    }
}
