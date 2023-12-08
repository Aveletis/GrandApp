using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrandApp.Models.Data
{
    public class RoomPrice
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ИД")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите стоимость на 1м кв")]
        [Display(Name = "Стоимость на 1м кв")]
        public decimal CostOneSM { get; set; }

        [Required(ErrorMessage = "Введите дату установки цены")]
        [Display(Name = "Дата установки цены")]
        public DateTime PriceSettingdateTime { get; set; } = DateTime.Now;

        [Required]
        [Display(Name = "Категория")]
        public byte IdRoomCategory { get; set; }

        [Display(Name = "Категория")]
        [ForeignKey("IdRoomCategory")]
        public RoomCategory RoomCategory { get; set; }
    }
}
