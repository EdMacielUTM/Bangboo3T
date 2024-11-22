using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace DAL
{
    public class DAL_BangbooSupplyDetails
    {

        //CREATE
        //UPDATE INVENTORY ON CREATION
        public static string CreateBangbooSupplyDetail(VO_BangbooSupplyDetails detail)
        {
            string output = "";
            int response = 0;

            try
            {
                response = Data_Methods.execute_nonQuery("SP_Create_BangbooSupplyDetail",
                    "@ID_Bangboo", detail.ID_Bangboo,
                    "@ID_Supplier", detail.ID_Supplier,
                    "@SupplyAmount", detail.SupplyAmount,
                    "@SupplyDate", detail.SupplyDate,
                    "@UnitCost", detail.UnitCost
                    );

                if (response != 0)
                {
                    output = "Bangboo supply log created successfully.";
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
        public static List<VO_BangbooSupplyDetails> GetBangbooSupplyDetails(params object[] parameters)
        {
            List<VO_BangbooSupplyDetails> list = new List<VO_BangbooSupplyDetails>();

            try
            {
                DataSet ds_details = Data_Methods.execute_DataSet("SP_List_BangbooSupplyDetails", parameters);

                foreach (DataRow dr in ds_details.Tables[0].Rows)
                {
                    list.Add(new VO_BangbooSupplyDetails(dr));
                }

                return list;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //UPDATE
        //THERE'S NO NEED TO UPDATE THIS

        //DELETE
        //THERE'S NO NEED TO DELETE THIS
        

    }
}
