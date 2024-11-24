using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace BLL
{
    public class BLL_Stock_Details
    {
        public static List<VO_Stock_Details> GetStockDetails(params object[] parameters)
        {
            return DAL_Stock_Details.GetStockDetails(parameters);
        }
    }
}
