using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MaxiPago.DataContract.Transactional {

    [Serializable]
    [XmlRoot(ElementName = "payment")]
    public class Payment {

        [XmlElement("creditInstallment")]
        public CreditInstallment CreditInstallment { get; set; }

        public bool ShouldSerializeCreditInstallment() { return this.CreditInstallment != null; }

        [XmlElement("chargeTotal")]
        public decimal ChargeTotal { get; set; }

        [XmlElement("currencyCode")]
        public string CurrencyCode { get; set; }

        public bool ShouldSerializeCurrencyCode() { return this.CurrencyCode != null; }
		
		[XmlElement("softDescriptor")]
        public string SoftDescriptor { get; set; }
        /// Verifica se o valor da propriedade é nulo, se sim, não serializa esse campo no xml
        public bool ShouldSerializeSoftDescriptor() { return this.SoftDescriptor != null; }

        [XmlElement("iataFee")]
        public decimal? IataFee { get; set; }
        /// Verifica se o valor da propriedade é nulo, se sim, não serializa esse campo no xml
        public bool ShouldSerializeIataFee() { return this.IataFee != null; }

    }
}
