using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModel
{
    //[Table("Classroom")]
    public class Classroom
    {
        //[Key]
        //[Column("id")]
        public int ClassroomID { get; set; }
        public string Name { get; set; }
        public int Floor { get; set; }
        public string Corridor { get; set; }

        public virtual ICollection<Student> Students { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
