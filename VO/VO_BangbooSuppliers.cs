using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class VO_BangbooSuppliers
    {
        private int _ID_Supplier;
        private string _Name;
        private string _Email;
        private string _Phone;
        private int _Address_ID;

        public VO_BangbooSuppliers()
        {
            _ID_Supplier = 0;
            _Name = "";
            _Email = "";
            _Phone = "";
            _Address_ID = 0;
        }

        public VO_BangbooSuppliers(DataRow dataRow)
        {
            _ID_Supplier = int.Parse(dataRow["ID_Supplier"].ToString());
            _Name = dataRow["Name"].ToString();
            _Email = dataRow["Email"].ToString();
            _Phone = dataRow["Phone"].ToString();
            _Address_ID = int.Parse(dataRow["Address_ID"].ToString());
        }

        public int ID_Supplier { get => _ID_Supplier; set => _ID_Supplier = value; }
        public string Name { get => _Name; set => _Name = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string Phone { get => _Phone; set => _Phone = value; }
        public int Address_ID { get => _Address_ID; set => _Address_ID = value; }
    }
}
