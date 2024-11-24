using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VO;

namespace Bangboo3T.Catalogues.BangbooSales
{
    public partial class BangbooSale_Form : System.Web.UI.Page
    {
        private VO_Bangboos _bangboo = new VO_Bangboos();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadGrid();
            }
        }

        public void loadGrid()
        {
            if (Request.QueryString["id"] != null)
            {
                int _id = int.Parse(Request.QueryString["id"].ToString());
                GVSales.DataSource = BLL_BangbooSales.GetBangbooSales("@SalesReceipt_ID", _id);

                GVSales.DataBind();
            }
            else
            {
                Response.Redirect($"~/Catalogues/SalesReceipts/SalesReceipt_List.aspx");
            }
        }

        protected void Insert_Click(object sender, EventArgs e)
        {
            int _id = int.Parse(Request.QueryString["id"].ToString());
            Response.Redirect($"Bangboo_Sale_Form.aspx?Id={_id}");
        }
        protected void Return_Click(object sender, EventArgs e)
        {
            Response.Redirect($"~/Catalogues/SalesReceipts/SalesReceipt_List.aspx");
        }
        protected void GVSales_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int bangbooID = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Bangboo_ID"));
                if (bangbooID > 0)
                {
                    _bangboo = BLL_Bangboos.GetBangboos("@ID_Bangboo",  bangbooID)[0];
                    e.Row.Cells[1].Text = _bangboo.Name + " | " + _bangboo.Model;
                }
                else
                {
                    e.Row.Cells[1].Text = "Unknown Bangboo"; 
                }
            }
        }
    }
}