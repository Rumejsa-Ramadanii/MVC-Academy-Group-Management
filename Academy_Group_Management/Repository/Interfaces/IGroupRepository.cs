using Academy_Group_Management.Models.Entities;

namespace Academy_Group_Management.Repository.Interfaces
{
    public interface IGroupRepository
    {
        public List<Group> GetAll();
        public Group GetById(int id);
        public bool Create(Group group);
        public bool Update(Group group);
        public bool Delete(Group group);
        public List<Instructor> GetInstructors();

    }
}
