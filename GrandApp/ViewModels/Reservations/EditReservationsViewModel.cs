using System.ComponentModel.DataAnnotations;

namespace GrandApp.ViewModels.Reservations
{
    public class EditReservationsViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите дату заезда")]
        [Display(Name = "Дата заезда")]
        public DateTime ArrivaldateTime { get; set; }

        [Required(ErrorMessage = "Введите дату выезда")]
        [Display(Name = "Дату выезда")]
        public DateTime DeparturedateTime { get; set; }

        [Required(ErrorMessage = "Введите кол-во гостей")]
        [Display(Name = "Кол-во гостей")]
        public byte NumberGuests { get; set; }

        [Required]
        [Display(Name = "Номер")]
        public byte IdRoom { get; set; }

        [Required]
        [Display(Name = "Пользователь")]
        public int IdUser { get; set; }
    }
}
