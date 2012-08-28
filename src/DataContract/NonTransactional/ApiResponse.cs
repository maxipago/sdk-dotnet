using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MaxiPago.DataContract.NonTransactional {

    [Serializable]
    [XmlRoot(ElementName = "api-response")]
    public class ApiResponse : ResponseBase {

        [XmlElement("errorCode")]
        public string ErrorCode { get; set; }

        [XmlElement("errorMessage")]
        public string ErrorMessage { get; set; }

        [XmlElement("command")]
        public string Command { get; set; }

        [XmlElement("time")]
        public string Time { get; set; }

        [XmlElement("result")]
        public ApiResult Result { get; set; }

    }
}
