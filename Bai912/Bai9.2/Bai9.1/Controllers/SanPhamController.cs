using Bai9._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bai9._1.Controllers
{
    public class SanPhamController : ApiController
    {
        Model1 data = new Model1();
        [HttpGet]
        public List<SanPham> ListALL()
        {
            List<SanPham> li = data.SanPhams.ToList();
            foreach(SanPham sp in li)
            {
                sp.MaDanhMuc = null;
            }
            return li;
        }
    }
}
