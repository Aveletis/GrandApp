using System.ComponentModel.DataAnnotations;

namespace GrandApp.ViewModels.Room
{
    public class CreateRoomsViewModel
    {
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
        [Display(Name = "Категория номера")]
        public byte IdRoomCategory { get; set; }
    }
}
