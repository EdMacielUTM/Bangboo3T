using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using VO;

namespace Bangboo3T.WebServices.Bangboos
{
    /// <summary>
    /// Summary description for Customer_Service
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Customer_Service : System.Web.Services.WebService
    {


        //CREATE
        //CREATE ADDRESS TOO
        [WebMethod]
        public string CreateCustomer(VO_Customers customer)
        {
            return DAL_Customers.CreateCustomer(customer);
        }

        //READ
        //READ ADDRESS TOO
        [WebMethod]
        public List<VO_Customers> GetCustomers(params object[] parameters)
        {
            return DAL_Customers.GetCustomers(parameters);
        }

        [WebMethod]
        public List<KeyValuePair<int, string>> GetCustomerNames(params object[] parameters)
        {
            List<VO_Customers> customers = GetCustomers(parameters);

            return customers.ToDictionary(
                c => c.ID_Customer,
                c => c.FirstName + " " + c.LastName
            ).ToList();
        }

        //UPDATE
        //UPDATE ADDRESS TOO
        [WebMethod]
        public string UpdateCustomer(VO_Customers customer)
        {
            return DAL_Customers.UpdateCustomer(customer);
        }

        //DELETE
        //ADDRESS IS DELETED ON CASCADE
        [WebMethod]
        public string DeleteCustomer(int id)
        {
            return DAL_Customers.DeleteCustomer(id);
        }
    }
}