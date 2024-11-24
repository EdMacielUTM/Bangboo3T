using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Transportes3Capas.utilidades;
using VO;

namespace Bangboo3T.Catalogues.BangbooSupplyDetails
{
    public partial class BangbooSupplyDetail_List : System.Web.UI.Page
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
            string id = Request.QueryString["id"];
            if (id != null && int.Parse(id) > 0)
            {
                Insert.Visible = false;
                GVDetails.DataSource = BLL_Stock_Details.GetStockDetails("@Bangboo_ID", id);
            }
            else
            {
                GVDetails.DataSource = BLL_Stock_Details.GetStockDetails();
            }

            GVDetails.DataBind();
        }

        protected void Insert_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Catalogues/BangbooSupplyDetails/BangbooSupplyDetail_Form.aspx");
        }
        protected void GVDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //recupero el indice en funcion de aquel elemento que haya detonado el evento
            int varIndex = int.Parse(e.CommandArgument.ToString());
            //recupero el ID en funcion del indice que recuperamos anteriormente
            string id = GVDetails.DataKeys[varIndex].Values["ID_Bangboo"].ToString();
            //redireccionamos al formulario de edicion, pasando como parametro el ID
            Response.Redirect($"~/Catalogues/BangbooSupplyDetails/BangbooSupplyDetail_Form.aspx?Id={id}");
        }
    }
}