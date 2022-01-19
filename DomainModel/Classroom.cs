using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DomainModel
{
    [Table("Classroom")]
    public class Classroom
    {
        //[Key]
        //[Column("id")]
        public int ClassroomID { get; set; }
        public string Name { get; set; }
        public int Floor { get; set; }
        public string Corridor { get; set; }

        //[JsonIgnore]
        public virtual ICollection<Student> Students { get; set; }

        [JsonIgnore]
        public virtual Teacher Teacher { get; set; }
    }
}
