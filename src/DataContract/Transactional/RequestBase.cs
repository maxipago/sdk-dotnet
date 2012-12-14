using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MaxiPago.DataContract.Transactional {
    
    [Serializable]
    public class RequestBase {

        public RequestBase() {
            this.Payment = new Payment();
            this.TransactionDetail = new TransactionDetail();
        }

        [XmlElement("processorID")]
        public string ProcessorId { get; set; }

        [XmlElement("authentication")]
        public string Authentication { get; set; }

        [XmlElement("referenceNum")]
        public string ReferenceNum { get; set; }

        [XmlElement("ipAddress")]
        public string IpAddress { get; set; }

        [XmlElement("fraudCheck")]
        public string FraudCheck { get; set; }
        // Verifica se o valor da propriedade é nulo, se sim, não serializa esse campo no xml
        public bool ShouldSerializeFraudCheck() { return this.FraudCheck != null; }

        //[XmlElement("invoiceNumber")]
        //public string InvoiceNumber { get; set; }

        [XmlElement("billing")]
        public Billing Billing { get; set; }
        public bool ShouldSerializeBilling() { return this.Billing != null; }

        [XmlElement("shipping")]
        public Shipping Shipping { get; set; }
        public bool ShouldSerializeShipping() { return this.Shipping != null; }

        [XmlElement("transactionDetail")]
        public TransactionDetail TransactionDetail { get; set; }

        [XmlElement("payment")]
        public Payment Payment { get; set; }

        [XmlElement("recurring")]
        public Recurring Recurring { get; set; }

        [XmlElement("saveOnFile")]
        public SaveOnFile SaveOnFile { get; set; }

        [XmlElement("customerIdExt")]
        public string CustomerIdExt { get; set; }
        public bool ShouldSerializeCustomerIdExt() { return !string.IsNullOrEmpty(this.CustomerIdExt); }

    }
}
