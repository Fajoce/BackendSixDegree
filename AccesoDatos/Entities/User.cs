using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("Users", Schema= "SD")]
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [MaxLength(50),  Required(ErrorMessage ="This field is Required")]
        public string UserName { get; set; }
        [MaxLength(50), Required(ErrorMessage = "This field is Required")]
        public string UserLastName { get; set; }
        public int TypeOfUserId { get; set; }
        [ForeignKey("TypeOfUserId")]
        public User Users { get; set; }
        [MaxLength(50), Required(ErrorMessage = "This field is Required")]
        public string UserAdress { get; set; }
        [MaxLength(50), Required(ErrorMessage = "This field is Required")]
        public string UserTelephone { get; set; }
        [MaxLength(50), Required(ErrorMessage = "This field is Required")]

        public string password { get; set; }
        [MaxLength(10), Required(ErrorMessage = "This field is Required")]
        public string UserEmail { get; set; }
    }
}
