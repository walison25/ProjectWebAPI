using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectWeb.Lib.Models
{
    public class Teacher
    {
        [Key]
        public int IdTeacher { get; set; }
        public string Name { get; set; }
      
        public string DepartamentName { get; set; }
        public virtual Departament Departament { get; set; }

        public virtual List<Subject> Subject { get; set; }

    }
}
