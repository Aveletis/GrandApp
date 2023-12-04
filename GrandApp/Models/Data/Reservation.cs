using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrandApp.Models.Data
{
    public class Reservation
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ИД")]
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

        [Required]
        public string IdUser { get; set; }


        [ForeignKey("IdUser")]
        public User User { get; set; }
    }
}
