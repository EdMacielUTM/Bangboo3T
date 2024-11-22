using BLL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using Transportes3Capas.utilidades;
using VO;

namespace Bangboo3T.Catalogues.Bangboos
{
    public partial class Bangboo_Form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] == null)
                {
                    Title_.Text = "Add Bangboo";
                    Subtitle_.Text = "Log a new Bangboo onto the Database";
                    lblRank.Visible = true;
                    checkRank.Visible = true;
                    imgPicture.Visible = false;
                    lblPictureURL.Visible = false;
                }
                else
                {
                    int _id = Convert.ToInt32(Request.QueryString["id"]);
                    VO_Bangboos _original_Bangboo = BLL_Bangboos.GetBangboos("@ID_Bangboo", _id)[0];

                    if (_original_Bangboo.ID_Bangboo != 0)
                    {
                        Title_.Text = "Update Bangboo";
                        Subtitle_.Text = $"Update Bangboo #{_id}'s entry";
                        txtName.Text = _original_Bangboo.Name;
                        txtModel.Text = _original_Bangboo.Model;
                        txtElement.Text = _original_Bangboo.Element;
                        txtPrice.Text = (_original_Bangboo.Price).ToString();
                        checkRank.Checked = _original_Bangboo.Rank;
                        imgPicture.ImageUrl = _original_Bangboo.PictureURL;
                    }
                    else
                    {
                        Response.Redirect("Bangboo_List.aspx");
                    }
                }

            }
        }

        protected void btnPictureUpload_Click1(object sender, EventArgs e)
        {
            if(pictureUpload.Value != "")
            {
                string filename = Path.GetFileName(pictureUpload.Value);
                string fileext = Path.GetExtension(filename).ToLower();

                string response = "";
                string title, msg, type;

                if ((fileext != "jpg") && (fileext != ".png") && (fileext != ".jpeg"))
                {
                    title = "Oops...";
                    msg = "File format must be JPG, PNG, or JPEG.";
                    type = "warning";
                }
                else
                {
                    string pathdir = Server.MapPath("~/assets/img/");
                    if (!Directory.Exists(pathdir))
                    {
                        Directory.CreateDirectory(pathdir);
                    }
                    pictureUpload.PostedFile.SaveAs(pathdir + filename);
                    string picURL = "~/assets/img/" + filename;
                    this.pictureURL.Text = picURL;
                    imgBangboo.ImageUrl = picURL;
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string title = "", response = "", type = "", output = "";

            try
            {
                VO_Bangboos _aux_bangboo = new VO_Bangboos();
                _aux_bangboo.Name = txtName.Text;
                _aux_bangboo.Element = txtElement.Text;
                _aux_bangboo.Rank = checkRank.Checked;
                _aux_bangboo.Model = txtModel.Text;
                _aux_bangboo.PictureURL = imgBangboo.ImageUrl != ""? imgBangboo.ImageUrl: imgPicture.ImageUrl;
                _aux_bangboo.Price = Convert.ToInt32(txtPrice.Text);

                if (Request.QueryString["Id"] == null)
                {
                    output = BLL_Bangboos.CreateBangboo(_aux_bangboo);
                }
                else
                {
                    _aux_bangboo.ID_Bangboo = int.Parse(Request.QueryString["Id"]);
                    output = BLL_Bangboos.UpdateBangboo(_aux_bangboo);
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
            SweetAlert.Sweet_Alert(title, response, type, this.Page, this.GetType(), "Bangboo_List");
        }
    }
}