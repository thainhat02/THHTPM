using Bai9._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bai9._1.Controllers
{
    public class DanhMucController : ApiController
    {
        Model1 db = new Model1();
        [HttpGet]
        public DanhMuc DSDM(int id)
        {
            DanhMuc dm = db.DanhMucs.First(x => x.MaDanhMuc == id);
            if (dm != null)
            {
                dm.sanPhams.Clear();
            }
            return dm;
        }
        [HttpPost]
        public bool LuuDanhMuc(int madm, string tendanhmuc)
        {
            try
            {
                DanhMuc dm = new DanhMuc();
                dm.MaDanhMuc = madm;
                dm.TenDanhMuc = tendanhmuc;
                db.DanhMucs.Add(dm);
                db.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine("Lỗi: " + e.Message);
                return false;
            }
        }
        [HttpPut]
        public bool SuaDanhMuc(int madm, string tendanhmuc)
        {
            DanhMuc dm = db.DanhMucs.FirstOrDefault(x => x.MaDanhMuc == madm);
            if (dm != null)
            {
                dm.MaDanhMuc = madm;
                dm.TenDanhMuc = tendanhmuc;
                db.SaveChanges();
                return true;
            }
            return false;
        }
        [HttpGet]
        public bool XoaDanhmuc(int madm)
        {
            DanhMuc dm = db.DanhMucs.FirstOrDefault(x => x.MaDanhMuc == madm);
            if (dm != null)
            {
                db.DanhMucs.Remove();
                return true;
            }
            return false;
        }
    }
}
