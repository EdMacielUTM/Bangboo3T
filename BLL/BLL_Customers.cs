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
    public class BLL_Customers
    {
        //CREATE
        //CREATE ADDRESS TOO
        public static string CreateCustomer(VO_Customers customer)
        {
            return DAL_Customers.CreateCustomer(customer);
        }

        //READ
        //READ ADDRESS TOO
        public static List<VO_Customers> GetCustomers(params object[] parameters)
        {
            return DAL_Customers.GetCustomers(parameters);
        }

        public static Dictionary<int, string> GetCustomerNames(params object[] parameters)
        {
            List<VO_Customers> customers = GetCustomers(parameters);

            return customers.ToDictionary(
                c => c.ID_Customer,
                c => c.FirstName + " " + c.LastName
            ); 
        }

        //UPDATE
        //UPDATE ADDRESS TOO
        public static string UpdateCustomer(VO_Customers customer)
        {
            return DAL_Customers.UpdateCustomer(customer);
        }

        //DELETE
        //ADDRESS IS DELETED ON CASCADE
        public static string DeleteCustomer(int id)
        {
            return DAL_Customers.DeleteCustomer(id);
        }
    }
}
