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
    public class BLL_SalesReceipts
    {

        //CREATE
        public static string CreateSalesReceipt(VO_SalesReceipts receipt)
        {
            return DAL_SalesReceipts.CreateSalesReceipt(receipt);
        }

        //READ
        //MAYBE ADD A BUTTON TO ADD A NEW BANGBOO SALE???
        public static List<VO_SalesReceipts> GetSalesReceipt(params object[] parameters)
        {
            return DAL_SalesReceipts.GetSalesReceipt(parameters);
        }

        //UPDATE
        //SHOULD NOT BE NECESSARY
        //UPDATED VIA TRIGGERS IN BANGBOOSALES

        //SOLVED: TR_CalculateTotalSale


        //DELETE
        //SHOULD NOT BE NECESSARY

    }
}
