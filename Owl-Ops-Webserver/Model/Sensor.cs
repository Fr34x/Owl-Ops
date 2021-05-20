using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Owl_Ops_Webserver.Model
{
    [Table("Sensor")]
    public partial class Sensor
    {
        public Sensor()
        {
            Events = new HashSet<Event>();
            Images = new HashSet<Image>();
            Measurements = new HashSet<Measurement>();
        }

        [Key]
        [Column(TypeName = "varchar(32)")]
        public string ID { get; set; }
        [Required]
        [Column(TypeName = "varchar(32)")]
        public string User_ID { get; set; }
        [Required]
        [Column(TypeName = "datetime")]
        public byte[] Up_Time { get; set; }
        [Column(TypeName = "datetime")]
        public byte[] End_Time { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Location { get; set; }
        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Description { get; set; }
        [Required]
        [Column(TypeName = "varchar(64)")]
        public string Secret { get; set; }

        [ForeignKey(nameof(User_ID))]
        [InverseProperty("Sensors")]
        public virtual User User { get; set; }
        [InverseProperty(nameof(Event.Sensor))]
        public virtual ICollection<Event> Events { get; set; }
        [InverseProperty(nameof(Image.Sensor))]
        public virtual ICollection<Image> Images { get; set; }
        [InverseProperty(nameof(Measurement.Sensor))]
        public virtual ICollection<Measurement> Measurements { get; set; }
    }
}
