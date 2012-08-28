using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MaxiPago.DataContract.Transactional {

    [Serializable]
    [XmlRoot( ElementName = "clientData")]
    public class ClientData {

        public ClientData() {
            this.comments = ".NetPlugin v1.1";
        }

        [XmlElement("customField1")]
        public string CustomField1 { get; set; }

        [XmlElement("customField2")]
        public string CustomField2 { get; set; }

        [XmlElement("customField3")]
        public string CustomField3 { get; set; }

        [XmlElement("customField4")]
        public string CustomField4 { get; set; }

        [XmlElement("customField5")]
        public string CustomField5 { get; set; }

        private string comments;

        [XmlElement("comments")]
        public string Comments {
            get { return this.comments; }
            set { }
        }

    }
}
