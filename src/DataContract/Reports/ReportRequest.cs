using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MaxiPago.DataContract.Reports {
    
    [Serializable]
    [XmlRoot(ElementName = "request")]
    public class ReportRequest {

        public ReportRequest() {
            this.FilterOptions = new FilterOptions();
        }

        [XmlElement("filterOptions")]
        public FilterOptions FilterOptions { get; set; }

        [XmlElement("requestToken")]
        public String RequestToken { get; set; }
        

    }
}
