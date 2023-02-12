using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Interfaces.Generica
{
    public interface IRepositorioGenericoRead<TEntity> where TEntity: class
    {
        Task<IEnumerable<TEntity>> GetAllUsers();
        Task<TEntity> GetuserById(int id);
    }
}
