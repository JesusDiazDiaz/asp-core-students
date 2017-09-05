using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcRelaciones.Models
{
    public class Course
    {
        public int CourseID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "{0} debe tener una longitud de {1} caracteres.")]
        [Display(Name = "Curso")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$", ErrorMessage = "{0} solo puede contener caracteres")]
        public string Title { get; set; }

        [Required]
        [Range(0, 5)]
        public int Credits { get; set; }

        public ICollection<Inscripcion> Inscripciones { get; set; }
    }
}
