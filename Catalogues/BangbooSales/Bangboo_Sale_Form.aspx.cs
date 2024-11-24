using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Transportes3Capas.utilidades;
using VO;

namespace Bangboo3T.Catalogues.BangbooSales
{
    public partial class Bangboo_Sale_Form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                load_DDL();

                Title_.Text = "Enter Bangboo sale data.";
                int _id = int.Parse(ddlBangboo.SelectedValue);
                VO_Bangboos _bangboo = BLL_Bangboos.GetBangboos("@ID_Bangboo", _id)[0];
                txtCost.Text = _bangboo.Price.ToString();
                imgBangboo.AlternateText = _bangboo.PictureURL;
                imgBangboo.ImageUrl = _bangboo.PictureURL;
                imgBangboo.Visible = true;
            }
        }

        private void load_DDL()
        {
            ListItem ddlBangboos_I = new ListItem("Select a Bangboo", "0");
            List<VO_Bangboos> list_bangboos = BLL_Bangboos.GetBangboos();
            if (list_bangboos.Count > 0)
            {
                foreach (var bangboo in list_bangboos)
                {
                    ListItem bangbooItem = new ListItem(
                            (bangboo.Name + " | " + bangboo.Model),
                            bangboo.ID_Bangboo.ToString()
                        );
                    ddlBangboo.Items.Add(bangbooItem);
                }
                ddlBangboo.SelectedIndex = 0;
            }
        }

        protected void ddlBangboo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int _id = int.Parse(ddlBangboo.SelectedValue);
            VO_Bangboos _bangboo = BLL_Bangboos.GetBangboos("@ID_Bangboo", _id)[0];
            imgBangboo.AlternateText = _bangboo.PictureURL;
            imgBangboo.ImageUrl = _bangboo.PictureURL;
            imgBangboo.Visible = true;
            txtCost.Text = _bangboo.Price.ToString();
            if (string.IsNullOrEmpty(txtQuantity.Text)) txtQuantity.Text = "1";
            int _calc = _bangboo.Price * int.Parse(txtQuantity.Text);
            txtSubtotal.Text = _calc.ToString();
        }

        protected void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            int quantity;
            if (int.TryParse(txtQuantity.Text, out quantity))
            {
                if (quantity < 1)
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "  * Quantity must be at least 1.";
                    txtQuantity.Text = "1"; // Optional: reset to 1 if the input is less than 1
                }
                else
                {
                    int _calc = int.Parse(txtCost.Text) * int.Parse(txtQuantity.Text);
                    txtSubtotal.Text = _calc.ToString();
                }
            }
            else
            {
                lblMessage.Text = "Please enter a valid number.";
            }
        }

        protected void Return_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                int _id = int.Parse(Request.QueryString["id"].ToString());
                Response.Redirect($"~/Catalogues/BangbooSales/Bangboo_Sale_List.aspx?Id={_id}");
            }
            else
            {
                Response.Redirect($"~/Catalogues/SalesReceipts/SalesReceipt_List.aspx");
            }
        }

        protected void btnSale_Click(object sender, EventArgs e)
        {
            VO_BangbooSales _sale = new VO_BangbooSales();
            string title, message, type, response;

            try
            {
                _sale.Bangboo_ID = int.Parse(ddlBangboo.SelectedValue);
                _sale.Quantity = int.Parse(txtQuantity.Text);

                if (Request.QueryString["id"] != null)
                {
                    _sale.SalesReceipt_ID = int.Parse(Request.QueryString["id"]);
                }

                response = BLL_BangbooSales.CreateBangbooSale(_sale);

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
                    int _id = int.Parse(Request.QueryString["id"]);
                    SweetAlert.Sweet_Alert(title, message, type, this.Page, this.GetType(), $"/Catalogues/BangbooSales/Bangboo_Sale_List?Id={_id}");

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