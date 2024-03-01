using System.ComponentModel.DataAnnotations;

namespace BeeCake.Models
{
    public class CakeType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
