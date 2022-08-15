using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ChernabogApp.Models
{
    public class MonsterCategory
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Название")]
        public string Name { get; set; }
    }
}
