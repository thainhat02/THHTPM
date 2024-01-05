using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Vidu1
{
    class ThuVien
    {
        static void main(string[] agrs)
        {
            XmlDocument doc = new XmlDocument();
            XmlElement root = doc.CreateElement("thuvien");
            CuonSach s1 = new CuonSach("j01", "Công nghệ", "Java", "350", "Nhật", "08555555", "350");
            themsach(doc, root, s1);
        }
        static void themsach(XmlDocument doc, XmlElement root, CuonSach cs)
        {
            XmlElement cuonsach = doc.CreateElement("cuonsach");
            cuonsach.SetAttribute("masach", cs.masach);
            cuonsach.SetAttribute("theloai", cs.theloai);
            XmlElement tensach = doc.CreateElement("tensach");
            XmlText ttensach = doc.CreateTextNode(cs.tensach);
            XmlElement sotrang = doc.CreateElement("sotrang");
            XmlText ttsotrang = doc.CreateTextNode(cs.sotrang);
            XmlElement tacgia = doc.CreateElement("tacgia");
            XmlElement hoten = doc.CreateElement("hoten");
            XmlText thoten = doc.CreateTextNode(cs.hoten);
            XmlElement dienthoai = doc.CreateElement("dienthoai");
            XmlText tdienthoai = doc.CreateTextNode(cs.dienthoai);
            XmlElement giatien = doc.CreateElement("giatien");
            XmlText tgiatien = doc.CreateTextNode(cs.giatien);
            root.AppendChild(cuonsach);
            cuonsach.AppendChild(tensach);
            cuonsach.AppendChild(sotrang);
            cuonsach.AppendChild(tacgia);
            cuonsach.AppendChild(giatien);
            tacgia.AppendChild(hoten);
            tacgia.AppendChild(dienthoai);
            tensach.AppendChild(ttensach);
            sotrang.AppendChild(ttsotrang);
            hoten.AppendChild(thoten);
            dienthoai.AppendChild(tdienthoai);
            giatien.AppendChild(tgiatien);
        }
    }
}
