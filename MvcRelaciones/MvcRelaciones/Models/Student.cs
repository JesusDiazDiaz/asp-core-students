using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcRelaciones.Data;



namespace MvcRelaciones.Models
{
    public class Student
    {
        public int StudentID { get; set; }


        [Required]
        [StringLength(30, ErrorMessage ="{0} debe tener longitub de {1} caracteres.")]
        [Display(Name = "Nombre")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$", ErrorMessage = "{0} solo puede contener caracteres")]
        public string LastName { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "{0} de tener longitub de {1} caracteres.")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$", ErrorMessage = "{0} solo puede contener caracteres")]
        public string FirstMidName { get; set; }

        [Display(Name = "Nombre completo")]
        public string get_full_name
        {
            get
            {
                return LastName + ", " + FirstMidName;
            }
        }

        public ICollection<Inscripcion> Inscripcions { get; set; }


        private readonly SchoolContext _context;

        public Student()
        {
        }


        public Student(SchoolContext context)
        {
            _context = context;
        }


        //Metodo para listar Estudiantes
        public async Task<ICollection<Student>> ListadoEstudiantes()
        {
            var estudiante = new List<Student>();
            try
            {
                estudiante = await _context.Students.ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return estudiante;
        }


        //Metodo para ver el detalle de un estudiante, recibe como parametro el Id del estudiante
        public async Task<Student> Detalle(int? id)
        {
            Student estudiante = new Student();
            try
            {
                estudiante = await _context.Students.SingleOrDefaultAsync(m => m.StudentID == id);
                if (estudiante == null)
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return estudiante;
        }


        //Adicionar un estudiante a la base de datos
        public async Task GrabarEstudiante(Student estudiante)
        {
            _context.Add(estudiante);
            await _context.SaveChangesAsync();
        }



    }
}
