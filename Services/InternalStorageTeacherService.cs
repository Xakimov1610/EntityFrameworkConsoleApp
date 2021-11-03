using System;
using System.Linq;
using efconsole.Entity;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace efconsole.services
{
    public class InternalStorageTeacherService : IStorageTeacherService
    {
        private readonly List<Teacher> _teacher;
        private readonly ILogger<InternalStorageTeacherService> _logger;

        public InternalStorageTeacherService(ILogger<InternalStorageTeacherService> logger)
        {
            _teacher = new List<Teacher>();
            _logger = logger;
        }

        public Task<bool> ExistAsync(Guid id)
                => Task.FromResult<bool>(_teacher.Any(u => u.Id == id));

        public Task<bool> ExistsAsync(string firstname)
                => Task.FromResult<bool>(_teacher.Any(u => u.Firstname == firstname));


        public Task<Teacher> GetTeacherAsync(string firstname)
                => Task.FromResult<Teacher>(_teacher.FirstOrDefault(u => u.Firstname == firstname));

        public Task<Teacher> GetTeacherAsync(Guid id)
                => Task.FromResult<Teacher>(_teacher.FirstOrDefault(u => u.Id == id));

        public async Task<(bool IsSuccess, Exception exception)> InsertUserAsync(Teacher teacher)
        {
            if (await ExistAsync(teacher.Id))
            {
                return (false, new Exception("Teacher already exists!"));
            }
            _teacher.Add(teacher);
            return (true, null);
        }

        public async Task<(bool IsSuccess, Exception exception, Teacher teacher)> RemoveAsync(Teacher teacher)
        {
            if (await ExistAsync(teacher.Id))
            {
                var savedTeacher = await GetTeacherAsync(teacher.Id);
                _teacher.Remove(savedTeacher);
                return (true, null, savedTeacher);
            }
            return (false, new Exception("Teacher does not exist!"), null);
        }

        public async Task<(bool IsSuccess, Exception exception)> UpdateUserAsync(Teacher teacher)
        {
            if (await ExistAsync(teacher.Id))
            {
                var savedTeacher = await GetTeacherAsync(teacher.Id);
                _teacher.Remove(savedTeacher);
                _teacher.Add(teacher);

                return (true, null);
            }

            return (false, new Exception("User does not exist!"));
        }
    }
}