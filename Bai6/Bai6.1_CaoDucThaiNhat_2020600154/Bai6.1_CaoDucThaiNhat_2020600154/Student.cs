using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai6._1_CaoDucThaiNhat_2020600154
{
    public class Student
    {
        public string id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public string city { get; set; }
        public Student() { }

        public Student(string id, string name, int age, string city)
        {
            this.id = id;
            this.name = name;
            this.age = age;
            this.city = city;
        }
    }
}
