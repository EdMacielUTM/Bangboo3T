using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace DAL
{
    public class DAL_SalesReceipts
    {

        //CREATE
        public static string CreateSalesReceipt(VO_SalesReceipts receipt)
        {
            string output = "";
            int response = 0;

            try
            {
                response = Data_Methods.execute_nonQuery("SP_Create_SalesReceipt",
                    "@SaleDate", receipt.SaleDate,
                    "@Employee_ID", receipt.Employee_ID,
                    "@Customer_ID", receipt.Customer_ID,
                    "@TotalAmount", receipt.TotalAmount
                );

                if (response != 0)
                {
                    output = "Bangboo Sale receipt created successfully.";
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
        //MAYBE ADD A BUTTON TO ADD A NEW BANGBOO SALE???
        public static List<VO_SalesReceipts> GetSalesReceipt(params object[] parameters)
        {
            List<VO_SalesReceipts> list = new List<VO_SalesReceipts>();

            try
            {
                DataSet ds_receipts = Data_Methods.execute_DataSet("SP_List_SalesReceipts", parameters);

                foreach (DataRow dr in ds_receipts.Tables[0].Rows)
                {
                    list.Add(new VO_SalesReceipts(dr));
                }

                return list;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //UPDATE
        //SHOULD NOT BE NECESSARY
        //UPDATED VIA TRIGGERS IN BANGBOOSALES
        

        //DELETE
        //SHOULD NOT BE NECESSARY

    }
}
