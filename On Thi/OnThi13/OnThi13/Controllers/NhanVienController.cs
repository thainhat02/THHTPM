using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OnThi13.Models;

namespace OnThi13.Controllers
{
    public class NhanVienController : ApiController
    {
        CSDLTest13 db = new CSDLTest13();
        [HttpGet]
        public List<NhanVien> GetAll()
        {
            List<NhanVien> li = db.NhanViens.ToList();
            return li;
        }
        [HttpGet]
        public List<NhanVien> Find(string ma)
        {
            List<NhanVien> li = db.NhanViens.Where(x => x.Ma == ma).ToList();
            return li;
        }
        [HttpPost]
        public IHttpActionResult Add([FromBody] NhanVien nv)
        {
            db.NhanViens.Add(nv);
            db.SaveChanges();
            return Ok("Thêm thành công");
        }
        [HttpPut]
        public IHttpActionResult Update([FromBody] NhanVien nv)
        {
            NhanVien nhanVien = db.NhanViens.FirstOrDefault(x => x.Ma == nv.Ma);
            if (nhanVien != null)
            {
                nhanVien.Ten = nv.Ten;
                nhanVien.NgaySinh = nv.NgaySinh;
                nhanVien.GioiTinh = nv.GioiTinh;
                nhanVien.HeSoLuong = nv.HeSoLuong;
                db.SaveChanges();
            }
            else
            {
                return NotFound();
            }
            return Ok("Sửa thành công");
        }
        [HttpDelete]
        public IHttpActionResult Delete(string ma)
        {
            NhanVien nhanVien = db.NhanViens.FirstOrDefault(x => x.Ma == ma);
            if (nhanVien!=null)
            {
                db.NhanViens.Remove(nhanVien);
                db.SaveChanges();
            }
            else
            {
                return NotFound();
            }
            return Ok("Xóa thành công");
        }
    }
}
