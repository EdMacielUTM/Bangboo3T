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
    public class BLL_BangbooSales
    {
        //CREATE
        //UPDATE RECEIPT, INVENTORY ON CREATION
        //TR_CalculateTotalSale, TR_DecrementInventoryOnSale
        public static string CreateBangbooSale(VO_BangbooSales bangboo_sale)
        {
            return DAL_BangbooSales.CreateBangbooSale(bangboo_sale);
        }

        //READ
        //READ ON RECEIPTS LIST
        public static List<VO_BangbooSales> GetBangbooSales(params object[] parameters)
        {
            return DAL_BangbooSales.GetBangbooSales(parameters);
        }

        //UPDATE
        //NO NEED TO UPDATE THIS


        //DELETE
        //NO NEED TO DELETE THIS


    }
}
