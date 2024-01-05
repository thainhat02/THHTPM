using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bai122.Models;

namespace Bai122.Controllers
{
    public class NhanVienController : ApiController
    {
        QLLuongEntities db = new QLLuongEntities();
        [HttpGet]
        public List<NhanVien> LayALL()
        {
            List<NhanVien> li = db.NhanViens.ToList();
            return li;
        }
        [HttpPost]
        public bool Add(string ma, string ten, DateTime ngaysinh, int hsl, string madv)
        {
            NhanVien nv = db.NhanViens.FirstOrDefault(x => x.Ma == ma);
            if (nv == null)
            {
                NhanVien d = new NhanVien();
                d.Ma = ma;
                d.HoTen = ten;
                d.NgaySinh = ngaysinh;
                d.HsLuong = hsl;
                d.MaDonVi = madv;
                db.NhanViens.Add(d);
                db.SaveChanges();
                return true;
            }
            return false;
        }
        [HttpPut]
        public bool Update(string ma, string ten, DateTime ngaysinh, int hsl, string madv)
        {
            NhanVien d = db.NhanViens.FirstOrDefault(x => x.Ma == ma);
            if (d != null)
            {
                d.HoTen = ten;
                d.NgaySinh = ngaysinh;
                d.HsLuong = hsl;
                d.MaDonVi = madv;
                db.SaveChanges();
                return true;
            }
            return false;
        }
        [HttpDelete]
        public bool Delete(string ma)
        {
            NhanVien dv = db.NhanViens.FirstOrDefault(x => x.Ma == ma);
            if (dv != null)
            {
                db.NhanViens.Remove(dv);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
