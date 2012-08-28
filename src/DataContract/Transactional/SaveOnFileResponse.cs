using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MaxiPago.DataContract.Transactional {
    
    [Serializable]
    [XmlRoot(ElementName = "save-on-file")]
    public class SaveOnFileResponse {

        [XmlElement("error")]
        public string Error { get; set; }

        [XmlElement("token")]
        public string Token { get; set; }

    }
}
