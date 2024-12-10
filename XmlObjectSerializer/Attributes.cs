using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlObjectSerializer
{
    public class SerNodeAttribute : Attribute
    {
        public string Name { get; set; }
    }
    public class SerIenumerableNodeAttribute : SerNodeAttribute
    {
        public Type Type { get; set; }
    }
}
