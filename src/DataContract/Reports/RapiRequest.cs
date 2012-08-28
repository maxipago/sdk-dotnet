using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MaxiPago.DataContract.Reports {

    [Serializable]
    [XmlRoot(ElementName = "rapi-request")]
    public class RapiRequest {

        public RapiRequest() {
            this.Verification = new Verification();
            this.ReportRequest = new ReportRequest();
        }

        public RapiRequest(string merchantId, string merchantKey) {
            this.Verification = new Verification(merchantId, merchantKey);
            this.ReportRequest = new ReportRequest();
        }

        [XmlElement("verification")]
        public Verification Verification { get; set; }

        [XmlElement("command")]
        public string Command { get; set; }

        [XmlElement("request")]
        public ReportRequest ReportRequest { get; set; }


    }
}
