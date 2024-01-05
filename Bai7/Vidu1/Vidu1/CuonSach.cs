using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vidu1
{
    public class CuonSach
    {
        public string masach { get; set; }
        public string theloai { get; set; }
        public string  tensach{ get; set; }
        public string sotrang { get; set; }
        public string hoten { get; set; }
        public string dienthoai { get; set; }
        public string giatien { get; set; }
        public CuonSach() { }

        public CuonSach(string masach, string theloai, string tensach, string sotrang, string hoten, string dienthoai, string giatien)
        {
            this.masach = masach;
            this.theloai = theloai;
            this.tensach = tensach;
            this.sotrang = sotrang;
            this.hoten = hoten;
            this.dienthoai = dienthoai;
            this.giatien = giatien;
        }
    }
}
