using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Teacher : Person
    {
        [Required]
        public string Discipline { get; set; }

        [Range(1000, 3000)]
        public int Salary { get; set; }

        public int ClassroomID { get; set; }
        public virtual Classroom Classroom { get; set; }
    }
}
