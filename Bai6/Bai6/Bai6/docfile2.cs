using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
namespace Bai6
{
    class docfile2
    {
        static void Main(string[] arg)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("ĐỌC FILE CÁCH 2");
            XmlDocument doc = new XmlDocument();
            doc.Load("thuvien.xml");
            XmlElement root = doc.DocumentElement;
            PrintNode(root);
            Console.ReadKey();
        }
        static void PrintNode(XmlNode node)
        {
            Console.WriteLine("Type =[" + node.NodeType + "]");
            Console.WriteLine(", Name =" + node.Name);
            Console.WriteLine(", Value = [" + node.Value+ "]");

            XmlNodeList childnode = node.ChildNodes;
            if (childnode.Count > 0)
            {
                Console.WriteLine("----------Các con của node: " + node.Name + " là: ");
                foreach(XmlNode item in childnode)
                {
                    PrintNode(item);
                }
                Console.WriteLine("Kết thúc một node " + node.Name);
            }
        }
    }
}
