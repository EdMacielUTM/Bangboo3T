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
    /// Summary description for Address_Service
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Address_Service : System.Web.Services.WebService
    {

        //CREATE
        [WebMethod]
        public string CreateAddress(VO_Addresses address)
        {
            return DAL_Addresses.CreateAddress(address);
        }

        //READ
        [WebMethod]
        public List<VO_Addresses> GetAddresses(params object[] parameters)
        {
            return DAL_Addresses.GetAddresses(parameters);
        }

        [WebMethod]
        public List<KeyValuePair<int, string>> GetFullAddresses(params object[] parameters)
        {
            List<VO_Addresses> addresses = GetAddresses(parameters);

            return addresses.ToDictionary(
                c => c.ID_Address,
                c => c.Street_Number + "\n" + c.City + ", " + c.State + " " + c.ZipCode
            ).ToList();
        }

        //UPDATE
        [WebMethod]
        public string UpdateAddress(VO_Addresses address)
        {
            return DAL_Addresses.UpdateAddress(address);
        }

    }
}
