using Academy_Group_Management.Data;
using Academy_Group_Management.Models.Entities;
using Academy_Group_Management.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Academy_Group_Management.Repository.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private readonly ApplicationDbContext _context;
        public GroupRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Group> GetAll()
        {
            var data = _context.Groups
                .Include(g => g.Instructor)
                .Include(g => g.Students)
                .ToList();
            return data;

        }

        public Group GetById(int id)
        {
            var data = _context.Groups
                        .Include(i => i.Students)
                        .Include(i => i.Instructor)
                        .FirstOrDefault(i => i.Id == id);
            return data;
        }
        public bool Create(Group group)
        {
            _context.Groups.Add(group);
            _context.SaveChanges();
            return true;

        }

        public bool Delete(Group group)
        {
            _context.Groups.Remove(group);
            _context.SaveChanges();
            return true;

        }

        public bool Update(Group group)
        {
            _context.Groups.Update(group);
            _context.SaveChanges();
            return true;
        }

        public List<Instructor> GetInstructors()
        {
            var instructors = _context.Instructors.ToList();
            return instructors;
        }
    }
}
