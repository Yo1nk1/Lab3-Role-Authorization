using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoleAuthorizationLab3.Data
{
    [Table("Users")]
    public class User
    {
        [Key]
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Column("Login")]
        public string Login { get; set; }

        [Column("Password")]
        public string Password { get; set; }

        [Column("First_Name")]
        public string FirstName { get; set; }

        [Column("Second_Name")]
        public string SecondName { get; set; }

        [Column("Pictures")]
        public string Pictures { get; set; }

        [Column("RoleID")]
        public int? RoleID { get; set; }

        [ForeignKey("RoleID")]
        public virtual Role Role { get; set; }
    }
}
