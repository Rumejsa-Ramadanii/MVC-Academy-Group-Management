using Academy_Group_Management.Data;
using Academy_Group_Management.Models.Entities;
using Academy_Group_Management.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Academy_Group_Management.Repository.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;
        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Student> GetAll()
        {
           var data = _context.Students
                .Include(s => s.Instructor)
                .Include(s => s.Group)
                .ToList();
            return data;
        }

        public Student GetById(int id)
        {
            return _context.Students
                 .Include(s => s.Instructor)
                 .Include(s => s.Group)
                 .FirstOrDefault() ?? throw new KeyNotFoundException();
        }

        public bool Create(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(Student student)
        {
            _context?.Students.Remove(student);
            _context?.SaveChanges();
            return true;
        }

        public bool Update(Student student)
        {
            _context.Update(student);
            _context.SaveChanges();
            return true;
        }

        public List<Group> GetGroups()
        {
            var groups = _context.Groups.ToList();
            return groups;
        }

        public List<Instructor> GetInstructors()
        {
            var instructors = _context.Instructors.ToList();
            return instructors;
        }
    }
}
