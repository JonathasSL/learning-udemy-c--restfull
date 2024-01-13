using Geolocation;
using WebApplication1.Model;

namespace WebApplication1.Services
{
    public interface ILocationService
    {
        (Coordinate max, Coordinate min) CalculateCoordinates(double initialLatitude, double initialLongitude, double metersDistance, int bearing = 90);
    }
}
