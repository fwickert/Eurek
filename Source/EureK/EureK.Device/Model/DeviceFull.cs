using Microsoft.Azure.Documents.Spatial;
using Newtonsoft.Json;


namespace EureK.Device.Model
{
    public class DeviceFull : IDeviceFull
    {
        public override string ToString()
        {
            return this.ID;
        }

        [JsonProperty(PropertyName = "id")]
        public string ID { get; set; }

        [JsonProperty(PropertyName = "addressDomain")]
        public string AddressDomain { get; set; }

        [JsonProperty(PropertyName = "addressName")]
        public string AddressName { get; set; }

        [JsonProperty(PropertyName = "addressNature")]
        public string AddressNature { get; set; }

        [JsonProperty(PropertyName = "addressNum")]
        public string AddressNum { get; set; }

        [JsonProperty(PropertyName = "district")]
        public string District { get; set; }

        [JsonProperty(PropertyName = "lampFamily")]
        public string lampFamily { get; set; }

        [JsonProperty(PropertyName = "lampFlow")]
        public int LampFlow { get; set; }

        [JsonProperty(PropertyName = "lampLib")]
        public string LampLib { get; set; }

        [JsonProperty(PropertyName = "lampLife")]
        public int LampLife { get; set; }

        [JsonProperty(PropertyName = "lampLifeUnit")]
        public string LampLifeUnit { get; set; }

        [JsonProperty(PropertyName = "lampPower")]
        public double lampPower { get; set; }

        [JsonProperty(PropertyName = "lampVolt")]
        public int lampVolt { get; set; }

        [JsonProperty(PropertyName = "material")]
        public string Material { get; set; }

        [JsonProperty(PropertyName = "sector")]
        public string Sector { get; set; }

        [JsonProperty(PropertyName = "supportHeight")]
        public double SupportHeight { get; set; }

        [JsonProperty(PropertyName = "supportLife")]
        public int SupportLife { get; set; }

        [JsonProperty(PropertyName = "supportLifeUnit")]
        public string SupportLifeUnit { get; set; }

        [JsonProperty(PropertyName = "technicalRegion")]
        public string TechnicalRegion { get; set; }

        [JsonProperty(PropertyName = "latitude")]
        public double Latitude { get; set; }

        [JsonProperty(PropertyName = "longitude")]
        public double Longitude { get; set; }

        [JsonProperty(PropertyName = "location")]
        public Point Location { get; set; }
    }
}
