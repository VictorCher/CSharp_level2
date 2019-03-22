using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using CSharp_level2_WebAPI.Models;

namespace CSharp_level2_WebAPI
{
    public class MyUsersDB
    {
        string ConnectionString;
        SqlConnection connection;
        SqlCommand command;

        public MyUsersDB()
        {
            ConnectionString = @"Data Source=(localdb)\mssqllocaldb;
                                        Initial Catalog=lesson7;
                                        Integrated Security=True;
                                        Pooling=True";
            connection = new SqlConnection(ConnectionString);
            command = new SqlCommand();
            command.Connection = connection;
        }

        public List<Employee> ReadEmployee()
        {
            List<Employee> employees = new List<Employee>();
            connection.Open();
            command.CommandText = @"SELECT * FROM Employees";
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            if (reader.HasRows) // Если есть данные
                while (reader.Read()) // Построчно считываем данные
                    employees.Add(new Employee{Name = reader.GetString(0),Department = reader.GetString(1)});
            connection.Close();
            return employees;
        }

        public List<Departments> ReadDepartment()
        {
            List<Departments> departments = new List<Departments>();
            connection.Open();
            command.CommandText = @"SELECT * FROM Departments";
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            if (reader.HasRows) // Если есть данные
                while (reader.Read()) // Построчно считываем данные
                    departments.Add(new Departments { Department = reader.GetString(0) });
            connection.Close();
            return departments;
        }
    }
}