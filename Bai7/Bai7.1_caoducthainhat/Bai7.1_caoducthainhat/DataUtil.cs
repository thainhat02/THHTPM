using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace Bai7._1_caoducthainhat
{
    class DataUtil
    {
        XmlDocument doc; // đại diện cho một tài liệu xml
        XmlElement root;
        string filename;
        public DataUtil()
        {
            filename = "NganHang.xml"; 
            doc = new XmlDocument();
            if (!File.Exists(filename)) // kiểm tra xem filename có tồn tại không
            {
                XmlElement nganhang = doc.CreateElement("nganhang");// tạo một phần tử trong xml
                doc.AppendChild(nganhang); // thêm phần  tử nganhang vào tài liệu xml
                doc.Save(filename);
            }
            doc.Load(filename); // tải một tài liệu xml từ tệp tin filename vào doc
            root = doc.DocumentElement; // Lấy ra phần tử gốc và gán cho biến root
        }

        // Hiển thị danh sách
        public List<TaiKhoan>ShowCount()
        {
            List<TaiKhoan> taiKhoans = new List<TaiKhoan>();
            XmlNodeList nodeList = root.SelectNodes("taikhoan");
            foreach(XmlNode node in nodeList)
            {
                TaiKhoan taiKhoan = new TaiKhoan
                {
                    sotaikhoan = node.SelectSingleNode("sotaikhoan").InnerText,
                    tentaikhoan = node.SelectSingleNode("tentaikhoan").InnerText,
                    diachi = node.SelectSingleNode("diachi").InnerText,
                    dienthoai = node.SelectSingleNode("dienthoai").InnerText,
                    sotien = node.SelectSingleNode("sotien").InnerText

                };
                taiKhoans.Add(taiKhoan);
                
            }
            return taiKhoans;

        }

        //Thêm tài khoản
        public bool AddTaiKhoan(TaiKhoan tk)
        {
            XmlNode tkfind = root.SelectSingleNode("taikhoan[sotaikhoan='" + tk.sotaikhoan + "']");
            if (tkfind != null)
            {
                return false;
            }
            else
            {
            XmlElement taikhoan = doc.CreateElement("taikhoan");
            //taikhoan.SetAttribute("id", tk.sotaikhoan);   đặt giá trị cho thuộc tính
            XmlElement sotaikhoan = doc.CreateElement("sotaikhoan");

            sotaikhoan.InnerText = tk.sotaikhoan; // innertext đặt nội dung văn bản cho phần tử xml
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


        // Sửa tài khoản
        public bool UpdateTaiKhoan(TaiKhoan tk)
        {
            XmlNode tkfind = root.SelectSingleNode("taikhoan[sotaikhoan='" + tk.sotaikhoan + "']");
            if (tkfind != null)
            {
                XmlElement taikhoan = doc.CreateElement("taikhoan");
                XmlElement sotaikhoan = doc.CreateElement("sotaikhoan");
                sotaikhoan.InnerText = tk.sotaikhoan; // innertext đặt nội dung văn bản cho phần tử xml
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
                root.ReplaceChild(taikhoan, tkfind);
                doc.Save(filename);
                return true;
            }
            return false;
        }
        public bool DeleteTaiKhoan(string sotaikhoan)
        {
            XmlNode tkdlt = root.SelectSingleNode("taikhoan[sotaikhoan='" + sotaikhoan + "']");
            if(tkdlt!= null)
            {
                root.RemoveChild(tkdlt);
                doc.Save(filename);
                return true;
            }

            return false;
        }
        public TaiKhoan FindByID(string sotaikhoan)
        {
            XmlNode tkdlt = root.SelectSingleNode("taikhoan[sotaikhoan='" + sotaikhoan + "']");
            TaiKhoan tk = null;
            if( tkdlt != null)
            {
                tk = new TaiKhoan();
                tk.sotaikhoan = tkdlt.SelectSingleNode("sotaikhoan").InnerText;
                tk.tentaikhoan = tkdlt.SelectSingleNode("tentaikhoan").InnerText;
                tk.diachi = tkdlt.SelectSingleNode("diachi").InnerText;
                tk.dienthoai = tkdlt.SelectSingleNode("dienthoai").InnerText;
                tk.sotien = tkdlt.SelectSingleNode("sotien").InnerText;
            }
            return tk;
        }

        public List<TaiKhoan> FindByName(string tentaikhoan)
        {
            XmlNodeList nodeList = root.SelectNodes("taikhoan[tentaikhoan='" + tentaikhoan + "']");
            List<TaiKhoan> li = new List<TaiKhoan>();
            
            if (nodeList != null)
            {
                foreach(XmlNode tkdlt in nodeList)
                {
                    TaiKhoan tk = new TaiKhoan();
                    tk.sotaikhoan = tkdlt.SelectSingleNode("sotaikhoan").InnerText;
                    tk.tentaikhoan = tkdlt.SelectSingleNode("tentaikhoan").InnerText;
                    tk.diachi = tkdlt.SelectSingleNode("diachi").InnerText;
                    tk.dienthoai = tkdlt.SelectSingleNode("dienthoai").InnerText;
                    tk.sotien = tkdlt.SelectSingleNode("sotien").InnerText;
                    li.Add(tk);
                }
            }
            return li;
        }

    }
}
