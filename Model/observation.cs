using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceModel
{
    public class ObservationModel
    {
        public Observation[] observation { get; set; }
    }

    public class Observation
    {
        public string name { get; set; }
        public object summary { get; set; }
        public string uri { get; set; }
        public object id { get; set; }
        public string document { get; set; }
        public object documentSummary { get; set; }
        public string source { get; set; }
        public object sourceSummary { get; set; }
        public Opinion[] opinion { get; set; }
    }

    public class Opinion
    {
        public string name { get; set; }
        public string uri { get; set; }
        public object id { get; set; }
        public float defaultCertainty { get; set; }
        public float defaultLikelihood { get; set; }
    }


}