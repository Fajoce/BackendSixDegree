using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("TypeOfusers", Schema="SD")]
    public class TypeOfUser
    {
        [Key]
        public int TypeOfUserId { get; set; }
        [MaxLength(50), Required(ErrorMessage = "This field is Required")]
        public string TypeOfUserName { get; set; }
        [MaxLength(50), Required(ErrorMessage = "This field is Required")]
        public string TypeOfUserDescription { get; set; }
       
    }
}
