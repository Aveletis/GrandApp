using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace GrandApp.Models.Data
{
    public class RoomPrice
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Введите идентифкатор категории")]
        [Display(Name = "Идентифкатор катгории")]
        public string IdCategory { get; set; }

        [Required(ErrorMessage = "Введите стоимость на 1м кв")]
        [Display(Name = "Стоимость на 1м кв")]
        public decimal CostOneSM { get; set; }

        [Required(ErrorMessage = "Введите дату установки цены")]
        [Display(Name = "Дата установки цены")]
        public DateTime PriceSettingdateTime { get; set; }
    }
}
