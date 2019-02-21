using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    class HourlySalary : BaseSalary
    {
        public HourlySalary(string name, double rate) : base(name, rate)
        {
            this.salary = 20.8 * 8 * rate;
        }
    }
}
