using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class VO_Employees
    {
        private int _ID_Employee;
        private string _FirstName;
        private string _LastName;
        private string _PhoneNumber;
        private string _Email;
        private string _HireDate;
        private float _Salary;
        private int _Address_ID;

        public VO_Employees()
        {
            _ID_Employee = 0;
            _FirstName = "";
            _LastName = "";
            _PhoneNumber = "";
            _Email = "";
            _HireDate = "";
            _Salary = 0;
            _Address_ID = 0;
        }

        public VO_Employees(DataRow dataRow)
        {
            _ID_Employee = int.Parse(dataRow["ID_Employee"].ToString());
            _FirstName = dataRow["FirstName"].ToString();
            _LastName = dataRow["LastName"].ToString();
            _PhoneNumber = dataRow["PhoneNumber"].ToString();
            _Email = dataRow["Email"].ToString();
            _HireDate = dataRow["HireDate"].ToString().Split(' ')[0];
            _Salary = float.Parse(dataRow["Salary"].ToString());
            _Address_ID = int.Parse(dataRow["Address_ID"].ToString());
        }

        public int ID_Employee { get => _ID_Employee; set => _ID_Employee = value; }
        public string FirstName { get => _FirstName; set => _FirstName = value; }
        public string LastName { get => _LastName; set => _LastName = value; }
        public string PhoneNumber { get => _PhoneNumber; set => _PhoneNumber = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string HireDate { get => _HireDate; set => _HireDate = value; }
        public float Salary { get => _Salary; set => _Salary = value; }
        public int Address_ID { get => _Address_ID; set => _Address_ID = value; }
    }
}
