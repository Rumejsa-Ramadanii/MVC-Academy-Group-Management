using Academy_Group_Management.Models.Entities;

namespace Academy_Group_Management.Repository.Interfaces
{
    public interface IInstructorRepository
    {
        public List<Instructor> GetAll();
        public Instructor GetById(int id);

        public bool Create(Instructor instructor);
        public bool Update(Instructor instructor);
        public bool Delete(Instructor instructor);
    }
}
