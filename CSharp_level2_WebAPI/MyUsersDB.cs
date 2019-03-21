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

        public List<Employee> ReadDB()
        {
            List<Employee> employees = new List<Employee>();
            connection.Open();
            command.CommandText = @"SELECT * FROM Employees";
            SqlDataReader reader1 = command.ExecuteReader(CommandBehavior.CloseConnection);
            if (reader1.HasRows) // Если есть данные
                while (reader1.Read()) // Построчно считываем данные
                    employees.Add(new Employee{Name = reader1.GetString(0),Department = reader1.GetString(1)});
            connection.Close();
            return employees;
        }
    }
}