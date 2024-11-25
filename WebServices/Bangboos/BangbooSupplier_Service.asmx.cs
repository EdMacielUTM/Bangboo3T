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
    /// Summary description for BangbooSupplier_Service
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class BangbooSupplier_Service : System.Web.Services.WebService
    {


        //CREATE
        //ADDRESS IS CREATED ON SUPPLIER CREATION
        [WebMethod]
        public string CreateBangbooSupplier(VO_BangbooSuppliers supplier)
        {
            return DAL_BangbooSuppliers.CreateBangbooSupplier(supplier);
        }

        //READ
        //ADDRESS IS READ TOO
        [WebMethod]
        public List<VO_BangbooSuppliers> GetBangbooSuppliers(params object[] parameters)
        {
            return DAL_BangbooSuppliers.GetBangbooSuppliers(parameters);
        }

        //UPDATE
        //ADDRESS IS UPDATED TOO
        [WebMethod]
        public string UpdateBangbooSupplier(VO_BangbooSuppliers supplier)
        {
            return DAL_BangbooSuppliers.UpdateBangbooSupplier(supplier);
        }

        //DELETE
        //ADDRESS IS DELETED TOO
        [WebMethod]
        public string DeleteSupplier(int id)
        {
            return DAL_BangbooSuppliers.DeleteSupplier(id);
        }

    }
}
