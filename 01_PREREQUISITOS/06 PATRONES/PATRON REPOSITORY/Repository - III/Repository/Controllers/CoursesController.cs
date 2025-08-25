using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Repository.DTOs;
using Repository.Models;
using Repository.Services;
using Microsoft.EntityFrameworkCore;

namespace Repository.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;
        private readonly IMapper _mapper;

        public CoursesController(ICourseService courseService, IMapper mapper)
        {
            _courseService = courseService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseDTO>>> GetAll()
        {
            var courses = await _courseService.GetAll();
            var dtos = _mapper.Map<IEnumerable<CourseDTO>>(courses);
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDTO>> GetById(int id)
        {
            var course = await _courseService.GetById(id);
            if (course == null) return NotFound($"Curso ID {id} no encontrado.");

            return Ok(_mapper.Map<CourseDTO>(course));
        }

        [HttpPost]
        public async Task<ActionResult<CourseDTO>> Insert(CourseDTO dto)
        {
            var course = _mapper.Map<Course>(dto);
            var created = await _courseService.Insert(course);
            return CreatedAtAction(nameof(GetById), new { id = created.CourseID }, _mapper.Map<CourseDTO>(created));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CourseDTO dto)
        {
            if (id != dto.CourseID) return BadRequest("El ID de la URL no coincide con el del curso.");

            try
            {
                var course = _mapper.Map<Course>(dto);
                await _courseService.Update(course);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CourseExists(id))
                    return NotFound($"Curso ID {id} no encontrado.");
                else
                    throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            await _courseService.DeleteById(id);
            return NoContent();
        }

        private async Task<bool> CourseExists(int id)
        {
            var course = await _courseService.GetById(id);
            return course != null;
        }
    }
}
