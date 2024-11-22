using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace BLL
{
    public class BLL_Addresses
    {
        //CREATE
        public static string CreateAddress(VO_Addresses address)
        {
            return DAL_Addresses.CreateAddress(address);
        }

        //READ
        public static List<VO_Addresses> GetAddresses(params object[] parameters)
        {
            return DAL_Addresses.GetAddresses(parameters);
        }
        //UPDATE
        public static string UpdateAddress(VO_Addresses address)
        {
            return DAL_Addresses.UpdateAddress(address);
        }

        //DELETE
        //NOT NEEDED - DELETED ON CASCADE
    }
}
