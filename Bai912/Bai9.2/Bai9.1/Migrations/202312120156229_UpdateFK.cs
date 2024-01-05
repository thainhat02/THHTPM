namespace Bai9._1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateFK : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DanhMuc",
                c => new
                    {
                        MaDanhMuc = c.Int(nullable: false, identity: true),
                        TenDanhMuc = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.MaDanhMuc);
            
            CreateTable(
                "dbo.SanPham",
                c => new
                    {
                        MaSP = c.Int(nullable: false, identity: true),
                        TenSP = c.String(maxLength: 50),
                        DonGia = c.Int(),
                        MaDanhMuc = c.Int(),
                    })
                .PrimaryKey(t => t.MaSP)
                .ForeignKey("dbo.DanhMuc", t => t.MaDanhMuc)
                .Index(t => t.MaDanhMuc);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SanPham", "MaDanhMuc", "dbo.DanhMuc");
            DropIndex("dbo.SanPham", new[] { "MaDanhMuc" });
            DropTable("dbo.SanPham");
            DropTable("dbo.DanhMuc");
        }
    }
}
