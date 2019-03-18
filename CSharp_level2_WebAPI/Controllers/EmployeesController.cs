using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CSharp_level2_WebAPI.Models;

namespace CSharp_level2_WebAPI.Controllers
{
    public class EmployeesController : ApiController
    {
        Employee[] employees = new Employee[] 
        {
            new Employee {Name = "Василий", Department = "OTK" },
            new Employee {Name = "Пётр", Department = "Отдел кадров" },
            new Employee {Name = "Пётр", Department = "ИТ" },
        };
        public IEnumerable<Employee> GetAllItem()
        {
            return employees;
        }
        public IHttpActionResult GetItem(string id)
        {
            //var mans = employees.FirstOrDefault((p) => p.Name == id);
            List<Employee> mans = new List<Employee>();
            foreach (var s in employees)
                if (s.Name == id)
                    mans.Add(new Employee { Name = s.Name, Department = s.Department });
            //if(mans == null) return NotFound();
            return Ok(mans);
        }
        /*public HttpResponseMessage GetBooks(int id)
        {
            return Ok(employees[id].Name);
        }*/
    }
}
