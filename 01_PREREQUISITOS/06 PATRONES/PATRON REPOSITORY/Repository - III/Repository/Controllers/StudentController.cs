using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Repository.DTOs;
using Repository.Models;
using Repository.Services;

namespace Repository.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public StudentController(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDTO>>> GetAll()
        {
            var students = await _studentService.GetAll();
            var studentDTOs = _mapper.Map<IEnumerable<StudentDTO>>(students);
            return Ok(studentDTOs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDTO>> GetById(int id)
        {
            var student = await _studentService.GetById(id);
            if (student == null) return NotFound();

            var studentDTO = _mapper.Map<StudentDTO>(student);
            return Ok(studentDTO);
        }

        [HttpPost]
        public async Task<ActionResult<StudentDTO>> Create(StudentDTO studentDTO)
        {
            var student = _mapper.Map<Student>(studentDTO);
            var newStudent = await _studentService.Insert(student);
            return Ok(_mapper.Map<StudentDTO>(newStudent));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<StudentDTO>> Update(int id, StudentDTO studentDTO)
        {
            if (id != studentDTO.ID) return BadRequest();

            var student = _mapper.Map<Student>(studentDTO);
            var updatedStudent = await _studentService.Update(student);
            return Ok(_mapper.Map<StudentDTO>(updatedStudent));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _studentService.DeleteById(id);
            return NoContent();
        }
    }
}
