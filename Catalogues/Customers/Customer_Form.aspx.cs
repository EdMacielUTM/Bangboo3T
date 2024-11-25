using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Transportes3Capas.utilidades;
using VO;

namespace Bangboo3T.Catalogues.Customers
{
    public partial class Customer_Form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] == null)
                {
                    Title_.Text = "Add Customer";
                    Subtitle_.Text = "Add new customer details";
                }
                else
                {
                    int _id = Convert.ToInt32(Request.QueryString["id"]);
                    VO_Customers _original_Customer = BLL_Customers.GetCustomers("@ID_Customer", _id)[0];
                    VO_Addresses _original_Address = BLL_Addresses.GetAddresses("@ID_Address", _original_Customer.Address_ID)[0];

                    if (_original_Customer.ID_Customer != 0)
                    {
                        Title_.Text = "Update Customer information";
                        Subtitle_.Text = $"Update {_original_Customer.FirstName + " " + _original_Customer.LastName}'s Data";
                        txtFirstName.Text = _original_Customer.FirstName;
                        txtLastName.Text = _original_Customer.LastName;
                        txtPhoneNumber.Text = _original_Customer.PhoneNumber;
                        txtEmail.Text = _original_Customer.Email;

                        txtStreetNumber.Text = _original_Address.Street_Number;
                        txtCity.Text = _original_Address.City;
                        txtState.Text = _original_Address.State;
                        txtZipCode.Text = _original_Address.ZipCode;
                    }
                    else
                    {
                        Response.Redirect("Customer_List.aspx");
                    }
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string title = "", response = "", type = "", output = "";

            try
            {
                VO_Customers _aux_customer = new VO_Customers();
                _aux_customer.FirstName = txtFirstName.Text;
                _aux_customer.LastName = txtLastName.Text;
                _aux_customer.PhoneNumber = txtPhoneNumber.Text;
                _aux_customer.Email = txtEmail.Text;

                VO_Addresses _aux_address = new VO_Addresses();
                _aux_address.Street_Number = txtStreetNumber.Text;
                _aux_address.City = txtCity.Text;
                _aux_address.State = txtState.Text;
                _aux_address.ZipCode = txtZipCode.Text;

                if (Request.QueryString["Id"] == null)
                {
                    output = BLL_Addresses.CreateAddress(_aux_address);
                    _aux_customer.Address_ID = BLL_Addresses.GetAddresses(
                        "@Street_Number", _aux_address.Street_Number,
                        "@City", _aux_address.City,
                        "@State", _aux_address.State,
                        "@ZipCode", _aux_address.ZipCode
                        ).Last().ID_Address;
                    output += " " + BLL_Customers.CreateCustomer(_aux_customer);
                }
                else
                {
                    _aux_customer.ID_Customer = int.Parse(Request.QueryString["Id"]);
                    _aux_address.ID_Address = BLL_Customers.GetCustomers("@ID_Customer", _aux_customer.ID_Customer)[0].Address_ID;
                    _aux_customer.Address_ID = _aux_address.ID_Address;
                    output = BLL_Addresses.UpdateAddress(_aux_address);
                    output += " " + BLL_Customers.UpdateCustomer(_aux_customer);
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
            SweetAlert.Sweet_Alert(title, response, type, this.Page, this.GetType(), "Customer_List");
        }


        protected void Return_Click(object sender, EventArgs e)
        {
            Response.Redirect($"Customer_List.aspx");
        }
    }
}