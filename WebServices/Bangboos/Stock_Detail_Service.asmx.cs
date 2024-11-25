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
    /// Summary description for Stock_Detail_Service
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Stock_Detail_Service : System.Web.Services.WebService
    {

        [WebMethod]
        public List<VO_Stock_Details> GetStockDetails(params object[] parameters)
        {
            return DAL_Stock_Details.GetStockDetails(parameters);
        }
    }
}
