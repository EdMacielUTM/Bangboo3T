﻿using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace BLL
{
    public class BLL_Inventory_Details
    {
        public static List<VO_Inventory_Details> GetInventoryDetails(params object[] parameters)
        {
            return DAL_Inventory_Details.GetInventoryDetails(parameters);
        }
    }
}
