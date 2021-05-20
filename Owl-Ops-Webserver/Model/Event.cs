using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Owl_Ops_Webserver.Model
{
    [Table("Event")]
    public partial class Event
    {
        [Key]
        [Column(TypeName = "varchar(32)")]
        public string ID { get; set; }
        [Required]
        [Column(TypeName = "varchar(32)")]
        public string Sensor_ID { get; set; }
        [Column(TypeName = "tinyint")]
        public long Importance { get; set; }
        [Required]
        [Column(TypeName = "datetime")]
        public byte[] Time { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Type { get; set; }
        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Message { get; set; }

        [ForeignKey(nameof(Sensor_ID))]
        [InverseProperty("Events")]
        public virtual Sensor Sensor { get; set; }
    }
}
