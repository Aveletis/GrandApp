using System.ComponentModel.DataAnnotations;

namespace GrandApp.ViewModels.RoomPrices
{
    public class EditRoomPricesViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите стоимость на 1м кв")]
        [Display(Name = "Стоимость на 1м кв")]
        public decimal CostOneSM { get; set; }

        [Required]
        [Display(Name = "Категория номера")]
        public byte IdRoomCategory { get; set; }
    }
}
