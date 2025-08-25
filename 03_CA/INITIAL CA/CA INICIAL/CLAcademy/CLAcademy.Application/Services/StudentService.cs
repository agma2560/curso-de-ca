using AutoMapper;
using CLAcademy.Application.DTOs;
using CLAcademy.Application.Interfaces;
using CLAcademy.Application.Validators;
using CLAcademy.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace CLAcademy.Application.Services
{
    public class StudentService
    {
        private readonly IGenericRepository<Student> _studentRepository;
        private readonly IMapper _mapper;

        public StudentService(IGenericRepository<Student> studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<List<StudentDTO>> GetAllAsync()
        {
            var students = await _studentRepository.GetAll();
            return _mapper.Map<List<StudentDTO>>(students);
        }

        public async Task<StudentDTO?> GetById(int id)
        {
            var student = await _studentRepository.GetById(id);
            return student == null ? null : _mapper.Map<StudentDTO>(student);
        }

        // Métodos Update/Delete pueden seguir usando Student directamente
        public async Task<Student> Insert(CreateStudentDTO dto)
        {
            var errors = CreateStudentValidator.Validate(dto);

            if (errors.Any())
                throw new ValidationException(string.Join("; ", errors));

            var student = _mapper.Map<Student>(dto);
            return await _studentRepository.Insert(student);
        }

        public async Task<Student> Update(Student student)
        {
            return await _studentRepository.Update(student);
        }

        public async Task DeleteById(int id)
        {
            await _studentRepository.DeleteById(id);
        }
    }
}
