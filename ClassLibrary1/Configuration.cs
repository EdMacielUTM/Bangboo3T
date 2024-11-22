using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Configuration
    {
        //Cadena de conexion
        //Data source = BD Server name
        //localhost
        //.
        //Instance name
        //Initial Catalog = DB name
        // Integrated Security = true (PC Credenctials)
        // = false (Access credentials)
        // User =;
        //Password=;

        static string _connectionString = @"Data Source = MSI\SQLEXPRESS; Initial Catalog = BangbooNET; Integrated Security = true";

        //Encapsulamiento
        public static string ConnectionString
        {
            get
            {
                return _connectionString;
            }
        }


    }
}
