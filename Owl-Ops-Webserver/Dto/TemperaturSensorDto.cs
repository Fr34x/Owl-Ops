namespace Owl_Ops_Webserver.Dto
{
    public class TemperaturSensorDto
    {
        [HttpPost("sensordata")]
        [ProducesResponseType(StatusCodes.Status)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult SaveSensordata([FromBody] SensordataDto data)
        {
            Console.WriteLine($"Received temperature {data.Temperature}°  with timestamp {data.Timestamp}.");
            return NoContent();
        }

        /// <summary>
        /// Reagiert auf POST /api/raspberry/heartbeat und setzt den letzten empfangenen Hearbeat
        /// im Service.
        /// </summary>
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