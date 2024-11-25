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
    /// Summary description for SalesReceipt_Service
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class SalesReceipt_Service : System.Web.Services.WebService
    {


        //CREATE
        [WebMethod]
        public string CreateSalesReceipt(VO_SalesReceipts receipt)
        {
            return DAL_SalesReceipts.CreateSalesReceipt(receipt);
        }

        //READ
        //MAYBE ADD A BUTTON TO ADD A NEW BANGBOO SALE???
        [WebMethod]
        public List<VO_SalesReceipts> GetSalesReceipt(params object[] parameters)
        {
            return DAL_SalesReceipts.GetSalesReceipt(parameters);
        }

    }
}
