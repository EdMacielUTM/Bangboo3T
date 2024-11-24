using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace DAL
{
    public class DAL_BangbooSuppliers
    {
        //CREATE
        //ADDRESS IS CREATED ON SUPPLIER CREATION
        public static string CreateBangbooSupplier(VO_BangbooSuppliers supplier)
        {
            string output = "";
            int response = 0;

            try
            {
                response = Data_Methods.execute_nonQuery("SP_Create_BangbooSupplier",
                    "@ID_Supplier", supplier.ID_Supplier,
                    "@Name", supplier.Name,
                    "@Email", supplier.Email,
                    "@Phone", supplier.Phone
                    );

                if (response != 0)
                {
                    output = "Bangboo Supplier created successfully.";
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
        //ADDRESS IS READ TOO
        public static List<VO_BangbooSuppliers> GetBangbooSuppliers(params object[] parameters)
        {
            List<VO_BangbooSuppliers> list = new List<VO_BangbooSuppliers>();

            try
            {
                DataSet ds_suppliers = Data_Methods.execute_DataSet("SP_List_BangbooSuppliers", parameters);

                foreach (DataRow dr in ds_suppliers.Tables[0].Rows)
                {
                    list.Add(new VO_BangbooSuppliers(dr));
                }

                return list;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //UPDATE
        //ADDRESS IS UPDATED TOO
        public static string UpdateBangbooSupplier(VO_BangbooSuppliers supplier)
        {
            string output = "";
            int response = 0;

            try
            {
                response = Data_Methods.execute_nonQuery("SP_Update_Bangboo",
                    "@ID_Supplier", supplier.ID_Supplier,
                    "@Name", supplier.Name,
                    "@Email", supplier.Email,
                    "@Phone", supplier.Phone,
                    "@Address_ID", supplier.Address_ID
                    );
                // REAL TALK
                //Address might need t o be updated in a follow-up call right here
                //Instead of asking for Address ID, just send the Address data and let it get updated via ID reference

                if (response != 0)
                {
                    output = "Bangboo Supplier updated successfully.";
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
        public static string DeleteSupplier(int id)
        {
            string output = "";
            int response = 0;

            try
            {
                response = Data_Methods.execute_nonQuery("SP_Delete_Supplier", "@ID_Supplier", id);

                if (response != 0)
                {
                    output = "Supplier deleted successfully.";
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
