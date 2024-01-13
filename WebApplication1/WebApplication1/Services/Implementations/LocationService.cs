using Geolocation;
using WebApplication1.Model;

namespace WebApplication1.Services.Implementations
{
    public class LocationService : ILocationService
    {
        private readonly double EARTH_RADIUS_KILOMETERS = 6371;

        public (Coordinate max, Coordinate min) CalculateCoordinates(double initialLatitude, double initialLongitude, double kilometersDistance, int bearing = 90)
        {
            var coordinates = new Coordinate { Latitude = initialLatitude, Longitude = initialLongitude };
            var boundaries = new CoordinateBoundaries(coordinates, kilometersDistance, DistanceUnit.Kilometers);

            /*
            var startingPoint = new Location(initialLatitude,initialLongitude);
                        
            //Converte latitude e longitude para radianos
            double phi1 = CalculatorService.DegreesToRadians(startingPoint.Latitude);
            double lambda1 = CalculatorService.DegreesToRadians(startingPoint.Longitude);

            //Calcula as novas coordenadas
            double delta = kilometersDistance / EARTH_RADIUS_KILOMETERS;
            double theta = bearing;

            double phi2 = Math.Asin(Math.Sin(phi1) * Math.Cos(delta) + Math.Cos(phi1) * Math.Sin(delta) * Math.Cos(theta));
            double lambda2 = lambda1 + Math.Atan2(Math.Sin(theta) * Math.Sin(delta) * Math.Cos(phi1), Math.Cos(delta) - Math.Sin(phi1) * Math.Sin(phi2));

            //Converte as novas coordenadas de radianos para graus
            phi2 = CalculatorService.RadiansToDegrees(phi2);
            lambda2 = CalculatorService.RadiansToDegrees(lambda2);
            */
            var limits = (new Coordinate { Latitude = boundaries.MaxLatitude, Longitude = boundaries.MaxLongitude },
                                             new Coordinate { Latitude = boundaries.MinLatitude, Longitude = boundaries.MinLongitude});

            return limits;
        }

        private readonly ICalculatorService CalculatorService;

        public LocationService(ICalculatorService calculatorService)
        {
            CalculatorService = calculatorService;
        }
    }
    /*
    public class GeoCalculator
    {
        // Raio médio da Terra em quilômetros
        private const double EarthRadius = 6371.0;

        public static void CalculateDestination(double lat1, double lon1, double distance, double bearing, out double lat2, out double lon2)
        {
            // Converter ângulos para radianos
            lat1 = DegreesToRadians(lat1);
            lon1 = DegreesToRadians(lon1);
            bearing = DegreesToRadians(bearing);

            // Calcular nova latitude
            lat2 = Math.Asin(Math.Sin(lat1) * Math.Cos(distance / EarthRadius) +
                             Math.Cos(lat1) * Math.Sin(distance / EarthRadius) * Math.Cos(bearing));

            // Calcular nova longitude
            lon2 = lon1 + Math.Atan2(Math.Sin(bearing) * Math.Sin(distance / EarthRadius) * Math.Cos(lat1),
                                     Math.Cos(distance / EarthRadius) - Math.Sin(lat1) * Math.Sin(lat2));

            // Converter de volta para graus
            lat2 = RadiansToDegrees(lat2);
            lon2 = RadiansToDegrees(lon2);
        }

        private static double DegreesToRadians(double degrees)
        {
            return degrees * Math.PI / 180.0;
        }
        private static double RadiansToDegrees(double radians)
        {
            return radians * 180.0 / Math.PI;
        }
        

        static void Main()
        {
            // Exemplo de uso
            double initialLatitude = 37.7749; // Latitude de San Francisco, CA
            double initialLongitude = -122.4194; // Longitude de San Francisco, CA
            double distance = 100.0; // Distância em quilômetros
            double bearing = 45.0; // Direção em graus

            double finalLatitude, finalLongitude;

            CalculateDestination(initialLatitude, initialLongitude, distance, bearing, out finalLatitude, out finalLongitude);

            Console.WriteLine($"Coordenadas iniciais: {initialLatitude}, {initialLongitude}");
            Console.WriteLine($"Coordenadas finais: {finalLatitude}, {finalLongitude}");
        }
    }
    */
}
