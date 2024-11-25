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
    /// Summary description for BangbooSale_Service
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class BangbooSale_Service : System.Web.Services.WebService
    {


        //CREATE
        //UPDATE RECEIPT, INVENTORY ON CREATION
        //TR_CalculateTotalSale, TR_DecrementInventoryOnSale
        [WebMethod]
        public string CreateBangbooSale(VO_BangbooSales bangboo_sale)
        {
            return DAL_BangbooSales.CreateBangbooSale(bangboo_sale);
        }

        //READ
        //READ ON RECEIPTS LIST
        [WebMethod]
        public List<VO_BangbooSales> GetBangbooSales(params object[] parameters)
        {
            return DAL_BangbooSales.GetBangbooSales(parameters);
        }

    }
}
