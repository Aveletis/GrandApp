using System.ComponentModel.DataAnnotations;

namespace GrandApp.Models.Data
{
    public class Booking
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Введите дату заезда")]
        [Display(Name = "Дата заезда")]
        public DateTime ArrivaldateTime { get; set; }

        [Required(ErrorMessage = "Введите дату выезда")]
        [Display(Name = "Дату выезда")]
        public DateTime DeparturedateTime { get; set; }

        [Required(ErrorMessage = "Введите кол-во гостей")]
        [Display(Name = "Кол-во гостей")]
        public byte NumberGuests { get; set; }

        [Required(ErrorMessage = "Введите номер")]
        [Display(Name = "Идентификатор номера")]
        public Room IdRoom { get; set; }

        [Required(ErrorMessage = "Введите пользователя")]
        [Display(Name = "Идентификатор пользователя")]
        public User IdUser { get; set; }
    }
}
