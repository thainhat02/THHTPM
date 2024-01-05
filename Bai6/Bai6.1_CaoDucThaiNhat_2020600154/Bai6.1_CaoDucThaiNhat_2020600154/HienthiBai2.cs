using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Bai6._1_CaoDucThaiNhat_2020600154
{
    class HienthiBai2
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // chuyển đổi kiểu tiếng việt
            Console.WriteLine("CHƯƠNG TRÌNH ĐỌC FILE sanpham.XML");
            XmlDocument doc = new XmlDocument();
            doc.Load("sanpham.xml");
            XmlElement root = doc.DocumentElement; // Lấy ra phần tử gốc
            XmlNodeList li = root.SelectNodes("sanpham"); // Lấy ra một danh sách các nút cuonsach 
            int i = 1;
            foreach (XmlNode item in li)
            {
                Console.WriteLine("-----------------------\nPhần tử thứ " + i);
                Console.WriteLine("Mã sản phẩm: " + item.SelectSingleNode("masp").InnerText);
                Console.WriteLine("Tên sản phẩm: " + item.SelectSingleNode("tensp").InnerText);
                Console.WriteLine("Số lượng: " + item.SelectSingleNode("soluong").InnerText);
                i++;
            }
            Console.WriteLine("Số lượng sản phẩm" + li.Count);
            Console.ReadKey();
        }
    }
}
