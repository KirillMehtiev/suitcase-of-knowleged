using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    partial class Base
    {
        private string _name = "Unknown";

        partial void OnNameChanging(string value);

        public string Name
        {
            get { return _name; }
            set
            {
                OnNameChanging(value.ToLower());
                _name = value;
            }
        }
    }

    partial class Base
    {
        partial void OnNameChanging(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("Name cannot be null or empty!");
        }
    }
}
