using System;
using efconsole.Data;
using efconsole.Entity;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace efconsole.services
{
    public class DbStorageTeacherService : IStorageTeacherService
    {
        private readonly ConsoleDbContext _context;

        public DbStorageTeacherService(ConsoleDbContext context)
        {
            _context = context;
        }

        public async Task<bool> ExistAsync(Guid id)
                => await _context.Teachers.AnyAsync(u => u.Id == id);

        public async Task<bool> ExistsAsync(string firstname)
                => await _context.Teachers.AnyAsync(u => u.Firstname == firstname);

        public async Task<Teacher> GetTeacherAsync(string firstname)
                => await _context.Teachers.FirstOrDefaultAsync(u => u.Firstname == firstname);

        public async Task<Teacher> GetTeacherAsync(Guid id)
                => await _context.Teachers.FirstOrDefaultAsync(u => u.Id == id);

        public async Task<(bool IsSuccess, Exception exception)> InsertUserAsync(Teacher teacher)
        {
            try
            {
                await _context.Teachers.AddAsync(teacher);
                await _context.SaveChangesAsync();
                return (true, null);
            }
            catch (Exception e)
            {
                return (false, e);
            }
        }

        public async Task<(bool IsSuccess, Exception exception, Teacher teacher)> RemoveAsync(Teacher teacher)
        {
            try
            {
                _context.Teachers.Remove(teacher);
                await _context.SaveChangesAsync();
                return (true, null, teacher);
            }
            catch (Exception e)
            {
                return (false, e, null);
            }
        }

        public async Task<(bool IsSuccess, Exception exception)> UpdateUserAsync(Teacher teacher)
        {
            try
            {
                var savedTeacher = await GetTeacherAsync(teacher.Id);
                _context.Remove(savedTeacher);
                await _context.SaveChangesAsync();
                await _context.Teachers.AddAsync(teacher);
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