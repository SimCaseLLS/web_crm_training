using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace TrainingCentersCRM.Models.Moodle
{
    public class Key
    {
        [XmlArray("MULTIPLE")]
        [XmlArrayItem("SINGLE")]
        public SingleResult[] MultiValue { get; set; }

        [XmlAttribute(AttributeName="name")]
        public string Name { get; set; }

        [XmlElement(ElementName="VALUE")]
        public string Value { get; set; }
    }
}