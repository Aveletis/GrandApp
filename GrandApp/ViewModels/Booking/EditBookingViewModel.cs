using GrandApp.Models.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GrandApp.ViewModels.Booking
{
    public class EditBookingViewModel
    {
        public byte Id { get; set; }

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

        [Required]
        public string IdUser { get; set; }


        [ForeignKey("IdUser")]
        public User User { get; set; }
    }
}
