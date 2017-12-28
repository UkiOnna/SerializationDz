using SerializationDz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializationDz
{
    [Serializable]
    [My()]
    public class Book : MyAttribute
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }

        public int GetAttribute()
        {
            var type = this.GetType();

            if (Attribute.IsDefined(type, typeof(MyAttribute)))
            {
                var attributeValue = Attribute.GetCustomAttribute(type, typeof(MyAttribute)) as MyAttribute;
                attributeValue.Cena = Price;
                return attributeValue.Cena;
            }

            return -1;
        }
    }
}
