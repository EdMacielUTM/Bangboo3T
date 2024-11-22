using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace BLL
{
    public class BLL_Bangboos
    {
        //CREATE
        public static string CreateBangboo(VO_Bangboos bangboo)
        {
            return DAL_Bangboos.CreateBangboo(bangboo);
        }

        //READ
        public static List<VO_Bangboos> GetBangboos(params object[] parameters)
        {
            return DAL_Bangboos.GetBangboos(parameters);
        }
        //UPDATE
        public static string UpdateBangboo(VO_Bangboos bangboo)
        {
            return DAL_Bangboos.UpdateBangboo(bangboo);
        }

        //DELETE
        //TR_PreventBangbooDeletion
        public static string DeleteBangboo(int id)
        {
            return DAL_Bangboos.DeleteBangboo(id);
        }

    }
}
