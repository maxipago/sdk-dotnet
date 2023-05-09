using System;
using System.Xml.Serialization;

namespace MaxiPago.DataContract.NonTransactional
{

    public class ApiResult {

        [XmlElement(ElementName="customerId")]
        public String CustomerId { get; set; }

        [XmlElement(ElementName = "token")]
        public String Token { get; set; }

        [XmlElement(ElementName = "pay_order_id")]
        public String PayOrderId { get; set; }

        [XmlElement(ElementName = "message")]
        public String Message { get; set; }

        [XmlElement(ElementName = "url")]
        public String Url { get; set; }
    }
}
