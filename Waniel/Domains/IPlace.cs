namespace Waniel.Domains
{
    public interface IPlace
    {
        public string Name { get; set; }
        public PlaceCoordinate Location { get; set; }
    }

    public class PlaceCoordinate : ICoordinate
    {
        public double Lon { get; set; }
        public double Lat { get; set; }
    }
}
