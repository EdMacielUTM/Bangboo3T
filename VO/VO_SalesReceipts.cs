using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class VO_SalesReceipts
    {
        private int _ID_Sale;
        private string _SaleDate;
        private int _Employee_ID;
        private int _Customer_ID;
        private int _TotalAmount;

        public VO_SalesReceipts()
        {
            _ID_Sale = 0;
            _SaleDate = "";
            _Employee_ID = 0;
            _Customer_ID = 0;
            _TotalAmount = 0;
        }

        public VO_SalesReceipts(DataRow dataRow)
        {
            _ID_Sale = int.Parse(dataRow["ID_Sale"].ToString());
            _SaleDate = dataRow["SaleDate"].ToString();
            _Employee_ID = int.Parse(dataRow["Employee_ID"].ToString());
            _Customer_ID = int.Parse(dataRow["Customer_ID"].ToString());
            _TotalAmount = int.Parse(dataRow["TotalAmount"].ToString());
        }

        public int ID_Sale { get => _ID_Sale; set => _ID_Sale = value; }
        public string SaleDate { get => _SaleDate; set => _SaleDate = value; }
        public int Employee_ID { get => _Employee_ID; set => _Employee_ID = value; }
        public int Customer_ID { get => _Customer_ID; set => _Customer_ID = value; }
        public int TotalAmount { get => _TotalAmount; set => _TotalAmount = value; }
    }
}
