using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONET
{
     public class Program
    {
        static void Main(string[] args)
        {
         EmployeePayRoll model=new EmployeePayRoll();
           

            model.Name = "Vishu";
            model.id = 11;
                   
            //  EmployeeRepository.AddEmployee(model);
            EmployeeRepository.DeleteEmployee(model);
            //EmployeeRepository.GetAllEmployees();


            Console.ReadLine();

        }
    }
}
