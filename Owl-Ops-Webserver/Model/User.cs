using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Owl_Ops_Webserver.Model
{
    [Table("User")]
    public partial class User
    {
        public User()
        {
            Sensors = new HashSet<Sensor>();
        }

        [Key]
        [Column(TypeName = "varchar(32)")]
        public string ID { get; set; }
        [Required]
        [Column(TypeName = "varchar(60)")]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "varchar(60)")]
        public string Email { get; set; }
        [Required]
        [Column(TypeName = "varchar(64)")]
        public string Password { get; set; }
        [Required]
        [Column(TypeName = "varchar(64)")]
        public string Private_Hash { get; set; }

        [InverseProperty(nameof(Sensor.User))]
        public virtual ICollection<Sensor> Sensors { get; set; }
    }
}
