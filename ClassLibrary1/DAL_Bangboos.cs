using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using VO;

namespace DAL
{
    public class DAL_Bangboos
    {
        //CREATE
        //CREATE INVENTORY ENTRY ALONGSIDE BANGBOO CREATION
        public static string CreateBangboo(VO_Bangboos bangboo)
        {
            string output = "";
            int response = 0;

            try
            {
                response = Data_Methods.execute_nonQuery("SP_Create_Bangboo",
                    "@Name", bangboo.Name,
                    "@Element", bangboo.Element,
                    "@Rank", bangboo.Rank,
                    "@Model", bangboo.Model,
                    "@PictureURL", bangboo.PictureURL,
                    "@Price", bangboo.Price
                    );

                if (response != 0)
                {
                    output = "Bangboo created successfully.";
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
        public static List<VO_Bangboos> GetBangboos(params object[] parameters)
        {
            List<VO_Bangboos> list = new List<VO_Bangboos>();

            try
            {
                DataSet ds_bangboos = Data_Methods.execute_DataSet("SP_List_Bangboos", parameters);

                foreach (DataRow dr in ds_bangboos.Tables[0].Rows)
                {
                    list.Add(new VO_Bangboos(dr));
                }

                return list;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //UPDATE
        public static string UpdateBangboo(VO_Bangboos bangboo)
        {
            string output = "";
            int response = 0;

            try
            {
                response = Data_Methods.execute_nonQuery("SP_Update_Bangboo",
                    "@ID_Bangboo", bangboo.ID_Bangboo,
                    "@Name", bangboo.Name,
                    "@Element", bangboo.Element,
                    "@Rank", bangboo.Rank,
                    "@Model", bangboo.Model,
                    "@PictureURL", bangboo.PictureURL,
                    "@Price", bangboo.Price
                    );

                if (response != 0)
                {
                    output = "Bangboo updated successfully.";
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

        //DELETE
        //DELETE LOCKED BEHIND INVENTORY, INVENTORY QTY MUST BE 0 IN ORDER TO ALLOW DELETION, INVENTORY ENTRY DELETED ALONGSIDE BANGBOO
        //SOLVED: TR_PreventBangbooDeletion
        public static string DeleteBangboo(int id)
        {
            string output = "";
            int response = 0;

            try
            {
                response = Data_Methods.execute_nonQuery("SP_Delete_Bangboo", "@ID_Bangboo", id);

                if (response != 0)
                {
                    output = "Bangboo deleted successfully.";
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

    }
}
