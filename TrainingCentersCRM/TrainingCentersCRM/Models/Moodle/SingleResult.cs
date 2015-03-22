using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

namespace TrainingCentersCRM.Models.Moodle
{
    [XmlRoot("SINGLE")]
    public class SingleResult
    {
        [XmlElement(ElementName = "KEY")]
        public Key[] KeyValues { get; set; }

        public string this[string key]
        {
            get
            {
                if (KeyValues.Where(a => a.Name == key).Count() == 0)
                    return null;
                return KeyValues.Where(a => a.Name == key).SingleOrDefault().Value;
            }
        }

        public string[] Keys
        {
            get
            {
                return KeyValues.Select(a => a.Name).ToArray();
            }
        }
    }
}