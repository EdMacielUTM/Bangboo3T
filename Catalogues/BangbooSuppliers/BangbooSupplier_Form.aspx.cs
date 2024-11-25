using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Transportes3Capas.utilidades;
using VO;

namespace Bangboo3T.Catalogues.BangbooSuppliers
{
    public partial class BangbooSupplier_Form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] == null)
                {
                    Title_.Text = "Add Supplier";
                    Subtitle_.Text = "Add new supplier details";
                }
                else
                {
                    int _id = Convert.ToInt32(Request.QueryString["id"]);
                    VO_BangbooSuppliers _original_Supplier = BLL_BangbooSuppliers.GetBangbooSuppliers("@ID_Supplier", _id)[0];
                    VO_Addresses _original_Address = BLL_Addresses.GetAddresses("@ID_Address", _original_Supplier.Address_ID)[0];

                    if (_original_Supplier.ID_Supplier != 0)
                    {
                        Title_.Text = "Update Customer information";
                        Subtitle_.Text = $"Update {_original_Supplier.Name}'s Data";
                        txtName.Text = _original_Supplier.Name;
                        txtPhoneNumber.Text = _original_Supplier.Phone;
                        txtEmail.Text = _original_Supplier.Email;

                        txtStreetNumber.Text = _original_Address.Street_Number;
                        txtCity.Text = _original_Address.City;
                        txtState.Text = _original_Address.State;
                        txtZipCode.Text = _original_Address.ZipCode;
                    }
                    else
                    {
                        Response.Redirect("BangbooSupplier_List.aspx");
                    }
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string title = "", response = "", type = "", output = "";

            try
            {
                VO_BangbooSuppliers _aux_supplier = new VO_BangbooSuppliers();
                _aux_supplier.Name = txtName.Text;
                _aux_supplier.Phone = txtPhoneNumber.Text;
                _aux_supplier.Email = txtEmail.Text;

                VO_Addresses _aux_address = new VO_Addresses();
                _aux_address.Street_Number = txtStreetNumber.Text;
                _aux_address.City = txtCity.Text;
                _aux_address.State = txtState.Text;
                _aux_address.ZipCode = txtZipCode.Text;

                if (Request.QueryString["Id"] == null)
                {
                    output = BLL_Addresses.CreateAddress(_aux_address);
                    _aux_supplier.Address_ID = BLL_Addresses.GetAddresses(
                        "@Street_Number", _aux_address.Street_Number,
                        "@City", _aux_address.City,
                        "@State", _aux_address.State,
                        "@ZipCode", _aux_address.ZipCode
                        ).Last().ID_Address;
                    output += " " + BLL_BangbooSuppliers.CreateBangbooSupplier(_aux_supplier);
                }
                else
                {
                    _aux_supplier.ID_Supplier = int.Parse(Request.QueryString["Id"]);
                    _aux_address.ID_Address = BLL_BangbooSuppliers.GetBangbooSuppliers("@ID_Supplier", _aux_supplier.ID_Supplier)[0].Address_ID;
                    _aux_supplier.Address_ID = _aux_address.ID_Address;
                    output = BLL_Addresses.UpdateAddress(_aux_address);
                    output += " " + BLL_BangbooSuppliers.UpdateBangbooSupplier(_aux_supplier);
                }

                if (output.ToUpper().Contains("ERROR"))
                {
                    title = "Oops...";
                    response = output;
                    type = "warning";
                }
                else
                {
                    title = "Success!";
                    response = output;
                    type = "success";
                }
            }
            catch (Exception ex)
            {
                title = "Error";
                response = ex.Message;
                type = "error";
            }
            SweetAlert.Sweet_Alert(title, response, type, this.Page, this.GetType(), "BangbooSupplier_List");
        }


        protected void Return_Click(object sender, EventArgs e)
        {
            Response.Redirect($"BangbooSupplier_List.aspx");
        }
    }
}