using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Site.Domain.Entities
{
    public class Vinyl
    {
        [HiddenInput(DisplayValue = false)]
        public int VinylId { get; set; }

        [Display(Name = "Исполнитель")]
        public string Artist { get; set; }

        [Display(Name = "Название")]
        [Required(ErrorMessage = "Пожалуйста, введите название композиции")]
        public string Title { get; set; }

        [Display(Name = "Стиль")]
        [Required(ErrorMessage = "Пожалуйста, введите жанр композиции")]
        public string Style { get; set; }

        [Display(Name = "Страна")]
        public string Country { get; set; }

        [Display(Name = "Цена")]
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Пожалуйста, введите положительное значение для цены")]
        public decimal Price { get; set; }

        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
    }
}
