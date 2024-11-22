using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class VO_Customers
    {
        private int _ID_Customer;
        private string _FirstName;
        private string _LastName;
        private string _PhoneNumber;
        private string _Email;
        private int _Address_ID;

        public VO_Customers()
        {
            _ID_Customer = 0;
            _FirstName = "";
            _LastName = "";
            _PhoneNumber = "";
            _Email = "";
            _Address_ID = 0;
        }

        public VO_Customers(DataRow dataRow)
        {
            _ID_Customer = int.Parse(dataRow["ID_Customer"].ToString());
            _FirstName = dataRow["FirstName"].ToString();
            _LastName = dataRow["LastName"].ToString();
            _PhoneNumber = dataRow["PhoneNumber"].ToString();
            _Email = dataRow["Email"].ToString();
            _Address_ID = int.Parse(dataRow["Address_ID"].ToString());
        }

        public int ID_Customer { get => _ID_Customer; set => _ID_Customer = value; }
        public string FirstName { get => _FirstName; set => _FirstName = value; }
        public string LastName { get => _LastName; set => _LastName = value; }
        public string PhoneNumber { get => _PhoneNumber; set => _PhoneNumber = value; }
        public string Email { get => _Email; set => _Email = value; }
        public int Address_ID { get => _Address_ID; set => _Address_ID = value; }
    }
}
