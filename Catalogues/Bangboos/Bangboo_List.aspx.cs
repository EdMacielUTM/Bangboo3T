using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Transportes3Capas.utilidades;
using VO;

namespace Bangboo3T.Catalogues.Bangboos
{
    public partial class Bangboo_List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                loadGrid();
            }
        }

        public void loadGrid()
        {
            GVBangboos.DataSource = BLL_Bangboos.GetBangboos();

            GVBangboos.DataBind();
        }

        protected void GVBangboos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int idBangboo = int.Parse(GVBangboos.DataKeys[e.RowIndex].Values["ID_Bangboo"].ToString());

            string response = BLL_Bangboos.DeleteBangboo(idBangboo);

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

            SweetAlert.Sweet_Alert(title, msg, type, this.Page, this.GetType());

            loadGrid();
        }

        protected void GVBangboos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                //recupero el indice en funcion de aquel elemento que haya detonado el evento
                int varIndex = int.Parse(e.CommandArgument.ToString());
                //recupero el ID en funcion del indice que recuperamos anteriormente
                string id = GVBangboos.DataKeys[varIndex].Values["ID_Bangboo"].ToString();
                //redireccionamos al formulario de edicion, pasando como parametro el ID
                Response.Redirect($"Bangboo_Form.aspx?Id={id}");
            }
        }

        protected void GVBangboos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GVBangboos.EditIndex = e.NewEditIndex;
            loadGrid();
        }

        protected void GVBangboos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GVBangboos.EditIndex = -1;
            loadGrid();
        }

        protected void GVBangboos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int idBangboo = int.Parse(GVBangboos.DataKeys[e.RowIndex].Values["ID_Bangboo"].ToString());
            string name = e.NewValues["Name"].ToString();
            string model = e.NewValues["Model"].ToString();
            string element = e.NewValues["Element"].ToString();
            string picture = e.NewValues["PictureURL"].ToString();
            int price = int.Parse(e.NewValues["Price"].ToString());
            CheckBox check = (CheckBox)GVBangboos.Rows[e.RowIndex].FindControl("checkEditRank");
            bool rank = check.Checked;

            VO_Bangboos _bangboo = BLL_Bangboos.GetBangboos("@ID_Bangboo", idBangboo)[0];
            VO_Bangboos _bangbooAux = new VO_Bangboos();

            _bangbooAux.ID_Bangboo = idBangboo;
            _bangbooAux.Name = name;
            _bangbooAux.Model = model;
            _bangbooAux.Element = element;
            _bangbooAux.Rank = rank;
            _bangbooAux.PictureURL = picture;
            _bangbooAux.Price = price;

            string response = "";
            string title, msg, type;

            try
            {
                response = BLL_Bangboos.UpdateBangboo(_bangbooAux);
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
            }
            catch (Exception ex)
            {
                title = "Oops...";
                msg = response;
                type = "error";
            }

            SweetAlert.Sweet_Alert(title, msg, type, this.Page, this.GetType());
            GVBangboos.EditIndex = -1;
            loadGrid();
        }

        protected void Insert_Click(object sender, EventArgs e)
        {
            Response.Redirect("Bangboo_Form.aspx");
        }
    }
}