using Application.DataTransfer;
using Application.Exceptions;
using Application.ICommands.UserCommands;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.UserEfCommands
{
    public class EfEditUserCommand : EfBaseCommand, IEditUserCommand
    {
        public EfEditUserCommand(EfCinemakContext context) : base(context)
        {
        }

        public int Id => 73;

        public string Name => "Edit User using EntityFramework";

        public void Execute(ShowUserDto request)
        {
            var user = Context.Users.Find(request.Id);

            if (user == null || user.IsDeleted == true)
                throw new EntityNotFoundException("User");

            if (request.Username.ToLower() != user.Username.ToLower() && Context.Users.Any(u => u.Username.ToLower() == request.Username.ToLower()))
                throw new EntityAlreadyExistsException("Username");

            if (request.Email.ToLower() != user.Email.ToLower() && Context.Users.Any(u => u.Email.ToLower() == request.Email.ToLower()))
                throw new EntityAlreadyExistsException("Email");

            if (request.Password != request.ConfirmPassword)
                throw new EntityMustHaveConfirmedPassword("Password fields must match.");

            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Username = request.Username;
            user.Email = request.Email;
            user.Password = request.Password;
            user.RoleId = request.RoleId;

            Context.SaveChanges();
        }
    }
}
