using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MaxiPago.DataContract.NonTransactional {

    [Serializable]
    [XmlRoot(ElementName = "api-request")]
    public class ApiRequest {

        public ApiRequest() {
            this.Verification = new Verification();
            
        }

        public ApiRequest(string merchantId, string merchantKey) {
            this.Verification = new Verification(merchantId, merchantKey);
            
        }

        [XmlElement("verification")]
        public Verification Verification { get; set; }

        [XmlElement("command")]
        public string Command { get; set; }

        [XmlElement("request")]
        public CommandRequest CommandRequest { get; set; }



    }
}
