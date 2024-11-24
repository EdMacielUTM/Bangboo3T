using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bangboo3T.Catalogues.Inventory
{
    public partial class Inventory_List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadGrid();
            }
        }

        public void loadGrid()
        {
            GVInventory.DataSource = BLL_Inventory_Details.GetInventoryDetails();

            GVInventory.DataBind();
        }

        protected void GVInventory_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Restock")
            {
                //recupero el indice en funcion de aquel elemento que haya detonado el evento
                int varIndex = int.Parse(e.CommandArgument.ToString());
                //recupero el ID en funcion del indice que recuperamos anteriormente
                string id = GVInventory.DataKeys[varIndex].Values["ID_Bangboo"].ToString();
                //redireccionamos al formulario de edicion, pasando como parametro el ID
                Response.Redirect($"~/Catalogues/BangbooSupplyDetails/BangbooSupplyDetail_Form.aspx?Id={id}");
            }

            if (e.CommandName == "Details")
            {
                //recupero el indice en funcion de aquel elemento que haya detonado el evento
                int varIndex = int.Parse(e.CommandArgument.ToString());
                //recupero el ID en funcion del indice que recuperamos anteriormente
                string id = GVInventory.DataKeys[varIndex].Values["ID_Bangboo"].ToString();
                //redireccionamos al formulario de edicion, pasando como parametro el ID
                Response.Redirect($"~/Catalogues/BangbooSupplyDetails/BangbooSupplyDetail_List.aspx?Id={id}");
            }
        }
    }
}