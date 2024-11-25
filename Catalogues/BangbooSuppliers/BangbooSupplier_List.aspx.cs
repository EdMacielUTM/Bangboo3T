using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Transportes3Capas.utilidades;

namespace Bangboo3T.Catalogues.BangbooSuppliers
{
    public partial class BangbooSupplier_List : System.Web.UI.Page
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
            GVSuppliers.DataSource = BLL_BangbooSuppliers.GetBangbooSuppliers();

            GVSuppliers.DataBind();
        }

        protected void Insert_Click(object sender, EventArgs e)
        {
            Response.Redirect("BangbooSupplier_Form.aspx");
        }

        protected void GVSuppliers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int idSupplier = int.Parse(GVSuppliers.DataKeys[e.RowIndex].Values["ID_Supplier"].ToString());

            string response = BLL_BangbooSuppliers.DeleteSupplier(idSupplier);

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

            SweetAlert.Sweet_Alert(title, msg, type, this.Page, this.GetType(), "/Catalogues/BangbooSuppliers/BangbooSupplier_List.aspx");

            //Response.Redirect("Employee_List.aspx");
        }

        protected void GVSuppliers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                //recupero el indice en funcion de aquel elemento que haya detonado el evento
                int varIndex = int.Parse(e.CommandArgument.ToString());
                //recupero el ID en funcion del indice que recuperamos anteriormente
                string id = GVSuppliers.DataKeys[varIndex].Values["ID_Supplier"].ToString();
                //redireccionamos al formulario de edicion, pasando como parametro el ID
                Response.Redirect($"BangbooSupplier_Form.aspx?Id={id}");
            }
        }

        protected void GVSuppliers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int addressID = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Address_ID"));
                if (Addresses.TryGetValue(addressID, out string supplierAddress))
                {
                    e.Row.Cells[3].Text = supplierAddress;
                }
                else
                {
                    e.Row.Cells[3].Text = "Unknown Address"; // Fallback for missing data
                }
            }
        }
    }
}