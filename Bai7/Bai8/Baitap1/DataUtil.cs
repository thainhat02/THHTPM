using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Baitap1
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
        public bool AddStudent(student stu)
        {
            XmlNode checkId = root.SelectSingleNode("student[@id='" + stu.id + "']");
            if (checkId != null)
            {
                return false;
            }
            else
            {
                XmlElement student = doc.CreateElement("student");
                student.SetAttribute("id", stu.id);
                XmlElement name = doc.CreateElement("name");
                name.InnerText = stu.name;
                XmlElement age = doc.CreateElement("age");
                age.InnerText = stu.age;
                XmlElement city = doc.CreateElement("city");
                city.InnerText = stu.city;
                student.AppendChild(name);
                student.AppendChild(age);
                student.AppendChild(city);
                root.AppendChild(student);
                doc.Save(filename);
                return true;
            }
        }
        public bool UpdateStudent(student stu)
        {
            XmlNode checkId = root.SelectSingleNode("student[@id='" + stu.id + "']");
            if (checkId != null)
            {
                XmlElement student = doc.CreateElement("student");
                student.SetAttribute("id", stu.id);
                XmlElement name = doc.CreateElement("name");
                name.InnerText = stu.name;
                XmlElement age = doc.CreateElement("age");
                age.InnerText = stu.age;
                XmlElement city = doc.CreateElement("city");
                city.InnerText = stu.city;
                student.AppendChild(name);
                student.AppendChild(age);
                student.AppendChild(city);
                root.ReplaceChild(student, checkId);
                doc.Save(filename);
                return true;
            }
            return false;
        }

        public bool DeleteStudent(string id)
        {
            XmlNode checkId = root.SelectSingleNode("student[@id='" + id + "']");
            if (checkId != null)
            {
                if(MessageBox.Show("Xác nhận yêu cầu xóa", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    root.RemoveChild(checkId);
                    doc.Save(filename);
                }
                return true;
            }
            return false;
        }
        public List<student> ShowList()
        {
            XmlNodeList nodeList = root.SelectNodes("student");
            List<student> li = new List<student>(); 
            foreach(XmlNode item in nodeList)
            {
                student s = new student();
                s.id = item.Attributes[0].InnerText;
                s.name = item.SelectSingleNode("name").InnerText;
                s.age = item.SelectSingleNode("age").InnerText;
                s.city = item.SelectSingleNode("city").InnerText;
                li.Add(s);
            }
            return li;
        }
        public List<student> FindByID(string id)
        {
            XmlNode find = root.SelectSingleNode("student[@id='" + id + "']");
            List<student> li = null;
            student s = null;
            if (find != null)
            {
                li = new List<student>();
                s = new student();
                s.id = find.Attributes[0].InnerText;
                s.name = find.SelectSingleNode("name").InnerText;
                s.age = find.SelectSingleNode("age").InnerText;
                s.city = find.SelectSingleNode("city").InnerText;
                li.Add(s);
            }
            return li;
            
        }


        public List<student> FindByName(string name)
        {
            XmlNodeList nodeList = root.SelectNodes("student");
            List<student> li = new List<student>();
            XmlNode find = root.SelectSingleNode("student[name='" + name + "']");
            if (find != null)
            {
                foreach (XmlNode item in nodeList)
                {
                    if (item.SelectSingleNode("name").InnerText == name)
                    {
                        student s = new student();
                        s.id = item.Attributes[0].InnerText;
                        s.name = item.SelectSingleNode("name").InnerText;
                        s.age = item.SelectSingleNode("age").InnerText;
                        s.city = item.SelectSingleNode("city").InnerText;
                        li.Add(s);
                    }
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy sinh vien");
            }
            return li;

        }
    }
}
