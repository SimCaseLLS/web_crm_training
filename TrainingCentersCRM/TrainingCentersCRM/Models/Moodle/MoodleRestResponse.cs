using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace TrainingCentersCRM.Models.Moodle
{
    [XmlRoot("RESPONSE")]
    public class MoodleRestResponse
    {
        [XmlArray("MULTIPLE")]
        [XmlArrayItem("SINGLE")]
        public SingleResult[] MultiValue { get; set; }

        [XmlElement(ElementName="SINGLE")]
        public Single SingleValue { get; set; }

    }
}