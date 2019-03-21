﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_level2_Wpf
{
    class MyWorkingWithDatabase
    {
        public string ConnectionString { get; set; }
        SqlConnection connection;
        SqlCommand command;
        public MyWorkingWithDatabase()
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
            command.CommandText = @"INSERT INTO [Employees] (Name, Department) VALUES (N'"+ name + "',N'" + department + "');";
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
        public void ReadDB()
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
            connection.Close();
        }
    }
}