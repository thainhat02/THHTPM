using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
namespace Bai6._2_CaoDucThaiNhat_2020600154
{
    class Program
    {
        static void Main(string[] args)
        {
                Console.OutputEncoding = System.Text.Encoding.UTF8; // chuyển đổi kiểu tiếng việt
                Console.WriteLine("CHƯƠNG TRÌNH ĐỌC FILE Congty.XML");
                XmlDocument doc = new XmlDocument();
                doc.Load("Congty.xml");
                XmlElement root = doc.DocumentElement; // Lấy ra phần tử gốc
                XmlNodeList li = root.SelectNodes("nhanvien"); // Lấy ra một danh sách các nút cuonsach 
                int i = 1;
                foreach (XmlNode item in li)
                {
                    Console.WriteLine("-----------------------\nPhần tử thứ " + i);
                    Console.WriteLine("Họ tên: " + item.SelectSingleNode("hoten").InnerText);
                    Console.WriteLine("Tuổi: " + item.SelectSingleNode("tuoi").InnerText);
                    Console.WriteLine("Lương: " + item.SelectSingleNode("luong").InnerText);
                    Console.WriteLine("Xã: " + item.SelectSingleNode("diachi/xa").InnerText);
                    Console.WriteLine("Huyện: " + item.SelectSingleNode("diachi/huyen").InnerText);
                    Console.WriteLine("Tỉnh: " + item.SelectSingleNode("diachi/tinh").InnerText);
                    Console.WriteLine("Điện thoại: " + item.SelectSingleNode("dienthoai").InnerText);
                i++;
                }
                Console.WriteLine("Số lượng cuốn sách" + li.Count);
                Console.ReadKey();
            }
        
    }
}
