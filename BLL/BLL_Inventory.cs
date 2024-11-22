using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace BLL
{
    public class BLL_Inventory
    {
        //CREATE
        //IS CREATED AUTOMATICALLY ON BANGBOO CREATION, QTY SET TO 0, RESTOCKDATE PROBS NULL

        //SOLVED: TR_InsertInventoryOnInsertBangboo


        //READ
        //MAYBE HAVE A BUTTON REDIRECTING TO A SUPPLY DETAIL???????
        public static List<VO_Inventory> GetInventory(params object[] parameters)
        {
            return DAL_Inventory.GetInventory(parameters);
        }

        //UPDATE
        //GOES OFF AUTOMATICALLY ON NEW SUPPLY DETAIL

        //SOLVED: TR_UpdateInventoryOnSupply


        //DELETE
        //CASCADING ON BANGBOO DELETION BUT MOST LIKELY WON'T BE NECESSARY TBH

        //SOLVED: TR_PreventBangbooDeletion
    }
}
