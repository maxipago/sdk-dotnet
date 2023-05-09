using System;
using System.Xml.Serialization;

namespace MaxiPago.DataContract.Transactional
{

    [Serializable]
    public class Address {

        [XmlElement("name")]
        public string Name { get; set; }
        public bool ShouldSerializeName() { return !string.IsNullOrEmpty(this.Name); }

        [XmlElement("address")]
        public string Address1 { get; set; }
        public bool ShouldSerializeAddress1() { return !string.IsNullOrEmpty(this.Address1); }

        [XmlElement("address2")]
        public string Address2 { get; set; }
        public bool ShouldSerializeAddress2() { return !string.IsNullOrEmpty(this.Address2); }

        [XmlElement("city")]
        public string City { get; set; }
        public bool ShouldSerializeCity() { return !string.IsNullOrEmpty(this.City); }

        [XmlElement("district")]
        public string District { get; set; }
        public bool ShouldSerializeDistrict() { return !string.IsNullOrEmpty(this.District); }

        [XmlElement("state")]
        public string State { get; set; }
        public bool ShouldSerializeState() { return !string.IsNullOrEmpty(this.State); }

        [XmlElement("postalcode")]
        public string Postalcode { get; set; }
        public bool ShouldSerializePostalcode() { return !string.IsNullOrEmpty(this.Postalcode); }

        [XmlElement("country")]
        public string Country { get; set; }
        public bool ShouldSerializeCountry() { return !string.IsNullOrEmpty(this.Country); }

        [XmlElement("phone")]
        public string Phone { get; set; }
        public bool ShouldSerializePhone() { return !string.IsNullOrEmpty(this.Phone); }

        [XmlElement("email")]
        public string Email { get; set; }
        public bool ShouldSerializeEmail() { return !string.IsNullOrEmpty(this.Email); }

        [XmlElement("customerIdExt")]
        public string CustomerIdExt { get; set; }
        public bool ShouldSerializeCustomerIdExt() { return !string.IsNullOrEmpty(this.CustomerIdExt); }

        [XmlElement("firstName")]
        public string FirstName { get; set; }
        public bool ShouldSerializeFirstName() { return !string.IsNullOrEmpty(this.FirstName); }

        [XmlElement("lastName")]
        public string LastName { get; set; }
        public bool ShouldSerializeLastName() { return !string.IsNullOrEmpty(this.LastName); }

        [XmlElement("dob")]
        public string Dob { get; set; }
        public bool ShouldSerializeDob() { return !string.IsNullOrEmpty(this.Dob); }

        [XmlElement("sex")]
        public string Sex { get; set; }
        public bool ShouldSerializeSex() { return !string.IsNullOrEmpty(this.Sex); }
    }
}
