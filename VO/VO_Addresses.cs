using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class VO_Addresses
    {
        private int _ID_Address;
        private string _Street_Number;
        private string _City;
        private string _State;
        private string _ZipCode;
        public VO_Addresses()
        {
            _ID_Address = 0;
            _Street_Number = "";
            _City = "";
            _State = "";
            _ZipCode = "";
        }
        public VO_Addresses(DataRow dataRow)
        {
            _ID_Address = int.Parse(dataRow["ID_Address"].ToString());
            _Street_Number = dataRow["Street_Number"].ToString();
            _City = dataRow["City"].ToString();
            _State = dataRow["State"].ToString();
            _ZipCode = dataRow["ZipCode"].ToString();
        }

        public int ID_Address { get => _ID_Address; set => _ID_Address = value; }
        public string Street_Number { get => _Street_Number; set => _Street_Number = value; }
        public string City { get => _City; set => _City = value; }
        public string State { get => _State; set => _State = value; }
        public string ZipCode { get => _ZipCode; set => _ZipCode = value; }
    }
}
