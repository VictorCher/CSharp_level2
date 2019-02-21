using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    abstract class BaseSalary
    {
        protected double salary;
        protected string name;

        protected BaseSalary(string name, double rate)
        {
            this.name = name;
        }
        public override string ToString()
        {
            return $"Имя сотрудника: {this.name.ToString()}\nСреднемесячная зарплата: {this.salary.ToString()} y.e.\n";
        }
        public double Salary => salary;
        public string Name => name;
    }
}
