using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch04.ContentControls
{
    class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return string.Format("{0} is {1} years old", Name, Age);
        }
    }
}
