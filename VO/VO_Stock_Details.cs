using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace VO
{
    public class VO_Stock_Details
    {
        private int _ID_Detail; 
        private int _ID_Bangboo; 
		private int _Price;
        private int _UnitCost;
        private int _SupplyAmount; 
		private string _SupplyDate;
        private string _Name;
        private string _PictureURL;

        public VO_Stock_Details()
        {
            _ID_Detail = 0;
            _ID_Bangboo = 0;
            _Price = 0;
            _UnitCost = 0;
            _SupplyAmount = 0;
            _SupplyDate = "";
            _Name = "";
            _PictureURL = "";
        }

        public VO_Stock_Details(DataRow dataRow)
        {
            _ID_Detail = int.Parse(dataRow["#"].ToString());
            _ID_Bangboo = int.Parse(dataRow["Bangboo_ID"].ToString());
            _Price = int.Parse(dataRow["Price"].ToString());
            _UnitCost = int.Parse(dataRow["Unit Cost"].ToString());
            _SupplyAmount = int.Parse(dataRow["Restock Amount"].ToString());
            _SupplyDate = dataRow["Restock Date"].ToString().Split(' ')[0];
            _Name = dataRow["Bangboo"].ToString();
            _PictureURL = dataRow["Picture"].ToString();
        }

        public int ID_Detail { get => _ID_Detail; set => _ID_Detail = value; }
        public int ID_Bangboo { get => _ID_Bangboo; set => _ID_Bangboo = value; }
        public int Price { get => _Price; set => _Price = value; }
        public int UnitCost { get => _UnitCost; set => _UnitCost = value; }
        public int SupplyAmount { get => _SupplyAmount; set => _SupplyAmount = value; }
        public string SupplyDate { get => _SupplyDate; set => _SupplyDate = value; }
        public string Name { get => _Name; set => _Name = value; }
        public string PictureURL { get => _PictureURL; set => _PictureURL = value; }
    }
}
