using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.Domain.Entities.Base;

namespace WebStore.Domain.Entities
{
    [Table("Products")]
    public class Product
        : BaseIdEntity
    {
        public int CategoryId { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(240)]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(500)]
        public string Description { get; set; }

        public double Price { get; set; }

        public bool IsDeleted { get; set; }
        
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}