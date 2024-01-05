using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace OntapTX21
{
    class DataUtil
    {
        XmlDocument doc;
        XmlElement root;
        string filename;
        public DataUtil()
        {
            doc = new XmlDocument();
            filename = @"D:\Kỳ 7\Tích hợp hệ thống phần mềm\OntapTX21\OntapTX21\ThuVIen.xml";
            if (!File.Exists(filename))
            {
                XmlElement thuvien = doc.CreateElement("thuvien");
                doc.AppendChild(thuvien);
                doc.Save(filename);
            }
            doc.Load(filename);
            root = doc.DocumentElement;
        }
        public List<Sach> ShowList()
        {
            XmlNodeList nodeList = root.SelectNodes("sach");
            List<Sach> li = new List<Sach>();
            foreach(XmlNode node in nodeList)
            {
                Sach s = new Sach();
                s.masach = node.Attributes[0].InnerText;
                s.tensach = node.SelectSingleNode("tensach").InnerText;
                s.sotrang = node.SelectSingleNode("sotrang").InnerText;
                s.hoten = node.SelectSingleNode("tacgia/@hoten").InnerText;
                s.diachi = node.SelectSingleNode("tacgia/diachi").InnerText;
                li.Add(s);
            }
            return li;
        }
        public bool Add(Sach s)
        {
            XmlNode checkid = root.SelectSingleNode("sach[@masach='" + s.masach + "']");
            if (checkid!=null)
            {
                return false;
            }
            else
            {
                XmlElement sach = doc.CreateElement("sach");
                sach.SetAttribute("masach", s.masach);
                XmlElement tensach = doc.CreateElement("tensach");
                tensach.InnerText = s.tensach;
                XmlElement sotrang = doc.CreateElement("sotrang");
                sotrang.InnerText = s.sotrang;
                XmlElement tacgia = doc.CreateElement("tacgia");
                tacgia.SetAttribute("hoten", s.hoten);
                XmlElement diachi = doc.CreateElement("diachi");
                diachi.InnerText = s.diachi;
                tacgia.AppendChild(diachi);
                sach.AppendChild(tensach);
                sach.AppendChild(sotrang);
                sach.AppendChild(tacgia);
                root.AppendChild(sach);
                doc.Save(filename);
                return true;
            }
        }
        public bool Update(Sach s)
        {
            XmlNode checkid = root.SelectSingleNode("sach[@masach='" + s.masach + "']");
            if (checkid != null)
            {
                XmlElement sach = doc.CreateElement("sach");
                sach.SetAttribute("masach", s.masach);
                XmlElement tensach = doc.CreateElement("tensach");
                tensach.InnerText = s.tensach;
                XmlElement sotrang = doc.CreateElement("sotrang");
                sotrang.InnerText = s.sotrang;
                XmlElement tacgia = doc.CreateElement("tacgia");
                tacgia.SetAttribute("hoten", s.hoten);
                XmlElement diachi = doc.CreateElement("diachi");
                diachi.InnerText = s.diachi;
                tacgia.AppendChild(diachi);
                sach.AppendChild(tensach);
                sach.AppendChild(sotrang);
                sach.AppendChild(tacgia);
                root.ReplaceChild(sach, checkid);
                doc.Save(filename);
                return true;
            }
            return false;
        }
        public bool Delete(string masach)
        {
            XmlNode checkid = root.SelectSingleNode("sach[@masach='" + masach + "']");
            if (checkid != null)
            {
                if(MessageBox.Show("Xác nhận yêu cầu xóa", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    root.RemoveChild(checkid);
                    doc.Save(filename);
                    return true;
                }
                else
                {
                    return true;
                }
                
            }
            return false;
        }
        public List<Sach> FindName(string hoten)
        {
            XmlNodeList nodeList = root.SelectNodes("sach[tacgia[@hoten='" + hoten + "']]");
            List<Sach> li = new List<Sach>();
            foreach(XmlNode node in nodeList)
            {
                Sach s = new Sach();
                s.masach = node.Attributes[0].InnerText;
                s.tensach = node.SelectSingleNode("tensach").InnerText;
                s.sotrang = node.SelectSingleNode("sotrang").InnerText;
                s.hoten = node.SelectSingleNode("tacgia/@hoten").InnerText;
                s.diachi = node.SelectSingleNode("tacgia/diachi").InnerText;
                li.Add(s);
            }
            return li;

        }
    }
}
