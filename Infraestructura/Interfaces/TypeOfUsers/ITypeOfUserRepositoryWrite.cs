using Entities.DTO;
using System.Threading.Tasks;

namespace Infraestructura.Interfaces.TypeOfUsers
{
    public interface ITypeOfUserRepositoryWrite
    {
        Task<TypeOfUserDTO> CreateUserAsync(TypeOfUserDTO user);
        Task<bool> UpdateUserAsync(TypeOfUserDTO user);
        Task<bool> DeleteUserAsync(int id);
    }
}
