using Domain.Data;
using Entities.DTO;
using Infraestructura.Interfaces.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository.Users
{
    public class UsersRepositoryRead : IUserRepositoryRead
    {
        private readonly SDDbContexto _context;

        public UsersRepositoryRead(SDDbContexto context)
        {
            _context = context; 
        }
        public async Task<IEnumerable<UserDTO>> GetAllUsers()
        {
            try
            {
                var lst = await (from u in _context.Users
                           join tu in _context.TypeOfUsers
                           on u.TypeOfUserId equals tu.TypeOfUserId
                           select new UserDTO
                           {
                               UserId = u.UserId,
                               UserName = u.UserName,
                               UserLastName = u.UserLastName,
                               UserAdress = u.UserAdress,
                               UserTelephone = u.UserTelephone,
                               UserEmail = u.UserEmail,
                               TypeOfUserId = u.TypeOfUserId,
                               TypeOfUserName = tu.TypeOfUserName,
                               Password = u.password
                               
                           }).ToListAsync();
                return lst;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UserDTO> GetuserById(int id)
        {
            try
            {
                var lst = await(from u in _context.Users
                                join tu in _context.TypeOfUsers
                                on u.TypeOfUserId equals tu.TypeOfUserId
                                select new UserDTO
                                {
                                    UserId = u.UserId,
                                    UserName = u.UserName,
                                    UserLastName = u.UserLastName,
                                    UserAdress = u.UserAdress,
                                    UserTelephone = u.UserTelephone,
                                    UserEmail = u.UserEmail,
                                    TypeOfUserId = u.TypeOfUserId,
                                    TypeOfUserName = tu.TypeOfUserName,
                                    Password = u.password
                                }).FirstOrDefaultAsync(u=> u.UserId == id);
                return lst;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
