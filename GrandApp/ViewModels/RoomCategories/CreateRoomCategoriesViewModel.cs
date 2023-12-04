using System.ComponentModel.DataAnnotations;

namespace GrandApp.ViewModels.RoomCategories
{
    public class CreateRoomsViewModel
    {
        [Required(ErrorMessage = "Введите категорию")]
        [Display(Name = "Категория")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Введите описание")]
        [Display(Name = "Описание")]
        public string Description { get; set; }
    }
}
