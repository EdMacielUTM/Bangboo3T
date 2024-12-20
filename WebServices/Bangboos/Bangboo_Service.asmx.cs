﻿using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using VO;

namespace Bangboo3T.WebServices.Bangboos
{
    /// <summary>
    /// Summary description for Bangboo_Service
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Bangboo_Service : System.Web.Services.WebService
    {

        //CREATE
        [WebMethod]
        public string CreateBangboo(VO_Bangboos bangboo)
        {
            return DAL_Bangboos.CreateBangboo(bangboo);
        }

        //READ
        [WebMethod]
        public List<VO_Bangboos> GetBangboos(params object[] parameters)
        {
            return DAL_Bangboos.GetBangboos(parameters);
        }
        //UPDATE
        [WebMethod]
        public string UpdateBangboo(VO_Bangboos bangboo)
        {
            return DAL_Bangboos.UpdateBangboo(bangboo);
        }

        //DELETE
        //TR_PreventBangbooDeletion
        [WebMethod]
        public string DeleteBangboo(int id)
        {
            return DAL_Bangboos.DeleteBangboo(id);
        }
    }
}
