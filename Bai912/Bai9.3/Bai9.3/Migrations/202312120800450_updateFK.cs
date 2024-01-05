namespace Bai9._3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateFK : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DonVi",
                c => new
                    {
                        MaDonVi = c.String(nullable: false, maxLength: 10, fixedLength: true),
                        TenDonVi = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.MaDonVi);
            
            CreateTable(
                "dbo.NhanVien",
                c => new
                    {
                        Ma = c.String(nullable: false, maxLength: 10, fixedLength: true),
                        HoTen = c.String(maxLength: 50),
                        NgaySinh = c.DateTime(storeType: "date"),
                        GioiTinh = c.String(maxLength: 10, fixedLength: true),
                        HsLuong = c.Int(),
                        MaDonVi = c.String(nullable: false, maxLength: 10, fixedLength: true),
                    })
                .PrimaryKey(t => t.Ma)
                .ForeignKey("dbo.DonVi", t => t.MaDonVi, cascadeDelete: true)
                .Index(t => t.MaDonVi);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NhanVien", "MaDonVi", "dbo.DonVi");
            DropIndex("dbo.NhanVien", new[] { "MaDonVi" });
            DropTable("dbo.NhanVien");
            DropTable("dbo.DonVi");
        }
    }
}
