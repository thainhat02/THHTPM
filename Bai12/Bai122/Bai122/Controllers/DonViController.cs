using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bai122.Models;

namespace Bai122.Controllers
{
    public class DonViController : ApiController
    {
        QLLuongEntities db = new QLLuongEntities();
        [HttpGet]
        public List<DonVi> LayALL()
        {
            List<DonVi> li = db.DonVis.ToList();
            return li;
        }
        [HttpPost]
        public bool Add(string ma, string ten)
        {
            DonVi dv = db.DonVis.FirstOrDefault(x => x.MaDonVi == ma);
            if (dv == null)
            {
                DonVi d = new DonVi();
                d.MaDonVi = ma;
                d.TenDonVi = ten;
                db.DonVis.Add(d);
                db.SaveChanges();
                return true;
            }
            return false;
        }
        [HttpPut]
        public bool Update(string ma, string ten)
        {
            DonVi dv = db.DonVis.FirstOrDefault(x => x.MaDonVi == ma);
            if (dv != null)
            {
                dv.TenDonVi = ten;
                db.SaveChanges();
                return true;
            }
            return false;
        }
        [HttpDelete]
        public bool Delete(string ma)
        {
            DonVi dv = db.DonVis.FirstOrDefault(x => x.MaDonVi == ma);
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
