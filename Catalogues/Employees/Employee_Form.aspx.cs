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

namespace Bangboo3T.Catalogues.Employees
{
    public partial class Employee_Form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] == null)
                {
                    Title_.Text = "Add Employee";
                    Subtitle_.Text = "Add new hire details";
                }
                else
                {
                    int _id = Convert.ToInt32(Request.QueryString["id"]);
                    VO_Employees _original_Employee = BLL_Employees.GetEmployees("@ID_Employee", _id)[0];
                    VO_Addresses _original_Address = BLL_Addresses.GetAddresses("@ID_Address", _original_Employee.Address_ID)[0];

                    if (_original_Employee.ID_Employee != 0)
                    {
                        Title_.Text = "Update Employee information";
                        Subtitle_.Text = $"Update {_original_Employee.FirstName + " " + _original_Employee.LastName}'s Data";
                        txtFirstName.Text = _original_Employee.FirstName;
                        txtLastName.Text = _original_Employee.LastName;
                        txtPhoneNumber.Text = _original_Employee.PhoneNumber;
                        txtEmail.Text = _original_Employee.Email;
                        txtSalary.Text = _original_Employee.Salary.ToString();

                        txtStreetNumber.Text = _original_Address.Street_Number;
                        txtCity.Text = _original_Address.City;
                        txtState.Text = _original_Address.State;
                        txtZipCode.Text = _original_Address.ZipCode;
                    }
                    else
                    {
                        Response.Redirect("Employee_List.aspx");
                    }
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string title = "", response = "", type = "", output = "";

            try
            {
                VO_Employees _aux_employee = new VO_Employees();
                _aux_employee.FirstName = txtFirstName.Text;
                _aux_employee.LastName = txtLastName.Text;
                _aux_employee.PhoneNumber = txtPhoneNumber.Text;
                _aux_employee.Email = txtEmail.Text;
                _aux_employee.Salary = float.Parse(txtSalary.Text);

                VO_Addresses _aux_address = new VO_Addresses();
                _aux_address.Street_Number = txtStreetNumber.Text;
                _aux_address.City = txtCity.Text;
                _aux_address.State = txtState.Text;
                _aux_address.ZipCode = txtZipCode.Text;

                if (Request.QueryString["Id"] == null)
                {
                    output = BLL_Addresses.CreateAddress(_aux_address);
                    _aux_employee.Address_ID = BLL_Addresses.GetAddresses(
                        "@Street_Number", _aux_address.Street_Number,
                        "@City", _aux_address.City,
                        "@State", _aux_address.State,
                        "@ZipCode", _aux_address.ZipCode
                        ).Last().ID_Address;
                    output += " " + BLL_Employees.CreateEmployee(_aux_employee);
                }   
                else
                {
                    _aux_employee.ID_Employee = int.Parse(Request.QueryString["Id"]);
                    _aux_employee.HireDate = BLL_Employees.GetEmployees("@ID_Employee", _aux_employee.ID_Employee)[0].HireDate;
                    _aux_address.ID_Address = BLL_Employees.GetEmployees("@ID_Employee", _aux_employee.ID_Employee)[0].Address_ID;
                    _aux_employee.Address_ID = _aux_address.ID_Address;
                    output = BLL_Addresses.UpdateAddress(_aux_address);
                    output += " " + BLL_Employees.UpdateEmployee(_aux_employee);
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
            SweetAlert.Sweet_Alert(title, response, type, this.Page, this.GetType(), "Employee_List");
        }


        protected void Return_Click(object sender, EventArgs e)
        {
            Response.Redirect($"Employee_List.aspx");
        }
    }
}