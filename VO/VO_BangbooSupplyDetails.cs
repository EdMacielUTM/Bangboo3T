using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class VO_BangbooSupplyDetails
    {
        private int _ID_Detail;
        private int _ID_Bangboo;
        private int _ID_Supplier;
        private int _SupplyAmount;
        private string _SupplyDate;
        private int _UnitCost;

        public VO_BangbooSupplyDetails()
        {
            _ID_Detail = 0;
            _ID_Bangboo = 0;
            _ID_Supplier = 0;
            _SupplyAmount = 0;
            _SupplyDate = "";
            _UnitCost = 0;
        }

        public VO_BangbooSupplyDetails(DataRow dataRow)
        {
            _ID_Detail = int.Parse(dataRow["ID_Detail"].ToString());
            _ID_Bangboo = int.Parse(dataRow["ID_Bangboo"].ToString());
            _ID_Supplier = int.Parse(dataRow["ID_Supplier"].ToString());
            _SupplyAmount = int.Parse(dataRow["SupplyAmount"].ToString());
            _UnitCost = int.Parse(dataRow["UnitCost"].ToString());
            _SupplyDate = dataRow["SupplyDate"].ToString();
        }

        public int ID_Detail { get => _ID_Detail; set => _ID_Detail = value; }
        public int ID_Bangboo { get => _ID_Bangboo; set => _ID_Bangboo = value; }
        public int ID_Supplier { get => _ID_Supplier; set => _ID_Supplier = value; }
        public int SupplyAmount { get => _SupplyAmount; set => _SupplyAmount = value; }
        public string SupplyDate { get => _SupplyDate; set => _SupplyDate = value; }
        public int UnitCost { get => _UnitCost; set => _UnitCost = value; }
    }
}
