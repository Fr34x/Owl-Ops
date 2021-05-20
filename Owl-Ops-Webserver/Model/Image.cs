using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Owl_Ops_Webserver.Model
{
    public partial class Image
    {
        [Key]
        [Column(TypeName = "varchar(32)")]
        public string ID { get; set; }
        [Required]
        [Column("Image", TypeName = "blob")]
        public byte[] Image1 { get; set; }
        [Required]
        [Column(TypeName = "datetime")]
        public byte[] Time { get; set; }
        [Required]
        [Column(TypeName = "varchar(32)")]
        public string Sensor_ID { get; set; }

        [ForeignKey(nameof(Sensor_ID))]
        [InverseProperty("Images")]
        public virtual Sensor Sensor { get; set; }
    }
}
