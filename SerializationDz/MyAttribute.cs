using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializationDz
{
    public class MyAttribute : Attribute
    {
        public int Cena { get; set; }

        public MyAttribute()
        {

        }
    }
}
