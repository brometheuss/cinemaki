using Application.DataTransfer;
using Application.Exceptions;
using Application.ICommands.UserCommands;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands.UserEfCommands
{
    public class EfGetUserCommand : EfBaseCommand, IGetUserCommand
    {
        public EfGetUserCommand(EfCinemakContext context) : base(context)
        {
        }

        public ShowUserDto Execute(int request)
        {
            var user = Context.Users.Find(request);

            if (user == null || user.IsDeleted == true)
                throw new EntityNotFoundException("User");

            return new ShowUserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Username = user.Username,
                //RoleName = user.Role.Name
            };
        }
    }
}
