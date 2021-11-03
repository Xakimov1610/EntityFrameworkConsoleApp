using System;
using efconsole.Data;
using efconsole.Entity;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace efconsole.services
{
    public class DbStorageStudentService : IStorageStudentService
    {
        private readonly ConsoleDbContext _context;

        public DbStorageStudentService(ConsoleDbContext context)
        {
            _context = context;
        }

        public async Task<bool> ExistAsync(Guid id)
                => await _context.Students.AnyAsync(u => u.Id == id);

        public async Task<bool> ExistsAsync(string firstname)
                => await _context.Students.AnyAsync(u => u.Firstname == firstname);
        public async Task<Student> GetStudentAsync(string firstname)
                 => await _context.Students.FirstOrDefaultAsync(u => u.Firstname == firstname);

        public async Task<Student> GetStudentAsync(Guid id)
                => await _context.Students.FirstOrDefaultAsync(u => u.Id == id);

        public async Task<(bool IsSuccess, Exception exception)> InsertUserAsync(Student student)
        {
            try
            {
                await _context.Students.AddAsync(student);
                await _context.SaveChangesAsync();
                return (true, null);
            }
            catch (Exception e)
            {
                return (false, e);
            }
        }

        public async Task<(bool IsSuccess, Exception exception, Student student)> RemoveAsync(Student student)
        {
            try
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
                return (true, null, student);
            }
            catch (Exception e)
            {
                return (false, e, null);
            }
        }

        public async Task<(bool IsSuccess, Exception exception)> UpdateUserAsync(Student student)
        {
            try
            {
                var savedStudent = await GetStudentAsync(student.Id);
                _context.Remove(savedStudent);
                await _context.SaveChangesAsync();
                await _context.Students.AddAsync(student);
                await _context.SaveChangesAsync();

                return (true, null);

            }
            catch (Exception e)
            {
                return (false, e);
            }
        }
    }
}