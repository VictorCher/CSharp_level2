using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CSharp_level2_WebAPI.Models;

namespace CSharp_level2_WebAPI.Controllers
{
    public class DepartmentsController : ApiController
    {
        public IEnumerable<Departments> GetAllDepartments()
        {
            return new MyUsersDB().ReadDepartment();
        }
        public IHttpActionResult GetDepartment(string id)
        {
            List<Departments> employees = new MyUsersDB().ReadDepartment();
            List<Departments> temp = new List<Departments>();
            foreach (var s in employees)
                if (s.Department == id)
                    temp.Add(new Departments { Department = s.Department });
            return Ok(temp);
        }
    }
}
