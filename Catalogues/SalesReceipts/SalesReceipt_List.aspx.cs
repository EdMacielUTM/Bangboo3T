using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bangboo3T.Catalogues.SalesReceipts
{
    public partial class SalesReceipt_List : System.Web.UI.Page
    {
        private Dictionary<int, string> Customers;
        private Dictionary<int, string> Employees;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Customers = BLL_Customers.GetCustomerNames();
                Employees = BLL_Employees.GetEmployeeNames();

                loadGrid();
            }
        }
        public void loadGrid()
        {
            GVReceipts.DataSource = BLL_SalesReceipts.GetSalesReceipt();

            GVReceipts.DataBind();
        }

        protected void Insert_Click(object sender, EventArgs e)
        {
            Response.Redirect("SalesReceipt_Form.aspx");
        }

        protected void GVReceipts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                //recupero el indice en funcion de aquel elemento que haya detonado el evento
                int varIndex = int.Parse(e.CommandArgument.ToString());
                //recupero el ID en funcion del indice que recuperamos anteriormente
                string id = GVReceipts.DataKeys[varIndex].Values["ID_Sale"].ToString();
                //redireccionamos al formulario de edicion, pasando como parametro el ID
                Response.Redirect($"~/Catalogues/BangbooSales/Bangboo_Sale_List.aspx?Id={id}");
            }
        }

        protected void GVReceipts_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int customerId = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Customer_ID"));
                if (Customers.TryGetValue(customerId, out string customerName))
                {
                    e.Row.Cells[2].Text = customerName;
                }
                else
                {
                    e.Row.Cells[2].Text = "Unknown Customer"; // Fallback for missing data
                }

                int employeeId = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Employee_ID"));
                if (Employees.TryGetValue(employeeId, out string employeeName))
                {
                    e.Row.Cells[3].Text = employeeName;
                }
                else
                {
                    e.Row.Cells[3].Text = "Unknown Employee"; // Fallback for missing data
                }
            }
        }

    }
}