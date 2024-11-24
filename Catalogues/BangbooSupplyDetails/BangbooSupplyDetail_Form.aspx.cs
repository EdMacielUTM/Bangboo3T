using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using Transportes3Capas.utilidades;
using VO;

namespace Bangboo3T.Catalogues.BangbooSupplyDetails
{
    public partial class BangbooSupplyDetail_Form : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                load_DDL();

                Title_.Text = "Enter Bangboo restock data.";
                int _id = int.Parse(ddlBangboo.SelectedValue);
                VO_Bangboos _bangboo = BLL_Bangboos.GetBangboos("@ID_Bangboo", _id)[0];
                imgBangboo.AlternateText = _bangboo.PictureURL;
                imgBangboo.ImageUrl = _bangboo.PictureURL;
                imgBangboo.Visible = true;
                if (Request.QueryString["id"] != null)
                {
                    _id = int.Parse(Request.QueryString["id"].ToString());
                    _bangboo = BLL_Bangboos.GetBangboos("@ID_Bangboo", _id)[0];


                    if (_bangboo.ID_Bangboo != 0)
                    {
                        Subtitle_.Text = "Bangboo: " + _bangboo.Name + " (" + _bangboo.Model + ")";
                        lblBangboo.Visible = false;
                        ddlBangboo.Visible = false;
                        imgBangboo.AlternateText = _bangboo.PictureURL;
                        imgBangboo.ImageUrl = _bangboo.PictureURL;
                        imgBangboo.Visible = true;
                    }
                    else
                    {
                        SweetAlert.Sweet_Alert("Oops...", "Bangboo not found.", "info", this.Page, this.GetType(), "~/Catalogues/Inventory/Inventory.aspx");
                    }
                }
            }
        }

        protected void load_DDL()
        {
            ListItem ddlBangboos_I = new ListItem("Select a Bangboo", "0");
            List<VO_Bangboos> list_bangboos = BLL_Bangboos.GetBangboos();
            if(list_bangboos.Count > 0)
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

            ListItem ddlSuppliers_I = new ListItem("Select a Supplier", "0");
            List<VO_BangbooSuppliers> list_suppliers = BLL_BangbooSuppliers.GetBangbooSuppliers();
            if (list_suppliers.Count > 0)
            {
                foreach (var supplier in list_suppliers)
                {
                    ListItem supplierItem = new ListItem(
                            supplier.Name, 
                            supplier.ID_Supplier.ToString()
                        );
                    ddlSupplier.Items.Add(supplierItem);
                }
            }
        }

        protected void btnRestock_Click(object sender, EventArgs e)
        {
            int _id = int.Parse(ddlBangboo.SelectedValue);
            VO_Bangboos _bangboo = BLL_Bangboos.GetBangboos("@ID_Bangboo", _id)[0];

            _id = int.Parse(ddlSupplier.SelectedValue);
            VO_BangbooSuppliers _supplier = BLL_BangbooSuppliers.GetBangbooSuppliers("@ID_Supplier", _id)[0];

            VO_BangbooSupplyDetails _supply = new VO_BangbooSupplyDetails();

            string title, message, type, response;

            try
            {
                _supply.ID_Supplier = int.Parse(ddlSupplier.SelectedValue);
                _supply.SupplyAmount = int.Parse(txtAmount.Text);
                _supply.SupplyDate = "";
                _supply.UnitCost = int.Parse(txtCost.Text);

                if (Request.QueryString["id"] != null)
                {
                    _supply.ID_Bangboo = int.Parse(Request.QueryString["id"]);
                }
                else
                {
                    _supply.ID_Bangboo = int.Parse(ddlBangboo.SelectedValue);
                }
                response = BLL_BangbooSupplyDetails.CreateBangbooSupplyDetail(_supply);

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

                    SweetAlert.Sweet_Alert(title, message, type, this.Page, this.GetType(), "/Catalogues/Inventory/Inventory.aspx");

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

        protected void ddlBangboo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int _id = int.Parse(ddlBangboo.SelectedValue);
            VO_Bangboos _bangboo = BLL_Bangboos.GetBangboos("@ID_Bangboo", _id)[0];
            imgBangboo.AlternateText = _bangboo.PictureURL;
            imgBangboo.ImageUrl = _bangboo.PictureURL;
            imgBangboo.Visible = true;
        }
    }
}