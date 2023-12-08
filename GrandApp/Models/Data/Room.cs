using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrandApp.Models.Data
{
    public class Room
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ИД")]
        public byte Id { get; set; }

        [Required(ErrorMessage = "Введите номер")]
        [Display(Name = "Номер")]
        public int Number { get; set; }

        [Required(ErrorMessage = "Введите ссылку на изображение")]
        [Display(Name = "Изображение")]
        public string Image { get; set; }

        [Required(ErrorMessage = "Введите этаж")]
        [Display(Name = "Этаж")]
        public byte Floor { get; set; }

        [Required(ErrorMessage = "Введите кол-во гостей")]
        [Display(Name = "Кол-во гостей")]
        public byte NumberGuests { get; set; }

        [Required(ErrorMessage = "Введите площадь")]
        [Display(Name = "Площадь")]
        public double Square { get; set; }

        [Required(ErrorMessage = "Введите описание")]
        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Категория")]
        public byte IdRoomCategory { get; set; }

        [Display(Name = "Категория")]
        [ForeignKey("IdRoomCategory")]
        public RoomCategory RoomCategory { get; set; }

        [Required]
        public ICollection<Reservation> Reservations { get; set; }
    }
}
