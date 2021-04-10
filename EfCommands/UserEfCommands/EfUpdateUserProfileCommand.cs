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
    public class EfUpdateUserProfileCommand : EfBaseCommand, IUpdateUserProfileCommand
    {
        public EfUpdateUserProfileCommand(EfCinemakContext context) : base(context)
        {
        }

        public int Id => throw new NotImplementedException();

        public string Name => "Update user profile using EntityFramework";

        public void Execute(UpdateUserDto request)
        {
            var user = Context.Users.Find(request.Id);

            if (user == null || user.IsDeleted == true)
                throw new EntityNotFoundException("User");

            if (user.Password != request.OldPassword)
                throw new Exception("Current password is required.");

            if (request.FirstName == null || request.LastName == null || request.RoleId == 0 || request.Email == null)
                throw new EntityCannotBeNullException("Fields");

            if (request.Email.ToLower() != user.Email.ToLower() && Context.Users.Any(u => u.Email.ToLower() == request.Email.ToLower()))
                throw new EntityAlreadyExistsException("Email");

            if (request.Password != request.ConfirmPassword)
                throw new EntityMustHaveConfirmedPassword("Password fields must match.");

            if (request.Password == null)
                request.Password = user.Password;

            if(request.RoleId == 2)
            {
                user.FirstName = request.FirstName;
                user.LastName = request.LastName;
                user.RoleId = request.RoleId;
                user.Email = request.Email;
                user.Password = request.Password;
            }
            else
            {
                user.FirstName = request.FirstName;
                user.LastName = request.LastName;
                user.Email = request.Email;
                user.Password = request.Password;
            }

            Context.SaveChanges();
        }
    }
}
