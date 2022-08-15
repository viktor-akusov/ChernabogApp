using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ChernabogApp.Models
{
    public class Monster
    {
        [Key]
        public uint Id { get; set; }
        [DisplayName("Категория")]
        public MonsterCategory? Category { get; set; }
        [Required]
        [DisplayName("Название")]
        public string Name { get; set; } = string.Empty;
        [Required]
        [DisplayName("Минимальная кость здоровья")]
        public uint MinimalHitDice { get; set; }
        [Required]
        [DisplayName("Максимальная кость здоровья")]
        public uint MaximalHitDice { get; set; }
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
    }
}
