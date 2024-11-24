using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Transportes3Capas.utilidades;
using VO;

namespace Bangboo3T.Catalogues.SalesReceipts
{
    public partial class SalesReceipt_Form : System.Web.UI.Page
    {
        private Dictionary<int, string> Customers;
        private Dictionary<int, string> Employees;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Customers = BLL_Customers.GetCustomerNames();
                Employees = BLL_Employees.GetEmployeeNames();

                load_DDL();

                Title_.Text = "Enter Customer and Employee data.";
            }
        }

        private void load_DDL()
        {
            ListItem ddlCustomers_I = new ListItem("Select a Customer", "0");
            List<VO_Customers> list_customers = BLL_Customers.GetCustomers();
            if (list_customers.Count > 0)
            {
                foreach (var customer in list_customers)
                {
                    ListItem customerItem = new ListItem(
                            (customer.FirstName + " " + customer.LastName + " | " + customer.PhoneNumber + " | " + customer.Email),
                            customer.ID_Customer.ToString()
                        );
                    ddlCustomer.Items.Add(customerItem);
                }
                ddlCustomer.SelectedIndex = 0;
            }

            ListItem ddlEmployees_I = new ListItem("Select an Employee", "0");
            List<VO_Employees> list_employees = BLL_Employees.GetEmployees();
            if (list_employees.Count > 0)
            {
                foreach (var employee in list_employees)
                {
                    ListItem employeeItem = new ListItem(
                            (employee.FirstName + " " + employee.LastName + " | " + employee.PhoneNumber + " | " + employee.Email),
                            employee.ID_Employee.ToString()
                        );
                    ddlEmployee.Items.Add(employeeItem);
                }
                ddlEmployee.SelectedIndex = 0;
            }
        }

        protected void btnReceipt_Click(object sender, EventArgs e)
        {
            int _customerid = int.Parse(ddlCustomer.SelectedValue);
            VO_Customers _customer = BLL_Customers.GetCustomers("@ID_Customer", _customerid)[0];

            int _employeeid = int.Parse(ddlEmployee.SelectedValue);
            VO_Employees _employee = BLL_Employees.GetEmployees("@ID_Employee", _employeeid)[0];

            VO_SalesReceipts _receipt = new VO_SalesReceipts();

            string title, message, type, response;

            try
            {
                _receipt.Customer_ID = int.Parse(ddlCustomer.SelectedValue);
                _receipt.Employee_ID = int.Parse(ddlEmployee.SelectedValue);
                _receipt.SaleDate = "";
                _receipt.TotalAmount = 0;

                response = BLL_SalesReceipts.CreateSalesReceipt(_receipt);

                if (response.ToUpper().Contains("ERROR"))
                {
                    title = "Error";
                    message = response;
                    type = "error";

                    SweetAlert.Sweet_Alert(title, message, type, this.Page, this.GetType());
                }
                else
                {
                    title = "Ok!";
                    message = response;
                    type = "success";

                    SweetAlert.Sweet_Alert(title, message, type, this.Page, this.GetType(), "/Catalogues/SalesReceipts/SalesReceipt_List.aspx");

                }
            }
            catch (Exception ex)
            {
                title = "Error";
                message = ex.Message;
                type = "error";

                SweetAlert.Sweet_Alert(title, message, type, this.Page, this.GetType());
            }

        }
    }
}