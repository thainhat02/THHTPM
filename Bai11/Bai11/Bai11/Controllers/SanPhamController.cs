using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bai11.Controllers
{
    public class SanPhamController : ApiController
    {
        CSDLTestDataContext context = new CSDLTestDataContext();
        [HttpGet]
        public List<SanPham> LayALL()
        {
            List<SanPham> li = context.SanPhams.ToList();
            return li;
        }
        [HttpGet]
        public SanPham Chitiet(int id)
        {
            SanPham sp = context.SanPhams.First(x => x.MaSP == id);
            return sp;
        }
        [HttpPost]
        public bool add(int masp, string tensp, int dongia, int madanhmuc)
        {
            SanPham sp = context.SanPhams.FirstOrDefault(x => x.MaSP == masp);
            if (sp == null)
            {
                SanPham sanPham = new SanPham();
                sanPham.MaSP = masp;
                sanPham.TenSP = tensp;
                sanPham.DonGia = dongia;
                sanPham.MaDanhMuc = madanhmuc;
                context.SanPhams.InsertOnSubmit(sanPham);
                context.SubmitChanges();
                return true;
            }
            return false;
        }
        [HttpPut]
        public bool update(int masp, string tensp, int dongia, int madanhmuc)
        {
            SanPham sp = context.SanPhams.FirstOrDefault(x => x.MaSP == masp);
            if (sp != null)
            {

                sp.TenSP = tensp;
                sp.DonGia = dongia;
                sp.MaDanhMuc = madanhmuc;
                context.SubmitChanges();
                return true;
            }
            return false;
        }
        [HttpDelete]
        public bool delete(int masp)
        {
            SanPham sp = context.SanPhams.FirstOrDefault(x => x.MaSP == masp);
            if (sp != null)
            {

                context.SanPhams.DeleteOnSubmit(sp);
                context.SubmitChanges();
                return true;
            }
            return false;
        }
    }
}
