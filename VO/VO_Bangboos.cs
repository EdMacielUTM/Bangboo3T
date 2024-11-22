using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class VO_Bangboos
    {
        private int _ID_Bangboo;
        private string _Name;
        private string _Element;
        private bool _Rank;
        private string _Model;
        private string _PictureURL;
        private int _Price;

        public VO_Bangboos()
        {
            _ID_Bangboo = 0;
            _Name = "";
            _Element = "";
            _Rank = false;
            _Model = "";
            _PictureURL = "";
            _Price = 0;
        }
        public VO_Bangboos(DataRow dataRow)
        {
            _ID_Bangboo = int.Parse(dataRow["ID_Bangboo"].ToString());
            _Name = dataRow["Name"].ToString();
            _Element = dataRow["Element"].ToString();
            _Rank = bool.Parse(dataRow["Rank"].ToString());
            _Model = dataRow["Model"].ToString();
            _PictureURL = dataRow["PictureURL"].ToString();
            _Price = int.Parse(dataRow["Price"].ToString());
        }

        public int ID_Bangboo { get => _ID_Bangboo; set => _ID_Bangboo = value; }
        public string Name { get => _Name; set => _Name = value; }
        public string Element { get => _Element; set => _Element = value; }
        public bool Rank { get => _Rank; set => _Rank = value; }
        public string Model { get => _Model; set => _Model = value; }
        public string PictureURL { get => _PictureURL; set => _PictureURL = value; }
        public int Price { get => _Price; set => _Price = value; }
    }
}
