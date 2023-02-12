using Entities.DTO;
using Infraestructura.Interfaces.Generica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Interfaces.TypeOfUsers
{
    public interface ITypeOfUserRepositoryRead: IRepositorioGenericoRead<TypeOfUserDTO>
    {
        Task<IEnumerable<TypeOfUserDTO>> GetAllTypeOfUsers();
        Task<TypeOfUserDTO> GetTypeOfuserById(int id);
    }
}
