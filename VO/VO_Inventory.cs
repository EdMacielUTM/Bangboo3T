using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class VO_Inventory
    {
        private int _ID_Inventory;
        private int _Bangboo_ID;
        private int _Quantity;
        private string _LastRestockDate;

        public VO_Inventory()
        {
            _ID_Inventory = 0;
            _Bangboo_ID = 0;
            _Quantity = 0;
            _LastRestockDate = "";
        }

        public VO_Inventory(DataRow dataRow)
        {
            _ID_Inventory = int.Parse(dataRow["ID_Inventory"].ToString());
            _Bangboo_ID = int.Parse(dataRow["Bangboo_ID"].ToString());
            _Quantity = int.Parse(dataRow["Quantity"].ToString());
            _LastRestockDate = dataRow["LastRestockDate"].ToString();
        }
        public int ID_Inventory { get => _ID_Inventory; set => _ID_Inventory = value; }
        public int Bangboo_ID { get => _Bangboo_ID; set => _Bangboo_ID = value; }
        public int Quantity { get => _Quantity; set => _Quantity = value; }
        public string LastRestockDate { get => _LastRestockDate; set => _LastRestockDate = value; }
    }
}
