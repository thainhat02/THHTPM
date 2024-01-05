using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Lab01.Models;
using System.Data.Entity;

namespace Lab01.Controllers
{
    public class EmployeeController : ApiController
    {
        Model1 data = new Model1();
        [HttpGet]
        public List<Employee> LayToanBoDS()
        {
            List<Employee> ds = data.Employees.ToList();
            foreach(Employee e in ds)
            {
                e.Department = null;
            }
            return ds;
        }  
        [HttpGet]
        public Employee ChiTiet(int id)
        {
            Employee e = data.Employees.First(x => x.eid == id);
            if (e != null)
            {
                e.Department = null;
            }
            return e;

        }
        [HttpGet]
        public List<Employee>DSSP(int madm)
        {
            List<Employee> li = data.Employees.Where(x => x.deptid == madm).ToList();
            foreach(Employee e in li)
            {
                e.Department = null;
            }
            return li;
        }
        [HttpGet]
        public List<Employee>TKByPrice(int a, int b)
        {
            List<Employee> li = data.Employees.Where(x => x.salary >= a && x.salary <= b).ToList();
            foreach(Employee e in li)
            {
                e.Department = null;
            }
            return li;
        }
    }
}
