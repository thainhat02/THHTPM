using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Bai7._1_lamLai
{
    class DataUtil
    {
        XmlDocument doc;
        XmlElement root;
        string filename;
        public DataUtil()
        {
            filename = "nganhang.xml";
            doc = new XmlDocument();
            if (!File.Exists(filename))
            {
                XmlElement nganhang = doc.CreateElement("nganhang");
                doc.AppendChild(nganhang);
                doc.Save(filename);
            }
            doc.Load(filename);
            root = doc.DocumentElement;
        }
        public bool AppTaiKhoan(TaiKhoan tk)
        {   // Tìm kiếm phần tử thỏa mãn điều kiện
            XmlNode checktk = root.SelectSingleNode("taikhoan[sotaikhoan='" + tk.sotaikhoan + "']");
            
            if (checktk != null)
            {
                return false;
            }
            else
            {
                XmlElement taikhoan = doc.CreateElement("taikhoan");
                XmlElement sotaikhoan = doc.CreateElement("sotaikhoan");
                sotaikhoan.InnerText = tk.sotaikhoan;
                XmlElement tentaikhoan = doc.CreateElement("tentaikhoan");
                tentaikhoan.InnerText = tk.tentaikhoan;
                XmlElement diachi = doc.CreateElement("diachi");
                diachi.InnerText = tk.diachi;
                XmlElement dienthoai = doc.CreateElement("dienthoai");
                dienthoai.InnerText = tk.dienthoai;
                XmlElement sotien = doc.CreateElement("sotien");
                sotien.InnerText = tk.sotien;
                taikhoan.AppendChild(sotaikhoan);
                taikhoan.AppendChild(tentaikhoan);
                taikhoan.AppendChild(diachi);
                taikhoan.AppendChild(dienthoai);
                taikhoan.AppendChild(sotien);
                root.AppendChild(taikhoan);
                doc.Save(filename);
                return true;
            }
          
        }
    }
}
