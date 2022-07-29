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
        private XmlDocument _xmlDocument;
         
        public Serializer()
        {
            if (Type.GetConstructors().ToList().Find(c => c.GetParameters().Length == 0) == null)
            {
                throw new SerializerException($"The Type {Type} must have a neutral constructor");
            }
        }

        public Type Type => typeof(T);

        // public
        public void ExportXml(T input, string path)
        {
            _xmlDocument = new XmlDocument();
            XmlNode xn = getXmlNode(_xmlDocument, input.GetType().Name, input);
            _xmlDocument.AppendChild(xn);

            XmlWriterSettings ws = new XmlWriterSettings() { Indent = true, Encoding = UTF8Encoding.UTF8 };

            using (XmlWriter writer = XmlWriter.Create(path, ws))
            {
                _xmlDocument.Save(writer);
            }
        }

        // private
        private XmlNode getXmlNode(XmlDocument xd, string name, object input)
        {
            XmlNode res = xd.CreateElement(name);

            if (input == null 
                || input.GetType().GetProperties() == null 
                || input.GetType().GetProperties().ToList()
                    .Find(pi => pi.GetMethod != null && pi.SetMethod != null) == null)
            {
                return null;
            }
            else
            {
                foreach (PropertyInfo pi in input.GetType().GetProperties())
                {
                    if (pi.GetMethod == null || pi.SetMethod == null) { continue; }
                    XmlNode nd = null;
                    try
                    {
                        nd = getXmlNode(xd, pi.Name, pi.GetValue(input));
                    }
                    catch (Exception) { continue; }

                    if (nd == null)
                    {
                        XmlAttribute att = xd.CreateAttribute(pi.Name);
                        att.Value = input != null ? pi.GetValue(input)?.ToString() ?? "" : "";
                        res.Attributes.SetNamedItem(att);
                    }
                    else
                    {
                        res.AppendChild(nd);
                    }
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
