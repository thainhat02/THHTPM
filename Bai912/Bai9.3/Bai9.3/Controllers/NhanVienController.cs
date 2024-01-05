using Bai9._3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bai9._3.Controllers
{
    public class NhanVienController : ApiController
    {
        Model1 db = new Model1();
        [HttpGet]
        public List<NhanVien> DSNV()
        {
            List<NhanVien> li = db.NhanViens.ToList();
            foreach(NhanVien nv in li)
            {
                nv.DonVi = null;
            }
            return li;
        }
        [HttpGet]
        public NhanVien ChiTiet(string id)
        {
            NhanVien nv = db.NhanViens.First(x => x.Ma == id);
            if (nv != null)
            {
                nv.DonVi = null;
            }
            return nv;
        }
        [HttpGet]
        public List<NhanVien> DSByDV(string madv)
        {
            List<NhanVien> nv = db.NhanViens.Where(x => x.MaDonVi == madv).ToList();
            foreach(NhanVien n in nv)
            {
                n.DonVi = null;
            }
            return nv;
        }
        [HttpGet]
        public List<NhanVien> DSByGT(string gt)
        {
            List<NhanVien> li = db.NhanViens.Where(x => x.GioiTinh == gt).ToList();
            foreach(NhanVien nv in li)
            {
                nv.DonVi = null;
            }
            return li;
        }
        [HttpGet]
        public List<NhanVien> DSByHSL(int a, int b)
        {
            List<NhanVien> li = db.NhanViens.Where(x => x.HsLuong >= a && x.HsLuong <= b).ToList();
            foreach(NhanVien nv in li)
            {
                nv.DonVi = null;
            }
            return li;
        }
        [HttpPost]
        public bool luunhanvien(string manv, string tennhanvien,DateTime ngaysinh, string gioitinh, int hsl, string madonvi)
        {
            NhanVien nv = db.NhanViens.FirstOrDefault(x => x.Ma == manv);
            if (nv == null)
            {
                NhanVien a = new NhanVien();
                a.Ma = manv;
                a.HoTen = tennhanvien;
                a.NgaySinh = ngaysinh;
                a.GioiTinh = gioitinh;
                a.HsLuong = hsl;
                a.MaDonVi = madonvi;
                db.NhanViens.Add(a);
                db.SaveChanges();
                return true;
            }
            return false;
        }
        [HttpPut]
        public bool suanhanvien(string manv, string tennhanvien, DateTime ngaysinh, string gioitinh, int hsl, string madonvi)
        {
            NhanVien nv = db.NhanViens.FirstOrDefault(x => x.Ma == manv);
            if (nv != null)
            {
                nv.HoTen = tennhanvien;
                nv.NgaySinh = ngaysinh;
                nv.GioiTinh = gioitinh;
                nv.HsLuong = hsl;
                nv.MaDonVi = madonvi;
                db.SaveChanges();
                return true;
            }
            return false;
        }
        [HttpDelete]
        public bool xoanhanvien(string manv)
        {
            NhanVien nv = db.NhanViens.FirstOrDefault(x => x.Ma == manv);
            if (nv != null)
            {
                db.NhanViens.Remove(nv);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
