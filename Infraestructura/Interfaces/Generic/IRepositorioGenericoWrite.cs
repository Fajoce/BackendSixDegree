using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Interfaces.Generica
{
    public interface IRepositorioGenericoWrite<TEntity> where TEntity: class
    {
        Task<TEntity> CreateUserAsync(TEntity user);
        Task<bool> UpdateUserAsync(TEntity user);
        Task<bool> DeleteUserAsync(int id);
    }
}
