using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cars.Models
{
    public class Car
    {
        [Key]
        public Guid Id { get; set; }
        [Required, Column(TypeName = "varchar(20)")]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
