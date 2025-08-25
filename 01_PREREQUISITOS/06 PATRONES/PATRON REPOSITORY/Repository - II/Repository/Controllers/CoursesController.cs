using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Models;
using Repository.Services;

namespace Repository.Controllers
{
    [Route("api/[controller]")] // Define la ruta base para este controlador, por ejemplo: /api/Course
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService courseService;

        public CoursesController(ICourseService courseService)
        {
            this.courseService = courseService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetAll()
        {
            return await courseService.GetAll();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetById(int id)
        {
            var course = await courseService.GetById(id);
            if (course == null)
            {
                return NotFound($"Curso Id {id} no se encuentra");
            }

            return course;
        }


        // PUT: api/Course/5
        // Para actualizar, el ID en la ruta (URL) debe coincidir con el CourseID del objeto en el cuerpo de la solicitud.
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Course course)
        {
            if (id != course.CourseID)
            {
                return BadRequest("El ID de la URL no coincide con el ID del curso proporcionado.");
            }

            try
            {
                await courseService.Update(course);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CourseExists(id))
                {
                    return NotFound($"Curso con ID {id} no encontrado.");
                }
                else
                {
                    throw; // Otra excepción de concurrencia
                }
            }

            return NoContent(); // Indica que la operación fue exitosa pero no hay contenido que devolver
        }


        [HttpPost]
        public async Task<ActionResult<Course>> Insert(Course course)
        {

            await courseService.Insert(course);
            return CreatedAtAction(nameof(GetById), new { id = course.CourseID }, course);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            await courseService.DeleteById(id);
            return NoContent();
        }


        private async Task<bool> CourseExists(int id)
        {
            var course = await courseService.GetById(id);
            return course != null;
        }
    }
}

