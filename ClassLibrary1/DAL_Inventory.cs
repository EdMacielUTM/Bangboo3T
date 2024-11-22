using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace DAL
{
    public class DAL_Inventory
    {
        //CREATE
        //IS CREATED AUTOMATICALLY ON BANGBOO CREATION, QTY SET TO 0, RESTOCKDATE PROBS NULL

        //READ
        //MAYBE HAVE A BUTTON REDIRECTING TO A SUPPLY DETAIL???????
        public static List<VO_Inventory> GetInventory(params object[] parameters)
        {
            List<VO_Inventory> list = new List<VO_Inventory>();

            try
            {
                DataSet ds_inventory = Data_Methods.execute_DataSet("SP_List_Inventory", parameters);

                foreach (DataRow dr in ds_inventory.Tables[0].Rows)
                {
                    list.Add(new VO_Inventory(dr));
                }

                return list;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //UPDATE
        //GOES OFF AUTOMATICALLY ON NEW SUPPLY DETAIL
        
        //DELETE
        //CASCADING ON BANGBOO DELETION BUT MOST LIKELY WON'T BE NECESSARY TBH
    }
}
