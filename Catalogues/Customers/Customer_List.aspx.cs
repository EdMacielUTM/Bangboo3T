using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Transportes3Capas.utilidades;

namespace Bangboo3T.Catalogues.Customers
{
    public partial class Customer_List : System.Web.UI.Page
    {
        private Dictionary<int, string> Addresses;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Addresses = BLL_Addresses.GetFullAddresses();

                loadGrid();
            }
        }

        public void loadGrid()
        {
            GVCustomers.DataSource = BLL_Customers.GetCustomers();

            GVCustomers.DataBind();
        }

        protected void Insert_Click(object sender, EventArgs e)
        {
            Response.Redirect("Customer_Form.aspx");
        }

        protected void GVCustomers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int idCustomer = int.Parse(GVCustomers.DataKeys[e.RowIndex].Values["ID_Customer"].ToString());

            string response = BLL_Customers.DeleteCustomer(idCustomer);

            string title, msg, type;
            if (response.ToUpper().Contains("ERROR"))
            {
                title = "Oops...";
                msg = response;
                type = "error";
            }
            else
            {
                title = "Success!";
                msg = response;
                type = "success";
            }

            SweetAlert.Sweet_Alert(title, msg, type, this.Page, this.GetType(), "/Catalogues/Customers/Customer_List.aspx");

            //Response.Redirect("Employee_List.aspx");
        }

        protected void GVCustomers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                //recupero el indice en funcion de aquel elemento que haya detonado el evento
                int varIndex = int.Parse(e.CommandArgument.ToString());
                //recupero el ID en funcion del indice que recuperamos anteriormente
                string id = GVCustomers.DataKeys[varIndex].Values["ID_Customer"].ToString();
                //redireccionamos al formulario de edicion, pasando como parametro el ID
                Response.Redirect($"Customer_Form.aspx?Id={id}");
            }
        }

        protected void GVCustomers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int addressID = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Address_ID"));
                if (Addresses.TryGetValue(addressID, out string customerAddress))
                {
                    e.Row.Cells[4].Text = customerAddress;
                }
                else
                {
                    e.Row.Cells[4].Text = "Unknown Address"; // Fallback for missing data
                }
            }
        }
    }
}