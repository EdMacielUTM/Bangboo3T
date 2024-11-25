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
    /// Summary description for Employee_Service
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Employee_Service : System.Web.Services.WebService
    {

        //CREATE
        //TRIGGER ADDRESS TOO
        [WebMethod]
        public string CreateEmployee(VO_Employees employee)
        {
            return DAL_Employees.CreateEmployee(employee);
        }

        //READ
        //READ ADDRESS TOO
        [WebMethod]
        public List<VO_Employees> GetEmployees(params object[] parameters)
        {
            return DAL_Employees.GetEmployees(parameters);
        }

        [WebMethod]
        public List<KeyValuePair<int, string>> GetEmployeeNames(params object[] parameters)
        {
            List<VO_Employees> employees = GetEmployees(parameters);

            return employees.ToDictionary(
                c => c.ID_Employee,
                c => c.FirstName + " " + c.LastName
            ).ToList();
        }

        //UPDATE
        //UPDATE ADDRESS TOO
        [WebMethod]
        public string UpdateEmployee(VO_Employees employee)
        {
            return DAL_Employees.UpdateEmployee(employee);
        }

        //DELETE
        //ADDRESS IS DELETED ON CASCADE
        [WebMethod]
        public string DeleteEmployee(int id)
        {
            return DAL_Employees.DeleteEmployee(id);
        }
    }
}
