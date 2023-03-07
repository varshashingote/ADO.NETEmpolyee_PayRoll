using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONET
{
    public class EmployeePayRoll
    {
        public string Name { get; set; }
        public int id { get; set; }
        public string Basic_Pay { get; set; }
        public DateTime StartDate { get; set; }
        public string Gender { get; set; }
        public int Phone_Number { get; set; }
        public string Emp_DEPT { get; set; }
        public string Emp_Address { get; set; }
        public float Taxable_Pay { get; set; }
        public float Deduction { get; set; }
        public float Net_Pay { get; set; }
        public float Income_Tax { get; set; }

    }
}
