﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrandApp.Models.Data
{
    public class RoomCategory
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ИД")]
        public byte ID { get; set; }

        [Required(ErrorMessage = "Введите категорию")]
        [Display(Name = "Категория")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Введите описание")]
        [Display(Name = "Описание")]
        public string Description { get; set; }
    }
}
