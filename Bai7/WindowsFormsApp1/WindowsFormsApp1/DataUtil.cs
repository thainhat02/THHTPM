using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
namespace WindowsFormsApp1
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
            if (!File.Exists(filename))
            {
                XmlElement course = doc.CreateElement("course");
                doc.AppendChild(course);
                doc.Save(filename);
            }
            doc.Load(filename);
            root = doc.DocumentElement;
        }
        public void AddStudent(Student s)
        {
            XmlElement st = doc.CreateElement("student");
            st.SetAttribute("id", s.id);
            XmlElement name = doc.CreateElement("name");
            name.InnerText = s.name;
            XmlElement age = doc.CreateElement("age");
            age.InnerText = s.age;
            XmlElement city = doc.CreateElement("city");
            city.InnerText = s.city;
            st.AppendChild(name);
            st.AppendChild(age);
            st.AppendChild(city);
            root.AppendChild(st);
            doc.Save(filename);
        }
    }
}
