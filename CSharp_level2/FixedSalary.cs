using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    class FixedSalary : BaseSalary
    {
        public FixedSalary(string name, double rate) : base (name, rate)
        {
            this.salary = rate;
        }
    }
}
