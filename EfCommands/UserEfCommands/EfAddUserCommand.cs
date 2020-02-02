using Application.DataTransfer;
using Application.Exceptions;
using Application.ICommands.UserCommands;
using Domain;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.UserEfCommands
{
    public class EfAddUserCommand : EfBaseCommand, IAddUserCommand
    {
        public EfAddUserCommand(EfCinemakContext context) : base(context)
        {
        }

        public void Execute(AddUserDto request)
        {
            if (Context.Users.Any(u => u.Username.ToLower() == request.Username.ToLower()))
                throw new EntityAlreadyExistsException("User with that username");

            if (Context.Users.Any(u => u.Email.ToLower() == request.Email.ToLower()))
                throw new EntityAlreadyExistsException("User with that email");

            Context.Users.Add(new User
            {
                FirstName = request.Username,
                LastName = request.LastName,
                Username = request.Username,
                Email = request.Email,
                Password = request.Password,
                RoleId = request.RoleId
            });

            Context.SaveChanges();
        }
    }
}
