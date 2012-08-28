using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using MaxiPago.DataContract;

namespace MaxiPago.DataContract.Transactional {
    
    [Serializable]
    [XmlRoot(ElementName="api-error")]
    public class ErrorResponse : ResponseBase {

        [XmlElement("errorCode")]
        public string ErrorCode { get; set; }

        [XmlElement("errorMsg")]
        public string ErrorMsg { get; set; }

    }
}
