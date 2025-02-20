using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Academy_Group_Management.Models.Entities
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        [MinLength(5), MaxLength(20)]
        public string? Surname { get; set; }
        [DataType(DataType.EmailAddress)]
        public string? EmailAddress { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public string? City { get; set; }
        public string? Address { get; set; }

        //Relationalships

        public Instructor? Instructor { get; set; }
        [ForeignKey(nameof(InstructorId))]
        public int? InstructorId { get; set; }
        public Group? Group { get; set; }
        [ForeignKey(nameof(GroupId))]
        public int? GroupId { get; set; }
    }
}
