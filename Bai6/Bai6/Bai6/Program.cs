using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Bai6
{
    class Program
    {
        static void Main2(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // chuyển đổi kiểu tiếng việt
            Console.WriteLine("CHƯƠNG TRÌNH ĐỌC FILE THUVIEN.XML");
            XmlDocument doc = new XmlDocument();
            doc.Load("thuvien.xml");
            XmlElement root = doc.DocumentElement; // Lấy ra phần tử gốc
            XmlNodeList li = root.SelectNodes("cuonsach"); // Lấy ra một danh sách các nút cuonsach 
            int i = 1;
            foreach(XmlNode item in li)
            {
                Console.WriteLine("-----------------------\nPhần tử thứ " + i);
                Console.WriteLine("Tên sách: " + item.SelectSingleNode("tensach").InnerText);// Hiển thị tên sách sử dụng SelectSingleNode
                Console.WriteLine("Số trang: " + item.SelectSingleNode("sotrang").InnerText);// Hiển thị số trang 
                Console.WriteLine("Họ tên tác giả: " + item.SelectSingleNode("tacgia/hoten").InnerText);// Hiển thị họ tên tác giả
                Console.WriteLine("Điện thoại tác giả: " + item.SelectSingleNode("tacgia/dienthoai").InnerText);// Hiển thị điện thoại tác giả
                Console.WriteLine("Giá tiền: " + item.SelectSingleNode("giatien").InnerText);
                i++;
            }
            Console.WriteLine("Số lượng cuốn sách" + li.Count);
            Console.ReadKey();
        }
    }
}
