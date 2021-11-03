using System;
using System.Threading;
using System.Threading.Tasks;
using efconsole.Data;
using efconsole.Entity;
using Microsoft.Extensions.Hosting;

namespace efconsole
{
    public class ConsoleService : BackgroundService
    {
        private readonly ConsoleDbContext _context;

        public ConsoleService(ConsoleDbContext context)
        {
            _context = context;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
        k: Console.WriteLine($"Add User");
            Console.WriteLine($"Teacher or Student");
            string choose = Console.ReadLine();
            if (choose == "Teacher")
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    Console.Write("Enter firstname: ");
                    var fname = Console.ReadLine();

                    Console.Write("Enter lastname: ");
                    var lname = Console.ReadLine();

                    Console.Write("Enter email: ");
                    var email = Console.ReadLine();

                    Console.Write("Enter phone: ");
                    var phone = Console.ReadLine();

                    Console.Write("Enter dob (1996/02/28): ");
                    var dob = Console.ReadLine();

                    var teacher = new Teacher()
                    {
                        Firstname = fname,
                        Lastname = lname,
                        Email = email,
                        Phone = phone,
                        Birthdate = DateTimeOffset.Parse(dob)
                    };

                    try
                    {
                        _context.Teachers.Add(teacher);
                        await _context.SaveChangesAsync();

                        Console.WriteLine($"New teacher added: {teacher.Id}");
                    }

                    catch (Exception e)
                    {
                        var defaultColor = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.Red;

                        Console.WriteLine($"Error: {e.Message}");

                        Console.ForegroundColor = defaultColor;
                    } goto k;
                }
            }
            if (choose == "Student")
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    Console.Write("Enter firstname: ");
                    var fname = Console.ReadLine();

                    Console.Write("Enter lastname: ");
                    var lname = Console.ReadLine();

                    Console.Write("Enter email: ");
                    var email = Console.ReadLine();

                    Console.Write("Enter phone: ");
                    var phone = Console.ReadLine();

                    Console.Write("Enter dob (1996/02/28): ");
                    var dob = Console.ReadLine();

                    var student = new Student()
                    {
                        Firstname = fname,
                        Lastname = lname,
                        Email = email,
                        Phone = phone,
                        Birthdate = DateTimeOffset.Parse(dob)
                    };

                    try
                    {
                        _context.Students.Add(student);
                        await _context.SaveChangesAsync();

                        Console.WriteLine($"New student added: {student.Id}");
                    }

                    catch (Exception e)
                    {
                        var defaultColor = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.Red;

                        Console.WriteLine($"Error: {e.Message}");

                        Console.ForegroundColor = defaultColor;
                    } goto k;
                }
            }
        }
    }
}