using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcRelaciones.Models
{
    public enum Grado
    {
        A, B, C, D, F
    }

    public class Inscripcion
    {

        public int ID { get; set; }
        public int EstudentID { get; set; }
        public int CourseID { get; set; }

        public Grado? Grado { get; set; }

        public Student estudiante { get; set; }
        public Course curso { get; set; }

    }
}
