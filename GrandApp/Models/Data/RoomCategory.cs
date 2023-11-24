using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace GrandApp.Models.Data
{
    public class RoomCategory
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Введите категорию")]
        [Display(Name = "Категория")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Введите описание")]
        [Display(Name = "Описание")]
        public string Description { get; set; }
    }
}
