using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OnThi7.Models;

namespace OnThi7.Controllers
{
    public class SanPhamController : ApiController
    {
        CSDLTest7Entities db = new CSDLTest7Entities();
        [HttpGet]
        public List<SanPham> LayALL()
        {
            List<SanPham> li = db.SanPhams.ToList();
            return li;
        }
        [HttpGet]
        public List<SanPham> FindName(string ten)
        {
            List<SanPham> li = db.SanPhams.Where(x => x.TenSP == ten).ToList();
            return li;
        }
        [HttpPost]
        public bool Add(int ma, string ten, int dongia, int soluong)
        {
            try
            {
                SanPham sp = new SanPham();
                sp.MaSP = ma;
                sp.TenSP = ten;
                sp.DonGia = dongia;
                sp.SoLuong = soluong;
                db.SanPhams.Add(sp);
                db.SaveChanges();
                return true;
            }
            catch{ }
            return false;
            
        }
        [HttpPut]
        public bool Update(int ma, string ten, int dongia, int soluong)
        {
            
            try
            {
                SanPham sp = db.SanPhams.FirstOrDefault(x => x.MaSP == ma);
                if (sp != null)
                {
                    sp.TenSP = ten;
                    sp.DonGia = dongia;
                    sp.SoLuong = soluong;
                    db.SaveChanges();
                    return true;
                }
            }
            catch { }
            return false;
            
        }
        [HttpDelete]
        public bool Delete(int ma)
        {
            SanPham sp = db.SanPhams.FirstOrDefault(x => x.MaSP == ma);
            if (sp != null)
            {
                db.SanPhams.Remove(sp);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
