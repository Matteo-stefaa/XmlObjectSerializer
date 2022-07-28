using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Xml;

namespace XmlObjectSerializer
{
    public class Serializer<T>
    {
        public Serializer()
        {
            if (Type.GetConstructors().ToList().Find(c => c.GetParameters().Length == 0) == null)
            {
                throw new SerializerException($"The Type {Type} must have a neutral constructor");
            }
        }

        public Type Type => typeof(T);

        public void ExportXml(T input, string path)
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlNode xn = getXmlNode(xmlDoc, input);
        }

        private XmlNode getXmlNode(XmlDocument xd, object input)
        {
            XmlNode res = xd.CreateTextNode(input.GetType().Name);

            if (input.GetType().GetProperties() == null)
            {
                res.Value = input.ToString();
            }
            else
            {
                foreach (PropertyInfo pi in input.GetType().GetProperties())
                {
                    if (pi.GetMethod == null || pi.SetMethod == null) { continue; }
                    res.AppendChild(getXmlNode(xd, input));
                }
            }

            return res;
        }
    }
    public class SerializerException : Exception
    {
        public SerializerException(string sms) : base(sms) { }
    }
}
