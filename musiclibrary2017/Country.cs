using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace musiclibrary2017
{
    public class Country
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _school;

        public string School
        {
            get { return _school; }
            set { _school = value; }
        }

        public Country(string name, string school)
        {
            _name = name;
            _school = school;
        }
    }
}
