using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace musiclibrary2017
{
    public class Singer
    {
        public const int DefaultYear = 2017;

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        // 0 - 10
        private int _year;

        public int Year
        {
            get { return _year; }
            set { _year = value; }
        }

        public string Info
        {
            get
            {
                return $"{_name} - {_year} - {_country.Name} - {_country.School}";
            }
        }

        private Country _country;

        public Country Country
        {
            get { return _country; }
            set { _country = value; }
        }



        public Singer(string name, int rating)
        {
            _name = name;
            _year = rating;
        }

        public Singer(string name)
            : this(name, DefaultYear)
        {
        }
    }
}
