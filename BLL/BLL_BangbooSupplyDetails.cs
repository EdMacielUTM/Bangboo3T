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
    public class BLL_BangbooSupplyDetails
    {
        //CREATE
        //UPDATE INVENTORY ON CREATION: TR_UpdateInventoryOnSupply
        public static string CreateBangbooSupplyDetail(VO_BangbooSupplyDetails detail)
        {
            return DAL_BangbooSupplyDetails.CreateBangbooSupplyDetail(detail);
        }

        //READ
        public static List<VO_BangbooSupplyDetails> GetBangbooSupplyDetails(params object[] parameters)
        {
            return DAL_BangbooSupplyDetails.GetBangbooSupplyDetails(parameters);
        }

        //UPDATE
        //THERE'S NO NEED TO UPDATE THIS

        //DELETE
        //THERE'S NO NEED TO DELETE THIS


    }
}
