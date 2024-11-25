using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace DAL
{
    public class DAL_Customers
    {
        //CREATE
        //CREATE ADDRESS TOO
        public static string CreateCustomer(VO_Customers customer)
        {
            string output = "";
            int response = 0;

            try
            {
                response = Data_Methods.execute_nonQuery("SP_Create_Customer",
                    "@FirstName", customer.FirstName,
                    "@LastName", customer.LastName,
                    "@PhoneNumber", customer.PhoneNumber,
                    "@Email", customer.Email,
                    "@Address_ID", customer.Address_ID
                    );

                if (response != 0)
                {
                    output = "Customer created successfully.";
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
        //READ ADDRESS TOO
        public static List<VO_Customers> GetCustomers(params object[] parameters)
        {
            List<VO_Customers> list = new List<VO_Customers>();

            try
            {
                DataSet ds_customers = Data_Methods.execute_DataSet("SP_List_Customers", parameters);

                foreach (DataRow dr in ds_customers.Tables[0].Rows)
                {
                    list.Add(new VO_Customers(dr));
                }

                return list;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //UPDATE
        //UPDATE ADDRESS TOO
        public static string UpdateCustomer(VO_Customers customer)
        {
            string output = "";
            int response = 0;

            try
            {
                response = Data_Methods.execute_nonQuery("SP_Update_Customer",
                    "@ID_Customer", customer.ID_Customer,
                    "@FirstName", customer.FirstName,
                    "@LastName", customer.LastName,
                    "@PhoneNumber", customer.PhoneNumber,
                    "@Email", customer.Email,
                    "@Address_ID", customer.Address_ID
                    );

                if (response != 0)
                {
                    output = "Customer updated successfully.";
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
        //ADDRESS IS DELETED ON CASCADE
        public static string DeleteCustomer(int id)
        {
            string output = "";
            int response = 0;

            try
            {
                response = Data_Methods.execute_nonQuery("SP_Delete_Customer", "@ID_Customer", id);

                if (response != 0)
                {
                    output = "Customer deleted successfully.";
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
