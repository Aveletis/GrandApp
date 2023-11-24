using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace GrandApp.Models.Data
{
    public class Right_cs
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Введите право")]
        [Display(Name = "Право")]
        public string Right { get; set; }

        [Required(ErrorMessage = "Введите описание")]
        [Display(Name = "Описание")]
        public string Description { get; set; }
    }
}
