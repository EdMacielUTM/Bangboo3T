using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace BLL
{
    public class BLL_Employees
    {
        //CREATE
        //TRIGGER ADDRESS TOO
        public static string CreateEmployee(VO_Employees employee)
        {
            return DAL_Employees.CreateEmployee(employee);
        }

        //READ
        //READ ADDRESS TOO
        public static List<VO_Employees> GetEmployees(params object[] parameters)
        {
            return DAL_Employees.GetEmployees(parameters);
        }

        //UPDATE
        //UPDATE ADDRESS TOO
        public static string UpdateEmployee(VO_Employees employee)
        {
            return DAL_Employees.UpdateEmployee(employee);
        }

        //DELETE
        //ADDRESS IS DELETED ON CASCADE
        public static string DeleteEmployee(int id)
        {
            return DAL_Employees.DeleteEmployee(id);
        }

    }
}
