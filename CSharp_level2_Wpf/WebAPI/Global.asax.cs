using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using System.Data;
using System.Data.SqlClient;
using WebAPI.Models;


namespace WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        List<Employee> employees;
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
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
        }
    }
}
