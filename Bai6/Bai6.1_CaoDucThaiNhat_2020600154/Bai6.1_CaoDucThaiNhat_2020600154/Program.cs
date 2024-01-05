using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using Newtonsoft.Json;

namespace Bai6._1_CaoDucThaiNhat_2020600154
{
    class Program
    {
        static void Main2(string[] args)
        {
            WriteToFile();
            ReadFromFile();
        }
        static void WriteToFile()
        {
            List<Student> stu = new List<Student>();
            stu.Add(new Student("s01", "Tran long", 21, "Hai Phong"));
            stu.Add(new Student("s02", "Nguyen Hang", 21, "Quang Ninh"));
            stu.Add(new Student("s03", "Phan Mai", 20, "Ha Noi"));
            File.WriteAllText("student.json", JsonConvert.SerializeObject(stu));
            //using(StreamWriter file = File.CreateText("student2.json"))
            //{
            //    JsonSerializer serializer = new JsonSerializer();
            //    serializer.Serialize(file, stu);
            //}
        }
        static void ReadFromFile()
        {
            Student stu;
            using (StreamReader file = File.OpenText("student.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                stu = (Student)serializer.Deserialize(file, typeof(Student));
                Console.WriteLine("Student " + stu);
            }
        }
    }
}
