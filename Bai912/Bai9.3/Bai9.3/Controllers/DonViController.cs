using Bai9._3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bai9._3.Controllers
{
    public class DonViController : ApiController
    {
        Model1 db = new Model1();
        [HttpGet]
        public List<DonVi> ListALL()
        {
            List<DonVi> li = db.DonVis.ToList();
            foreach(DonVi dv in li)
            {
                dv.NhanViens = null;
            }
            return li;
        }
        [HttpGet]
        public DonVi ChiTietDV(string id)
        {
            DonVi dv = db.DonVis.First(x => x.MaDonVi == id);
            if (dv != null)
            {
                dv.NhanViens = null;
            }
            return dv;
        }
        [HttpPost]
        public bool luudonvi(string madv, string tendonvi)
        {
            DonVi dv = db.DonVis.FirstOrDefault(x => x.MaDonVi == madv);
            if (dv == null)
            {
                DonVi a = new DonVi();
                a.MaDonVi = madv;
                a.TenDonVi = tendonvi;
                db.DonVis.Add(a);
                db.SaveChanges();
                return true;
            }
            return false;
        }
        [HttpPut]
        public bool suadonvi(string madv, string tendonvi)
        {
            DonVi dv = db.DonVis.FirstOrDefault(x => x.MaDonVi == madv);
            if (dv != null)
            {
                dv.TenDonVi = tendonvi;
                db.SaveChanges();
                return true;
            }
            return false;
        }
        [HttpDelete]
        public bool xoadonvi(string madv)
        {
            DonVi dv = db.DonVis.FirstOrDefault(x => x.MaDonVi == madv);
            if (dv != null)
            {
                db.DonVis.Remove(dv);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
