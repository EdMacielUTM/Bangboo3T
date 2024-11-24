using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace DAL
{
    public class DAL_Inventory_Details
    {
        //READ
        public static List<VO_Inventory_Details> GetInventoryDetails(params object[] parameters)
        {
            List<VO_Inventory_Details> list = new List<VO_Inventory_Details>();

            try
            {
                DataSet ds_details = Data_Methods.execute_DataSet("SP_Inventory_Details", parameters);

                foreach (DataRow dr in ds_details.Tables[0].Rows)
                {
                    list.Add(new VO_Inventory_Details(dr));
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
