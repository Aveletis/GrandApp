using System.ComponentModel.DataAnnotations;

namespace GrandApp.ViewModels.Users
{
    public class EditUsersViewModel
    {
        [Required]
        public string Id { get; set; }

        [Required(ErrorMessage = "Введите E-mail")]
        [Display(Name = "E-mail")]
       // [DataType(DataType.EmailAddress, ErrorMessage = "Введите корретный E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Введите фамилию")]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Введите имя")]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Введите никнейм")]
        [Display(Name = "Никнейм")]
        public string Nickname { get; set; }
    }
}
