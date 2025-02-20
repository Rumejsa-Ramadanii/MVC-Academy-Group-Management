using System.ComponentModel.DataAnnotations.Schema;

namespace Academy_Group_Management.Models.Entities
{
    public class Group 
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public ICollection<Student>? Students { get; set; }
        public Instructor? Instructor { get; set; }
        [ForeignKey(nameof(InstructorId))]
        public int? InstructorId { get; set; }
    }
}
