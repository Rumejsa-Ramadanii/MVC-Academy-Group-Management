using Academy_Group_Management.Models.Entities;

namespace Academy_Group_Management.Repository.Interfaces
{
    public interface IStudentRepository
    {
        public List<Student> GetAll();
        public Student GetById(int id);

        public bool Create(Student student);
        public bool Update(Student student);
        public bool Delete(Student student);

        public List<Group> GetGroups();
        public List<Instructor> GetInstructors();
    }
}
