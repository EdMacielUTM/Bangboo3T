using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class VO_Inventory_Details
    {
        private int _ID_Bangboo;
        private string _Name;
        private int _Price;
        private int _Quantity;
        private string _LastRestockDate;
        private string _PictureURL;

        public VO_Inventory_Details()
        {
            _ID_Bangboo = 0;
            _Name = "";
            _Price = 0;
            _Quantity = 0;
            _LastRestockDate = "";
            _PictureURL = "";
        }

        public VO_Inventory_Details(DataRow dataRow)
        {
            _ID_Bangboo = int.Parse(dataRow["#"].ToString());
            _Name = dataRow["Bangboo"].ToString();
            _Price = int.Parse(dataRow["Retail Price"].ToString());
            _Quantity = int.Parse(dataRow["Stock"].ToString());
            _LastRestockDate = dataRow["Latest Restock"].ToString().Split(' ')[0];
            _PictureURL = dataRow["Picture URL"].ToString();
        }

        public int ID_Bangboo { get => _ID_Bangboo; set => _ID_Bangboo = value; }
        public string Name { get => _Name; set => _Name = value; }
        public int Price { get => _Price; set => _Price = value; }
        public int Quantity { get => _Quantity; set => _Quantity = value; }
        public string LastRestockDate { get => _LastRestockDate; set => _LastRestockDate = value; }
        public string PictureURL { get => _PictureURL; set => _PictureURL = value; }
    }
}
