using Microsoft.AspNetCore.Mvc;
using restAPI.DataContext.Models;
using restAPI.DataContracts;
using System.Linq;

namespace restAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TextController : ControllerBase
    {
        private DevicePositionContext _dataContext;

        public TextController(DevicePositionContext dataContext)
        {
            _dataContext = dataContext;
        }
        
        [HttpGet]
        public ActionResult<string> Get()
        {
            DeviceMapPoint position = _dataContext.DevicePositions.FirstOrDefault();

            return string.Concat("First position id DB vas recorded at: ",
                position.TimeStamp.ToShortDateString(), " ",
                position.TimeStamp.ToShortTimeString(),
                " Long: ", position.Longitude, ", Lat: ", position.Latitude);
        }

        [HttpGet("{text}")]
        public ActionResult<string> Get(string text)
        {
            return string.Concat("OK: ", text);
        }
    }
}
