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
    [Table("Categories")]
    public class Category
        : BaseIdEntity
    {
        public int? HeadCategoryId { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(240)]
        public string Name { get; set; }

        public bool IsDeleted { get; set; }
        

        [ForeignKey("HeadCategoryId")]
        public virtual Category HeadCategory { get; set; }

        public virtual ICollection<Category> ChildCategories { get; set; }
    }
}
