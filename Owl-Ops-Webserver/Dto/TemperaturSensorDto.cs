using Microsoft.AspNetCore.Mvc.Formatters.Xml;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Owl_Ops_Webserver.Dto
{
    public record TemperaturSensorDto()
    {
        public double Value { get; set; }
        public decimal Timestamp { get; set; }
    }
}