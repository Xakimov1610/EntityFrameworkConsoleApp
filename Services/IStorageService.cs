using System;
using efconsole.Entity;
using System.Threading.Tasks;

namespace efconsole.services
{
    public interface IStorageTeacherService
    {
        Task<(bool IsSuccess, Exception exception)> InsertUserAsync(Teacher teacher);
        Task<(bool IsSuccess, Exception exception)> UpdateUserAsync(Teacher teacher);
        Task<bool> ExistsAsync(string firstname);
        Task<bool> ExistAsync(Guid id);
        Task<(bool IsSuccess, Exception exception, Teacher teacher)> RemoveAsync(Teacher teacher);
        Task<Teacher> GetTeacherAsync(string firstname);
        Task<Teacher> GetTeacherAsync(Guid id);
    }
    
    public interface IStorageStudentService
    {
        Task<(bool IsSuccess, Exception exception)> InsertUserAsync(Student student);
        Task<(bool IsSuccess, Exception exception)> UpdateUserAsync(Student student);
        Task<bool> ExistsAsync(string firstname);
        Task<bool> ExistAsync(Guid id);
        Task<(bool IsSuccess, Exception exception, Student student)> RemoveAsync(Student student);
        Task<Student> GetStudentAsync(string firstname);
        Task<Student> GetStudentAsync(Guid id);
    }
}