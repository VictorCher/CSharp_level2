using System;
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
        public void UpdateDB(string department)
        {
            connection.Open();
            command.CommandText = @"UPDATE Departments SET Department = @Department";
            command.Parameters.Add("@Department", SqlDbType.NVarChar, -1, department);
            
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
            /*SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataSet ds = new DataSet();
            adapter.Fill(ds);*/
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
            // перебор всех таблиц
            /*foreach (DataTable dt in ds.Tables)
            {
                // перебор всех строк таблицы
                foreach (DataRow row in dt.Rows)
                {
                    // получаем все ячейки строки
                    var cells = row.ItemArray;
                    //if (dt.TableName == "Departments")
                    //{
                        MainWindow.department.Add(cells[0] as string);
                    //}
                    if (dt.TableName == "Employee")
                    {
                        MainWindow.employee.Add(new Employee(cells[0] as string, cells[1] as string));
                    }
                }
            }*/
        }
    }
}
