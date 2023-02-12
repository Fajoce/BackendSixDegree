using Domain;
using Domain.Data;
using Entities;
using Entities.DTO;
using Infraestructura.Interfaces.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public class UserRepositoryWrite : IUserRepositoryWrite
    {
        private readonly SDDbContexto _context;
        public UserRepositoryWrite(SDDbContexto context)
        {
            _context = context;
        }
        public async Task<UserDTO> CreateUserAsync(UserDTO user)
        {
            try
            {
                var entity = new User()
                {
                   // UserId = user.UserId,
                    UserName = user.UserName,
                    UserLastName = user.UserLastName,
                    UserAdress = user.UserAdress,
                    UserTelephone = user.UserTelephone,
                    UserEmail = user.UserEmail,
                    TypeOfUserId = user.TypeOfUserId,
                    password = user.Password
                };
                _context.Users.Add(entity);
                await _context.SaveChangesAsync();
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            try
            {
                var entity = new User()
                {
                    UserId = id
                };
                _context.Users.Attach(entity);
                _context.Users.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateUserAsync(UserDTO user)
        {
            var entity = await _context.Users.FirstOrDefaultAsync(p => p.UserId == user.UserId);
            entity.UserName = user.UserName;
            entity.UserLastName = user.UserLastName;
            entity.UserAdress = user.UserAdress;
            entity.UserTelephone = user.UserTelephone;
            entity.UserEmail = user.UserEmail;
            entity.TypeOfUserId = user.TypeOfUserId;
            entity.password = user.Password;
            entity.UserId = user.UserId;         
            await _context.SaveChangesAsync();
            return true; ;
        }

       }
}
