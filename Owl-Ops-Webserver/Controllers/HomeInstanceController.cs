using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Owl_Ops_Webserver.Controllers
{
    [ApiController]
    [ServiceFilter(typeof(CheckApiKeyFilterAttribute))]
    public class HomeInstanceController : ControllerBase
    {
        [HttpPost("temperature")]
        [ProducesResponseType(StatusCodes.)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult SaveTemperature([FromBody] SensordataDto data)
        {
            Console.WriteLine($"Received temperature {data.Temperature}°  with timestamp {data.Timestamp}.");
            return NoContent();
        }
        
        [HttpPost("heartbeat")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult SetHeartbeat([FromBody] double timestamp)
        {
            Console.WriteLine($"Received hearbeat with timestamp {timestamp}.");
            _hearbeatService.SetHeartbeat(timestamp);
            return NoContent();
        }
        
    }
}