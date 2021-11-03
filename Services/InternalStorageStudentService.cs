using System;
using System.Linq;
using efconsole.Entity;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace efconsole.services
{
    public class InternalStorageStudentService : IStorageStudentService
    {
        private readonly List<Student> _student;
        private readonly ILogger<InternalStorageStudentService> _logger;

        public InternalStorageStudentService(ILogger<InternalStorageStudentService> logger)
        {
            _student = new List<Student>();
            _logger = logger;
        }

        public Task<bool> ExistAsync(Guid id)
                 => Task.FromResult<bool>(_student.Any(u => u.Id == id));

        public Task<bool> ExistsAsync(string firstname)
                 => Task.FromResult<bool>(_student.Any(u => u.Firstname == firstname));

        public Task<Student> GetStudentAsync(string firstname)
                => Task.FromResult<Student>(_student.FirstOrDefault(u => u.Firstname == firstname));
        public Task<Student> GetStudentAsync(Guid id)
                => Task.FromResult<Student>(_student.FirstOrDefault(u => u.Id == id));

        public async Task<(bool IsSuccess, Exception exception)> InsertUserAsync(Student student)
        {
            if (await ExistAsync(student.Id))
            {
                return (false, new Exception("Student already exists!"));
            }
            _student.Add(student);
            return (true, null);
        }

        public async Task<(bool IsSuccess, Exception exception, Student student)> RemoveAsync(Student student)
        {
            if (await ExistAsync(student.Id))
            {
                var savedTeacher = await GetStudentAsync(student.Id);
                _student.Remove(savedTeacher);
                return (true, null, savedTeacher);
            }
            return (false, new Exception("Teacher does not exist!"), null);
        }

        public async Task<(bool IsSuccess, Exception exception)> UpdateUserAsync(Student student)
        {
            if (await ExistAsync(student.Id))
            {
                var savedTeacher = await GetStudentAsync(student.Id);
                _student.Remove(savedTeacher);
                _student.Add(student);

                return (true, null);
            }

            return (false, new Exception("User does not exist!"));
        }
    }
}