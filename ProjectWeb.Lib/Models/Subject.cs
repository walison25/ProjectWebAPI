using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectWeb.Lib.Models
{
    public class Subject
    {
        [Key]
        public int IdSubject { get; set; }
        public string Name { get; set; }
        public double Grades { get; set; }

        public int IdCourse { get; set; }
        public virtual Course Course { get; set; }

        public int IdTeacher { get; set; }
        public virtual Teacher Teacher { get; set; }


    }
}
