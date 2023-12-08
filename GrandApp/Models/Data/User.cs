using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace GrandApp.Models.Data
{
    public class User : IdentityUser
    {
        [Required(ErrorMessage = "Введите фамилию")]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Введите имя")]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Введите никнейм")]
        [Display(Name = "Никнейм")]
        public string Nickname { get; set; }

        [Required]
        public ICollection<Reservation> Reservations { get; set; }
    }
}