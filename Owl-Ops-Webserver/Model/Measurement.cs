using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Owl_Ops_Webserver.Model
{
    [Table("Measurement")]
    public partial class Measurement
    {
        [Key]
        [Column(TypeName = "varchar(32)")]
        public string ID { get; set; }
        [Required]
        [Column(TypeName = "varchar(32)")]
        public string Sensor_ID { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Type { get; set; }
        [Column(TypeName = "double")]
        public double Value { get; set; }
        [Required]
        [Column(TypeName = "datetime")]
        public byte[] Time { get; set; }

        [ForeignKey(nameof(Sensor_ID))]
        [InverseProperty("Measurements")]
        public virtual Sensor Sensor { get; set; }
    }
}
