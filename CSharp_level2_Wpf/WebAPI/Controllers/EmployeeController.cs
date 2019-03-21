using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class EmployeeController : ApiController
    {
        //string ConnectionString { get; set; }
        //SqlConnection connection;
        //SqlCommand command;
        List<Employee> employees;
        /*public EmployeeController()
        {
            ConnectionString = @"Data Source=(localdb)\mssqllocaldb;
                                        Initial Catalog=lesson7;
                                        Integrated Security=True;
                                        Pooling=True";
            connection = new SqlConnection(ConnectionString);
            command = new SqlCommand();
            command.Connection = connection;
        }
        public void UpdateDB(string name, string department)
        {
            connection.Open();
            command.CommandText = @"UPDATE Employees SET Department = N'" + department + "' WHERE Name = N'" + name + "';";
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void InsertDB(string name, string department)
        {
            connection.Open();
            command.CommandText = @"INSERT INTO [Employees] (Name, Department) VALUES (N'" + name + "',N'" + department + "');";
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void InsertDB(string department)
        {
            connection.Open();
            command.CommandText = @"INSERT INTO [Departments] (Department) VALUES (N'" + department + "');";
            command.ExecuteNonQuery();
            connection.Close();
        }
        */
        public IEnumerable<Employee> GetAllItem()
        {
            //List<Employee> employees;
            string ConnectionString = @"Data Source=(localdb)\mssqllocaldb;
                                        Initial Catalog=lesson7;
                                        Integrated Security=True;
                                        Pooling=True";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                connection.Open();
                command.CommandText = @"SELECT * FROM Employees";
                //var a = command.ExecuteScalar();
                //var b = command.ExecuteScalar();
                //var reader4 = command.ExecuteReader();
                SqlDataReader reader3 = command.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader3.HasRows) // Если есть данные
                {
                    //employees?.Clear();
                    while (reader3.Read()) // Построчно считываем данные
                        this.employees.Add(new Employee { name = reader3.GetString(0), department = reader3.GetString(1) });
                }
                connection.Close();
            }
            return this.employees;
        }
        public IHttpActionResult GetItem(string id)
        {
            //var mans = employees.FirstOrDefault((p) => p.Name == id);
            List<Employee> mans = new List<Employee>();
            foreach (var s in employees)
                if (s.name == id || s.department == id)
                    mans.Add(new Employee { name = s.name, department = s.department });
            //if(mans == null) return NotFound();
            return Ok(mans);
        }
        /*public void ReadDB()
        {
            connection.Open();
            command.CommandText = @"SELECT * FROM Departments";
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            if (reader.HasRows) // Если есть данные
            {
                while (reader.Read()) // Построчно считываем данные
                {
                    Console.WriteLine(reader.GetString(0));
                    MainWindow.department.Add(reader.GetString(0));
                }
            }
            connection.Close();
            connection.Open();
            command.CommandText = @"SELECT * FROM Employees";
            SqlDataReader reader1 = command.ExecuteReader(CommandBehavior.CloseConnection);
            if (reader1.HasRows) // Если есть данные
            {
                while (reader1.Read()) // Построчно считываем данные
                {
                    Console.WriteLine(reader1.GetString(0));
                    MainWindow.employee.Add(new Employee(reader1.GetString(0), reader1.GetString(1)));
                    Console.WriteLine(reader1.GetString(1));
                }
            }
            connection.Close();*/
    }
}