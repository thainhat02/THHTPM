using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace Baitap2
{
    class DataUtil
    {
        XmlDocument doc;
        XmlElement root;
        string filename;
        public DataUtil()
        {
            doc = new XmlDocument();
            filename = "course.xml";
            if (!File.Exists(filename))
            {
                XmlElement course = doc.CreateElement("course");
                doc.AppendChild(course);
                doc.Save(filename);
            }
            doc.Load(filename);
            root = doc.DocumentElement;
        }
        public bool AddStudent(student s)
        {
            XmlNode checkid = root.SelectSingleNode("student[@id='" + s.id + "']");
            if(checkid != null)
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
        public bool UpdateStudent(student s)
        {
            XmlNode checkid = root.SelectSingleNode("student[@id='" + s.id + "']");
            if(checkid != null)
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
                root.ReplaceChild(student, checkid);
                doc.Save(filename);
                return true;
            }
            return false;
        }
        public bool DeleteStudent(string id)
        {
            XmlNode checkid = root.SelectSingleNode("student[@id='" + id + "']");
            if(checkid != null)
            {
                if(MessageBox.Show("Xác nhận yêu cầu xóa", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    root.RemoveChild(checkid);
                    doc.Save(filename);
                    return true;
                }
            }
            return false;
        }
        public List<student> ShowList()
        {
            XmlNodeList nodeList = root.SelectNodes("student");
            List<student> li = new List<student>();
            foreach(XmlNode node in nodeList)
            {
                student s = new student();
                s.id = node.Attributes[0].InnerText;
                s.name = node.SelectSingleNode("name").InnerText;
                s.age = node.SelectSingleNode("age").InnerText;
                s.city = node.SelectSingleNode("city").InnerText;
                li.Add(s);
            }
            return li;
        }
        public student FindId(string id)
        {
            XmlNode find = root.SelectSingleNode("student[@id='" + id + "']");
            student s = null;
            if (find != null)
            {
                s = new student();
                s.id = find.Attributes[0].InnerText;
                s.name = find.SelectSingleNode("name").InnerText;
                s.age = find.SelectSingleNode("age").InnerText;
                s.city = find.SelectSingleNode("city").InnerText;
            }
            return s;
        }
    }
}
