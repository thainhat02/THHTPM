using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Baitap3
{
    class DataUtil
    {
        XmlDocument doc;
        XmlElement root;
        string filename;
        public DataUtil()
        {
            doc = new XmlDocument();
            filename = "Course.xml";
            if (!File.Exists(filename))
            {
                XmlElement course = doc.CreateElement("course");
                doc.AppendChild(course);
                doc.Save(filename);
            }
            doc.Load(filename);
            root = doc.DocumentElement;
        }
        public List<Student> ShowList()
        {
            XmlNodeList nodeList = root.SelectNodes("student");
            List<Student> li = new List<Student>();
            foreach(XmlNode node in nodeList)
            {
                Student s = new Student();
                s.id = node.Attributes[0].InnerText;
                s.name = node.SelectSingleNode("name").InnerText;
                s.age = node.SelectSingleNode("age").InnerText;
                s.city = node.SelectSingleNode("city").InnerText;
                li.Add(s);
            }
            return li;
        }
        public bool AddStudent(Student s)
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
        public bool UpdateStudent(Student s)
        {
            XmlNode checkid = root.SelectSingleNode("student[@id='" + s.id + "']");
            if (checkid != null)
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
            if (checkid != null)
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
        public Student FindId(string id)
        {
            XmlNode checkid = root.SelectSingleNode("student[@id='" + id + "']");
            Student student = null;
            if(checkid != null)
            {
                student = new Student();
                student.id = checkid.Attributes[0].InnerText;
                student.name = checkid.SelectSingleNode("name").InnerText;
                student.age = checkid.SelectSingleNode("age").InnerText;
                student.city = checkid.SelectSingleNode("city").InnerText;
            }
            
            return student;
        }
        public List<Student> FindName(string name)
        {
            XmlNodeList checkname = root.SelectNodes("student[name='" + name + "']");
            List<Student> li = new List<Student>();
            foreach(XmlNode node in checkname)
            {
                Student s = new Student();
                s.id = node.Attributes[0].InnerText;
                s.name = node.SelectSingleNode("name").InnerText;
                s.age = node.SelectSingleNode("age").InnerText;
                s.city = node.SelectSingleNode("city").InnerText;
                li.Add(s);
            }
            return li;
        }
    }
}
