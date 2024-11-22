using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace DAL
{
    public class DAL_Addresses
    {
        //CREATE
        //CREATED ALONGSIDE EMPLOYEES, CUSTOMERS, SUPPLIERS
        public static string CreateAddress(VO_Addresses address)
        {
            string output = "";
            int response = 0;

            try
            {
                response = Data_Methods.execute_nonQuery("SP_Create_Address",
                     "@Street_Number", address.Street_Number,
                     "@City", address.City,
                     "@State", address.State,
                     "@ZipCode", address.ZipCode
                    );

                if (response != 0)
                {
                    output = "Address created successfully.";
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
        //READ ALONGSIDE EMPLOYEES, CUSTOMERS, SUPPLIERS
        public static List<VO_Addresses> GetAddresses(params object[] parameters)
        {
            List<VO_Addresses> list = new List<VO_Addresses>();

            try
            {
                DataSet ds_addresses = Data_Methods.execute_DataSet("SP_List_Addresses", parameters);

                foreach (DataRow dr in ds_addresses.Tables[0].Rows)
                {
                    list.Add(new VO_Addresses(dr));
                }

                return list;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //UPDATE
        //UPDATED ALONGSIDE EMPLOYEES, CUSTOMERS, SUPPLEIRS
        public static string UpdateAddress(VO_Addresses address)
        {
            string output = "";
            int response = 0;

            try
            {
                response = Data_Methods.execute_nonQuery("SP_Update_Address",
                    "@ID_Address", address.ID_Address,
                    "@Street_Number", address.Street_Number,
                    "@City", address.City,
                    "@State", address.State,
                    "@ZipCode", address.ZipCode
                    );

                if (response != 0)
                {
                    output = "Address updated successfully.";
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

        // DELETE --- Not needed: ON DELETE CASCADING
    }
}
