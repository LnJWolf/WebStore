using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WebStore.BusinessLogic.DTO.Product
{
    public class ProductViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [DisplayName("Категория")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле обязательно для заполнения")]
        public int CategoryId { get; set; }

        [DisplayName("Имя")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле обязательно для заполнения")]
        [MaxLength(200, ErrorMessage = "Превышена максимальная длина")]
        public string Name { get; set; }

        [DisplayName("Описание")]
        [MaxLength(500, ErrorMessage = "Превышена максимальная длина")]
        public string Description { get; set; }

        [DisplayName("Цена")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле обязательно для заполнения")]
        public double Price { get; set; }

        [DisplayName("Удален")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле обязательно для заполнения")]
        public bool IsDeleted { get; set; }
    }
}
