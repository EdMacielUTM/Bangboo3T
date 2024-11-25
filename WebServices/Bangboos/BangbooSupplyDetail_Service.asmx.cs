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
    /// Summary description for BangbooSupplyDetail_Service
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class BangbooSupplyDetail_Service : System.Web.Services.WebService
    {


        //CREATE
        //UPDATE INVENTORY ON CREATION: TR_UpdateInventoryOnSupply
        [WebMethod]
        public string CreateBangbooSupplyDetail(VO_BangbooSupplyDetails detail)
        {
            return DAL_BangbooSupplyDetails.CreateBangbooSupplyDetail(detail);
        }

        //READ
        [WebMethod]
        public List<VO_BangbooSupplyDetails> GetBangbooSupplyDetails(params object[] parameters)
        {
            return DAL_BangbooSupplyDetails.GetBangbooSupplyDetails(parameters);
        }
    }
}
