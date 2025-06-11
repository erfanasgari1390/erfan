
using StudentApi.Repositories;

namespace StudentApi.Services
{
    public partial class StudentService : IStudentService
    {
        private readonly IStudentRepository _repositorys;
        public StudentService (IStudentRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<StudentDto>> GetAllAsyn()
        {
            var students = await _repository.GetAllAsync();
            return students.Select(s => new StudentDto
            {
                Id = s.Id,
                Name = s.Name,
                Age = s.Age
            }).ToList();
        }

        public async Task<StudentDto?> GetByIdAsyn(int id)
        {
            var student = await _repository.GetByIdAsync(id);
            if (student == null) return null;

            return new StudentDto
            {
                Id = student.Id,
                Name = student.Name,
                Age = student.Age
            };
        }

        public async Task<StudentDto> CreateAsyn(StudentDto dto)
        {
            var student = new Student
            {
                Name = dto.Name,
                Age = dto.Age
            };

            await _repository.AddAsync(student);

            dto.Id = student.Id;
            return dto;
        }

        public async Task<bool> UpdateAsyn(int id, StudentDto dto)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return false;

            existing.Name = dto.Name;
            existing.Age = dto.Age;

            await _repository.UpdateAsync(existing);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return false;

            await _repository.DeleteAsync(existing);
            return true;
        }
    }
}