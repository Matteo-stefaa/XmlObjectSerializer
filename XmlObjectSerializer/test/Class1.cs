using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlObjectSerializer.test
{
    public class Class1
    {
        [SerNode("Name")]
        public string Name { get; set; }
        [SerNode("Description")]
        public string Description { get; set; }
        [SerIenumerableNode("List", typeof(string))]
        public List<string> List { get; set; } = new List<string>();
    }
}
