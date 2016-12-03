using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.Domain.Entities.Base;

namespace WebStore.Domain.Entities
{
    [Table("Roles")]
    public class Role
        : BaseIdEntity
    {
        [Column(TypeName = "nvarchar")]
        public string Name { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<Group> Groups { get; set; }
    }

    public class RoleEntityTypeConfiguration : EntityTypeConfiguration<Role>
    {
        public RoleEntityTypeConfiguration()
        {
            Property(x => x.Name).IsMaxLength();
        }
    }
}