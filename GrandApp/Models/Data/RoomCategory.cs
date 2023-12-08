using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrandApp.Models.Data
{
    public class RoomCategory
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ИД")]
        public byte Id { get; set; }

        [Required(ErrorMessage = "Введите категорию")]
        [Display(Name = "Категория")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Введите описание")]
        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Required]
        public ICollection<Room> Rooms { get; set; }

        [Required]
        public ICollection<RoomPrice> RoomPrices { get; set; }
    }
}
