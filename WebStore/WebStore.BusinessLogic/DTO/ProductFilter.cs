using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStore.BusinessLogic.DTO
{
    public class ProductFilter
    {
        [DisplayName("Имя")]
        public string Name { get; set; }


        public bool IsEmpty => string.IsNullOrEmpty(Name);
    }
}