using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;
using DAL;

namespace BLL
{
    public class BLL_BangbooSuppliers
    {
        //CREATE
        //ADDRESS IS CREATED ON SUPPLIER CREATION
        public static string CreateBangbooSupplier(VO_BangbooSuppliers supplier)
        {
            return DAL_BangbooSuppliers.CreateBangbooSupplier(supplier);
        }

        //READ
        //ADDRESS IS READ TOO
        public static List<VO_BangbooSuppliers> GetBangbooSuppliers(params object[] parameters)
        {
            return DAL_BangbooSuppliers.GetBangbooSuppliers(parameters);
        }

        //UPDATE
        //ADDRESS IS UPDATED TOO
        public static string UpdateBangbooSupplier(VO_BangbooSuppliers supplier)
        {
            return DAL_BangbooSuppliers.UpdateBangbooSupplier(supplier);
        }

        //DELETE
        //ADDRESS IS DELETED TOO
        public static string DeleteSupplier(int id)
        {
            return DAL_BangbooSuppliers.DeleteSupplier(id);
        }

    }
}
