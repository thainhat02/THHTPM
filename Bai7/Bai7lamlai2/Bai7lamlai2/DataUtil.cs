using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Bai7lamlai2
{
    class DataUtil
    {
        XmlDocument doc;
        XmlElement root;
        string filename;
        public DataUtil()
        {
            filename = "Course.xml";
            doc = new XmlDocument();
            if (!File.Exists(filename)) // nếu file không tòn tại
            {
                XmlElement course = doc.CreateElement("course");
                doc.AppendChild(course);
                doc.Save(filename);
            }
            doc.Load(filename);
            root = doc.DocumentElement;
        }
        public bool AddStudent(Student s)
        {
            XmlNode check = root.SelectSingleNode("student[@id='" + s.id + "']");
            if(check != null)
            { 
                return false;
            }
            else
            {
                XmlElement student = doc.CreateElement("student");
                student.SetAttribute("id", s.id);
                XmlElement name = doc.CreateElement("name");
                name.InnerText = s.name;
                XmlElement age = doc.CreateElement("age");
                age.InnerText = s.age;
                XmlElement city = doc.CreateElement("city");
                city.InnerText = s.city;

                student.AppendChild(name);
                student.AppendChild(age);
                student.AppendChild(city);
                root.AppendChild(student);
                doc.Save(filename);
                return true;
            }
            
        }
    }
}
