using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChernabogApp.Models
{
    public class Character
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Имя")]
        public string Name { get; set; } = string.Empty;
        [Required]
        [DisplayName("Народ")]
        public int RaceId { get; set; }
        public Race Race { get; set; }
        [Required]
        [DisplayName("Класс")]
        public int CharClassId { get; set; }
        public CharClass CharClass { get; set; }
        [Required]
        [DisplayName("Цель")]
        public string Purporse { get; set; } = string.Empty;
        [Required]
        [DisplayName("Уровень")]
        public byte Level { get; set; } = 1;
        [Required]
        [DisplayName("Опыт")]
        public uint Experience { get; set; } = 0;
        [Required]
        [DisplayName("Великолепие")]
        public uint Magnificence { get; set; } = 0;
        [Required]
        [DisplayName("Максимальное количество перебросов")]
        public byte RerollsMax { get; set; } = 0;
        [Required]
        [DisplayName("Голод")]
        public byte Hunger { get; set; } = 0;
        [Required]
        [DisplayName("Жажда")]
        public byte Thirst { get; set; } = 0;

        [Required]
        [DisplayName("Сила")]
        public byte Strength { get; set; }
        [NotMapped]
        [DisplayName("Модификатор силы")]
        public int StrengthModifier
        {
            get
            {
                return CalcModifier(Strength);
            }
        }
        [Required]
        [DisplayName("Ловкость")]
        public byte Dexterity { get; set; }
        [NotMapped]
        [DisplayName("Модификатор ловкости")]
        public int DexterityModifier
        {
            get
            {
                return CalcModifier(Dexterity);
            }
        }
        [Required]
        [DisplayName("Телосложение")]
        public byte Constituiton { get; set; }
        [NotMapped]
        [DisplayName("Модификатор телосложения")]
        public int ConstitutionModifier
        {
            get
            {
                return CalcModifier(Constituiton);
            }
        }
        [Required]
        [DisplayName("Мудрость")]
        public byte Wisdom { get; set; }
        [NotMapped]
        [DisplayName("Модификатор мудрости")]
        public int WisdomModifier
        {
            get
            {
                return CalcModifier(Wisdom);
            }
        }
        [Required]
        [DisplayName("Интеллект")]
        public byte Intellgence { get; set; }
        [NotMapped]
        [DisplayName("Модификатор интеллекта")]
        public int IntellegenceModifier
        {
            get
            {
                return CalcModifier(Intellgence);
            }
        }
        [Required]
        [DisplayName("Харизма")]
        public byte Charisma { get; set; }
        [NotMapped]
        [DisplayName("Модификатор харизмы")]
        public int CharismaModifier
        {
            get
            {
                return CalcModifier(Charisma);
            }
        }

        private int CalcModifier(byte Modifier)
        {
            var result = 0;
            if (Modifier <= 3)
            {
                result = -2;
            } else if (Modifier >= 4 && Modifier <=7)
            {
                result = -1;
            } else if (Modifier >= 14 && Modifier <= 17)
            {
                result = 1;
            } else if (Modifier >= 18)
            {
                result = 2;
            }
            return result;
        }

    }
}
