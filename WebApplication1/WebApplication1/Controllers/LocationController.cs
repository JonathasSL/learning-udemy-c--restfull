using Microsoft.AspNetCore.Mvc;
using WebApplication1.Extensions;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class LocationController : ControllerBase
    {
        [HttpGet("GetLocation/{initialLatitude},{initialLongitude}/{distanceInMeters}")]
        public IActionResult Get(string initialLatitude, string initialLongitude, string distanceInMeters)
        {
                
            if (!CheckInputHasValue(initialLatitude, initialLongitude, distanceInMeters) && initialLatitude.IsNumeric() && initialLongitude.IsNumeric() && distanceInMeters.IsNumeric())
                Logger.Log(LogLevel.Warning, $"Can't find location with values for: Initial Latitude= {initialLatitude}, Initial Longitude= {initialLongitude}, Distance= {distanceInMeters}");

            var location = LocationService.CalculateCoordinates(initialLatitude.ConvertToDouble(), initialLongitude.ConvertToDouble(), distanceInMeters.ConvertToDouble());


            return Ok(location);
        }

        private bool CheckInputHasValue(params string[] inputs)
        {
            return !inputs.Any(_ => _.IsEmptyOrNull());
        }

        private readonly ILogger<LocationController> Logger;
        private readonly ILocationService LocationService;

        public LocationController(ILogger<LocationController> logger, ILocationService locationService)
        {
            Logger = logger;
            LocationService = locationService;
        }
    }
}
