namespace WebApplication1.Services.Implementations
{
    public class CalculatorService : ICalculatorService
    {
        public double DegreesToRadians(double degrees) => degrees * Math.PI / 180;
        public double RadiansToDegrees(double radians) => radians * 180 / Math.PI;
    }
}
