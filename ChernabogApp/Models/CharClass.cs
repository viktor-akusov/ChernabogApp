using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ChernabogApp.Models
{
    public class CharClass
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Название")]
        public string Name { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.MultilineText)]
        [DisplayName("Описание")]
        public string Description { get; set; } = string.Empty;
    }
}
