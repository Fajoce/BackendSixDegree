using Domain.Data;
using Entities.DTO;
using Infraestructura.Interfaces.TypeOfUsers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository.TypeofUsers
{
    public class TypeOfUserRepositoryRead: ITypeOfUserRepositoryRead
    {
        private readonly SDDbContexto _context;

        public TypeOfUserRepositoryRead(SDDbContexto context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TypeOfUserDTO>> GetAllTypeOfUsers()
        {
            try
            {
                var lst = await(from tu in _context.TypeOfUsers
                                select new TypeOfUserDTO
                                {
                                    TypeOfUserId = tu.TypeOfUserId,
                                    TypeOfUserName = tu.TypeOfUserName,
                                    TypeOfUserDescription = tu.TypeOfUserDescription

                                }).ToListAsync();
                return lst;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<TypeOfUserDTO>> GetAllUsers()
        {
            try
            {
                var lst = await(from tu in _context.TypeOfUsers
                                select new TypeOfUserDTO
                                {
                                    TypeOfUserId = tu.TypeOfUserId,
                                    TypeOfUserName = tu.TypeOfUserName,
                                    TypeOfUserDescription = tu.TypeOfUserDescription

                                }).ToListAsync();
                return lst;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TypeOfUserDTO> GetTypeOfuserById(int id)
        {
            try
            {
                var lst = await(from tu in _context.TypeOfUsers
                                select new TypeOfUserDTO
                                {
                                    TypeOfUserId = tu.TypeOfUserId,
                                    TypeOfUserName = tu.TypeOfUserName,
                                    TypeOfUserDescription = tu.TypeOfUserDescription

                                }).FirstOrDefaultAsync(tu => tu.TypeOfUserId == id);
                return lst;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TypeOfUserDTO> GetuserById(int id)
        {
            try
            {
                var lst = await(from tu in _context.TypeOfUsers
                                select new TypeOfUserDTO
                                {
                                    TypeOfUserId = tu.TypeOfUserId,
                                    TypeOfUserName = tu.TypeOfUserName,
                                    TypeOfUserDescription = tu.TypeOfUserDescription

                                }).FirstOrDefaultAsync(tu => tu.TypeOfUserId == id);
                return lst;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
    
}
