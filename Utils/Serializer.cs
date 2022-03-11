using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WebserviceClient.Utils
{
    public static class Serializer
    {
        public static C Deserialize<C>(this string value)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(C));
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            StringReader inStream = new StringReader(value);
            C _out = (C)deserializer.Deserialize(inStream);
            inStream.Close();
            return _out;
        }

        public static string Serialize<T>(this T value)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            StringWriterUTF8 outStream = new StringWriterUTF8();
            serializer.Serialize(outStream, value, ns);
            return outStream.ToString();
        }
    }

    public class StringWriterUTF8 : StringWriter
    {
        private readonly Encoding encodingUtf8 = new UTF8Encoding();
        public StringWriterUTF8() : base() { }

        public override Encoding Encoding
        {
            get
            {
                return this.encodingUtf8;
            }
        }
    }
}
