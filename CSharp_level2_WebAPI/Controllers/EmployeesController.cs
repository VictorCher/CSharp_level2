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
        public IEnumerable<Employee> GetAllEmployees()
        {
            return new MyUsersDB().ReadEmployee();
        }

        public IHttpActionResult GetEmployee(string id)
        {
            List<Employee> employees = new MyUsersDB().ReadEmployee();
            List<Employee> temp = new List<Employee>();
            foreach (var s in employees)
                if (s.Name == id || s.Department == id)
                    temp.Add(new Employee { Name = s.Name, Department = s.Department });
            return Ok(temp);
        }
    }
}
