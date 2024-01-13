using Geolocation;

namespace WebApplication1.Model
{
    public class Location
    {
        public Coordinate Coordinate { get; }

        public Location(double latitude, double longitude)
        {
            Coordinate = new Coordinate(latitude, longitude);
        }
    }
}
