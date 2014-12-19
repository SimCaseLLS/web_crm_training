using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainingCentersCRM.Models
{
    [JsonObject]
    public class HHSpecialization
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }

    [JsonObject]
    public class HHProffessionalArea
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("specializations")]
        public List<HHSpecialization> Specializations { get; set; }
    }
}