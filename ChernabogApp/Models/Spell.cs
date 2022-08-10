using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ChernabogApp.Models
{
    public enum SpellLevel
    {
        [Display(Name = "Младшее")]
        Minor,
        [Display(Name = "Старшее")]
        Senior,
        [Display(Name = "Великое")]
        Great,
        [Display(Name = "Легендарное")]
        Legendary
    }
    public enum SpellKind
    {
        [Display(Name = "Колдовское")]
        Wizard,
        [Display(Name = "Жреческое")]
        Cleric
    }
    public enum SpellSphere
    {
        [Display(Name = "---")]
        None,
        [Display(Name = "Исцеления")]
        Healing,
        [Display(Name = "Смерти")]
        Death,
        [Display(Name = "Животных")]
        Animals,
        [Display(Name = "Страсти")]
        Passion,
        [Display(Name = "Духов")]
        Spirits,
        [Display(Name = "Солнца")]
        Sun,
        [Display(Name = "Войны")]
        War,
        [Display(Name = "Воды")]
        Water
    }
    public enum SpellTime
    {
        [Display(Name = "Мгновенно")]
        Instant,
        [Display(Name = "Основное действие")]
        MainAction,
        [Display(Name = "На ходу")]
        Running,
        [Display(Name = "5 минут")]
        FiveMinutes,
        [Display(Name = "10 минут")]
        TenMinutes,
        [Display(Name = "1 час")]
        OneHour,
        [Display(Name = "6 часов")]
        SixHours,
        [Display(Name = "1 день")]
        OneDay,
    }
    public class Spell : IValidatableObject
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Название")]
        public string Name { get; set; } = String.Empty;
        [Required]
        [EnumDataType(typeof(SpellLevel))]
        [DisplayName("Уровень")]
        public SpellLevel Level { get; set; } = SpellLevel.Minor;
        [Required]
        [EnumDataType(typeof(SpellKind))]
        [DisplayName("Вид")]
        public SpellKind Kind { get; set; } = SpellKind.Wizard;
        [EnumDataType(typeof(SpellSphere))]
        [DisplayName("Сфера")]
        public SpellSphere Sphere { get; set; } = SpellSphere.None;
        [Required]
        [EnumDataType(typeof(SpellTime))]
        [DisplayName("Время")]
        public SpellTime Time { get; set; } = SpellTime.Instant;
        [Required]
        [DisplayName("Очки колдовства/веры")]
        public byte Points { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        [DisplayName("Описание")]
        public string Description { get; set; } = String.Empty;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Kind == SpellKind.Wizard && Sphere != SpellSphere.None)
            {
                yield return new ValidationResult(
                    "Колдовские заклинания не могут принадлежать какой бы то ни было сфере.",
                    new[] { nameof(Sphere) } 
                );
            }
            if (Kind == SpellKind.Cleric && Sphere == SpellSphere.None)
            {
                yield return new ValidationResult(
                    "Жреческие заклинания должны принадлежать какой-нибудь сфере.",
                    new[] { nameof(Sphere) }
                );
            }
        }
    }
}
