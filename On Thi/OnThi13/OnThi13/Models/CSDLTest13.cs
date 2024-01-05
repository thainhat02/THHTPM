using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace OnThi13.Models
{
    public partial class CSDLTest13 : DbContext
    {
        public CSDLTest13()
            : base("name=CSDLTest13")
        {
        }

        public virtual DbSet<NhanVien> NhanViens { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NhanVien>()
                .Property(e => e.Ma)
                .IsFixedLength();
        }
    }
}
