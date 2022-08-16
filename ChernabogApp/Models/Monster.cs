using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChernabogApp.Models
{
    public class Monster: IValidatableObject
    {
        [Key]
        public uint Id { get; set; }
        [DisplayName("Категория")]
        public int? CategoryId { get; set; }
        public MonsterCategory? Category { get; set; }
        [Required]
        [DisplayName("Название")]
        public string Name { get; set; } = string.Empty;
        [NotMapped]
        public string DisplayName { 
            get
            {
                var result = Name;
                if(Category is not null)
                {
                    result = Category.Name + " (" + result + ")";
                }
                return result;
            }
        }
        [Required]
        [DisplayName("Минимальная кость здоровья")]
        public uint MinimalHitDice { get; set; }
        [Required]
        [DisplayName("Максимальная кость здоровья")]
        public uint MaximalHitDice { get; set; }
        [NotMapped]
        public string HitDice
        {
            get
            {
                var result = MinimalHitDice.ToString();
                if(MinimalHitDice != MaximalHitDice)
                {
                    result += " - " + MaximalHitDice.ToString();
                }
                return result;
            }
        }
        [Required]
        [DisplayName("Класс брони")]
        public uint ArmorClass { get; set; }
        [Required]
        [DisplayName("Спас-бросок")]
        public uint SaveRoll { get; set; }
        [Required]
        [DisplayName("Навык")]
        public uint Skill { get; set; }
        [Required]
        [DisplayName("Движение")]
        public uint Motion { get; set; }
        [Required]
        [DisplayName("Вплавь")]
        public uint Swim { get; set; } = 0;
        [Required]
        [DisplayName("По воздуху")]
        public uint Fly { get; set; } = 0;
        [Required]
        [DisplayName("Телепортация")]
        public uint Teleport { get; set; } = 0;
        [NotMapped]
        public string Movement
        {
            get
            {
                var result = Motion.ToString();
                if (Swim != 0 || Fly != 0 || Teleport !=0)
                {
                    result = "Пешком - " + Motion.ToString() + ";\n";
                }
                if (Swim != 0)
                {
                    result += "Вплавь - " + Swim.ToString() + ";\n";
                }
                if (Fly != 0)
                {
                    result += "По воздуху - " + Fly.ToString() + ";\n";
                }
                if (Teleport != 0)
                {
                    result += "Телепорт - " + Teleport.ToString() + ";\n";
                }
                return result;
            }
        }
        [Required]
        [DisplayName("Боевой дух")]
        public uint BattleSpirit { get; set; }
        [Required]
        [DisplayName("Атака")]
        public string Attack { get; set; } = string.Empty;
        [Required]
        [DisplayName("Урон")]
        public string Damage { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.MultilineText)]
        [DisplayName("Описание")]
        public string Description { get; set; } = string.Empty;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (MinimalHitDice > MaximalHitDice)
            {
                yield return new ValidationResult(
                    "Минимальная кость здоровья не может быть больше максимальной.",
                    new[] { nameof(MinimalHitDice) }
                );
            }
        }
    }
}
