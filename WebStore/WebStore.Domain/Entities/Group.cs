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
    [Table("Groups")]
    public class Group
        : BaseIdEntity
    {
        [Column(TypeName = "nvarchar")]
        [StringLength(240)]
        public string Name { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }

    public class GroupEntityTypeConfiguration
        : EntityTypeConfiguration<Group>
    {
        public GroupEntityTypeConfiguration()
        {
            HasMany(x => x.Roles)
                .WithMany(x => x.Groups)
                .Map(m =>
                {
                    m.MapLeftKey("GroupId");
                    m.MapRightKey("RoleId");
                    m.ToTable("GroupRoles");
                });
        }
    }
}