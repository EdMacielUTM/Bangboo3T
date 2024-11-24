using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace DAL
{
    public class DAL_BangbooSales
    {
        //CREATE
        //UPDATE RECEIPT, INVENTORY ON CREATION
        public static string CreateBangbooSale(VO_BangbooSales bangboo_sale)
        {
            string output = "";
            int response = 0;

            try
            {
                response = Data_Methods.execute_nonQuery("SP_Create_BangbooSale",
                    "@Bangboo_ID", bangboo_sale.Bangboo_ID,
                    "@SalesReceipt_ID", bangboo_sale.SalesReceipt_ID,
                    "@Quantity", bangboo_sale.Quantity
                    );

                if (response != 0)
                {
                    output = "Bangboo Sale (item) logged successfully.";
                }
                else
                {
                    output = "An error has occurred.";
                }
            }
            catch (Exception ex)
            {
                output = $"Error: {ex.Message}";
            }

            return output;
        }

        //READ
        //READ ON RECEIPTS LIST
        public static List<VO_BangbooSales> GetBangbooSales(params object[] parameters)
        {
            List<VO_BangbooSales> list = new List<VO_BangbooSales>();

            try
            {
                DataSet ds_bangboos = Data_Methods.execute_DataSet("SP_List_BangbooSales", parameters);
                // REAL TALK
                //Not sure how I'm handling this, but I'd rather come here from "/Caatalogues/BangbooSalesReceipts/Receipts_List" through "Details" or something

                // ALTERNATIVE:
                // List ALL BangbooSales related to the Receipt RIGHT UNDER IT, making it a sub-list
                // I can't be assed to make a dynamic list though, so it's gonna go in raw with no real Hide/Show function
                foreach (DataRow dr in ds_bangboos.Tables[0].Rows)
                {
                    list.Add(new VO_BangbooSales(dr));
                }

                return list;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //UPDATE
        //NO NEED TO UPDATE THIS


        //DELETE
        //NO NEED TO DELETE THIS


    }
}
