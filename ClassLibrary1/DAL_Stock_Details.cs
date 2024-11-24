using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace DAL
{
    public class DAL_Stock_Details
    {
        //READ
        public static List<VO_Stock_Details> GetStockDetails(params object[] parameters)
        {
            List<VO_Stock_Details> list = new List<VO_Stock_Details>();

            try
            {
                DataSet ds_details = Data_Methods.execute_DataSet("SP_Bangboo_Stock", parameters);

                foreach (DataRow dr in ds_details.Tables[0].Rows)
                {
                    list.Add(new VO_Stock_Details(dr));
                }

                return list;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
