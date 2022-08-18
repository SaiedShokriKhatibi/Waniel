using System.Text.Json.Serialization;

namespace Waniel.Domains
{
    public class Airport : IPlace
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Name { get; set; }
        public int Hubs { get; set; }
        public PlaceCoordinate Location { get; set; }
    }

}
