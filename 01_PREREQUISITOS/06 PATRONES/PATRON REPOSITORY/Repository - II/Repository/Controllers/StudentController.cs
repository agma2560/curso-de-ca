using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Models;
using Repository.Services;

namespace Repository.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService studentService;

        public StudentController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetAll()
        {
            return await studentService.GetAll();
        }


        // GET: api/Course/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetById(int id)
        {
            var student = await studentService.GetById(id);

            if (student == null)
            {
                return NotFound($"Estudiante con ID {id} no encontrado.");
            }

            return student;
        }

    
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Student student)
        {
            if (id != student.ID)
            {
                return BadRequest("El ID de la URL no coincide con el ID del estudiante.");
            }

            try
            {
                await studentService.Update(student);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    return NotFound($"Estudiante con ID {id} no encontrado.");
                }
                else
                {
                    throw; // Otra excepción de concurrencia
                }
            }

            return NoContent(); // Indica que la operación fue exitosa pero no hay contenido que devolver
        }


        [HttpPost]
        public async Task<ActionResult<Student>> Insert(Student student)
        {
            await studentService.Insert(student);

            return CreatedAtAction(nameof(GetById), new { id = student.ID }, student);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            await studentService.DeleteById(id);

            return NoContent(); // Indica que la operación fue exitosa pero no hay contenido que devolver
        }

        private bool StudentExists(int id)
        {
            return (studentService.GetById(id) != null);
        }

    }
}
