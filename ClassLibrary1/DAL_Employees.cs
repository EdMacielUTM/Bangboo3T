using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace DAL
{
    public class DAL_Employees
    {
        //CREATE
        //TRIGGER ADDRESS TOO
        public static string CreateEmployee(VO_Employees employee)
        {
            string output = "";
            int response = 0;

            try
            {
                response = Data_Methods.execute_nonQuery("SP_Create_Employee",
                    "@FirstName", employee.FirstName,
                    "@LastName", employee.LastName,
                    "@PhoneNumber", employee.PhoneNumber,
                    "@Email", employee.Email,
                    "@HireDate", employee.HireDate,
                    "@Salary", employee.Salary,
                    "@Address_ID", employee.Address_ID
                    );

                if (response != 0)
                {
                    output = "Employee created successfully.";
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
        public static List<VO_Employees> GetEmployees(params object[] parameters)
        {
            List<VO_Employees> list = new List<VO_Employees>();

            try
            {
                DataSet ds_employees = Data_Methods.execute_DataSet("SP_List_Employees", parameters);

                foreach (DataRow dr in ds_employees.Tables[0].Rows)
                {
                    list.Add(new VO_Employees(dr));
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
        public static string UpdateEmployee (VO_Employees employee)
        {
            string output = "";
            int response = 0;

            try
            {
                response = Data_Methods.execute_nonQuery("SP_Update_Employee",
                    "@ID_Employee", employee.ID_Employee,
                    "@FirstName", employee.FirstName,
                    "@LastName", employee.LastName,
                    "@PhoneNumber", employee.PhoneNumber,
                    "@Email", employee.Email,
                    "@HireDate", employee.HireDate,
                    "@Salary", employee.Salary,
                    "@Address_ID", employee.Address_ID
                    );

                if (response != 0)
                {
                    output = "Employee updated successfully.";
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
        public static string DeleteEmployee(int id)
        {
            string output = "";
            int response = 0;

            try
            {
                response = Data_Methods.execute_nonQuery("SP_Delete_Employee", "@ID_Employee", id);

                if (response != 0)
                {
                    output = "Employee deleted successfully.";
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
