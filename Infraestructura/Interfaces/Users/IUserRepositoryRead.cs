using Entities.DTO;
using Infraestructura.Interfaces.Generica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Interfaces.Users
{
    public interface IUserRepositoryRead: IRepositorioGenericoRead<UserDTO>
    {
        Task<IEnumerable<UserDTO>> GetAllUsers();
        Task<UserDTO>  GetuserById(int id);
    }
}
