using Entities.DTO;
using Infraestructura.Interfaces.Generica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Interfaces.Users
{
    public interface IUserRepositoryWrite:IRepositorioGenericoWrite<UserDTO>
    {
        Task<UserDTO> CreateUserAsync(UserDTO user);
        Task<bool> UpdateUserAsync(UserDTO user);
        Task<bool> DeleteUserAsync(int id);
    }
}
