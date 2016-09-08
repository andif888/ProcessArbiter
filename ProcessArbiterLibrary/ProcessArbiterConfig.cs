using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using ProcessArbiter;

namespace ProcessArbiter
{
    internal class ProcessArbiterConfig
    {
        internal ProcessPolicy Getconfig(string Filename)
        {
            ProcessPolicy _Policy = new ProcessPolicy();
            XmlSerializer serializer = new XmlSerializer(typeof(ProcessPolicy));
            using (StreamReader sr = new StreamReader(Filename))
            {
                _Policy = (ProcessPolicy)serializer.Deserialize(sr);
            }
            return _Policy;
        }
        internal void Setconfig(ProcessPolicy _Policy, string Filename)
        {
           
            XmlSerializer serializer = new XmlSerializer(typeof(ProcessPolicy));
            using (StreamWriter sr = new StreamWriter(Filename,false))
            {
                serializer.Serialize(sr, _Policy);
                sr.Flush();
            }

        }
    }
}
