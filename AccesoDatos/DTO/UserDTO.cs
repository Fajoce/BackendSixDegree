using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserLastName { get; set; }
        public int TypeOfUserId { get; set; }
        //public User Users { get; set; }
        public string TypeOfUserName { get; set; }
        public string UserAdress { get; set; }
        public string UserTelephone { get; set; }        
        public string UserEmail { get; set; }
        public string Password { get; set; }
    }
}
