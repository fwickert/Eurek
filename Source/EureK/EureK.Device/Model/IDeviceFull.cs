using Microsoft.Azure.Documents.Spatial;


namespace EureK.Device.Model
{
    public interface IDeviceFull
    {
        string ID { get; set; }
        string AddressNum { get; set; }
        string AddressNature { get; set; }
        string AddressName { get; set; }
        string AddressDomain { get; set; }
        string Sector { get; set; }
        string TechnicalRegion { get; set; }
        string District { get; set; }
        double SupportHeight { get; set; }
        int SupportLife { get; set; }
        string SupportLifeUnit { get; set; }
        string Material { get; set; }
        string LampLib { get; set; }
        double lampPower { get; set; }
        int LampLife { get; set; }
        string LampLifeUnit { get; set; }
        int LampFlow { get; set; }
        int lampVolt { get; set; }
        string lampFamily { get; set; }
        Point Location { get; set; }
        double Latitude { get; set; }
        double Longitude { get; set; }


    }
}
