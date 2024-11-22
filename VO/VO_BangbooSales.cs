using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class VO_BangbooSales
    {
        private int _Bangboo_ID;
        private int _SalesReceipt_ID;
        private int _Quantity;
        private int _ID_BangbooSales;

        public VO_BangbooSales()
        {
            _Bangboo_ID = 0;
            _SalesReceipt_ID = 0;
            _Quantity = 0;
            _ID_BangbooSales = 0;
        }

        public VO_BangbooSales(DataRow dataRow)
        {
            _Bangboo_ID = int.Parse(dataRow["Bangboo_ID"].ToString());
            _SalesReceipt_ID = int.Parse(dataRow["SalesReceipt_ID"].ToString());
            _Quantity = int.Parse(dataRow["Quantity"].ToString());
            _ID_BangbooSales = int.Parse(dataRow["ID_BangbooSales"].ToString());
        }

        public int Bangboo_ID { get => _Bangboo_ID; set => _Bangboo_ID = value; }
        public int SalesReceipt_ID { get => _SalesReceipt_ID; set => _SalesReceipt_ID = value; }
        public int Quantity { get => _Quantity; set => _Quantity = value; }
        public int ID_BangbooSales { get => _ID_BangbooSales; set => _ID_BangbooSales = value; }
    }
}
