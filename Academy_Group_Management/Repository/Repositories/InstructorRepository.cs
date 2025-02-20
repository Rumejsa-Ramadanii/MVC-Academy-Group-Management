using Academy_Group_Management.Data;
using Academy_Group_Management.Models.Entities;
using Academy_Group_Management.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Academy_Group_Management.Repository.Repositories
{
    public class InstructorRepository : IInstructorRepository
    {
        private readonly ApplicationDbContext _context;
        public InstructorRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Instructor> GetAll()
        {
          var data =  _context.Instructors
                         .Include(i => i.Students)
                         .Include(i => i.Groups)
                         .ToList();
            return data;
        }
        public Instructor GetById(int id)
        {
            var data = _context.Instructors
                         .Include(i => i.Students)
                         .Include(i => i.Groups)
                         .FirstOrDefault(i => i.Id == id);
            return data;
        }
        public bool Create(Instructor instructor)
        {
            _context.Instructors.Add(instructor);
            _context.SaveChanges();
            return true;
        }
        public bool Delete(Instructor instructor)
        {
           _context?.Instructors.Remove(instructor);
            _context?.SaveChanges();
            return true;
        }

        public bool Update(Instructor instructor)
        {
            _context.Instructors.Update(instructor);
            _context.SaveChanges();
            return true;
        }
       
    }
}
