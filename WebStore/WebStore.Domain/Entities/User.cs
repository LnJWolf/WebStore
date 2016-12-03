using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.Domain.Entities.Base;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace WebStore.Domain.Entities
{
    [Table("Users")]
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int GroupId { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(80)]
        public string Login { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(80)]
        public string Password { get; set; }

        public DateTime DateCreated { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(80)]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(80)]
        public string Surname { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(80)]
        public string Patronymic { get; set; }

        public int? PassportSerie { get; set; }

        public int? PassportNumber { get; set; }


        [ForeignKey("GroupId")]
        public virtual Group Group { get; set; }
    }

    public class UserEntityTypeConfiguration
        : EntityTypeConfiguration<User>
    {
        public UserEntityTypeConfiguration()
        {
            Map(m =>
            {
                m.Properties(u => new
                {
                    u.Name,
                    u.Surname,
                    u.Patronymic,
                    u.DateOfBirth,
                    u.PassportNumber,
                    u.PassportSerie
                });
                m.ToTable("UserInfo");
            })
            .Map(m =>
            {
                m.Properties(u => new
                {
                    u.Id,
                    u.Login,
                    u.Password,
                    u.DateCreated,
                    u.IsDeleted,
                    u.GroupId
                });
                m.ToTable("Users");
            });
        }
    }
}