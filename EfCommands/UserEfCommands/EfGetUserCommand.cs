using Application.DataTransfer;
using Application.Exceptions;
using Application.ICommands.UserCommands;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.UserEfCommands
{
    public class EfGetUserCommand : EfBaseCommand, IGetUserCommand
    {
        public EfGetUserCommand(EfCinemakContext context) : base(context)
        {
        }

        public int Id => 74;

        public string Name => "Get User using EntityFramework";

        public ShowUserDto Execute(int request)
        {
            var user = Context.Users
                .Include(r => r.Role)
                .Where(u => u.Id == request && u.IsDeleted == false)
                .FirstOrDefault();

            if (user == null || user.IsDeleted == true)
                throw new EntityNotFoundException("User");

            return new ShowUserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Username = user.Username,
                Password = user.Password,
                RoleName = user.Role.Name,
                RoleId = user.Role.Id
            };
        }
    }
}
