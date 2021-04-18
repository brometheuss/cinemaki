using Application.DataTransfer;
using Application.Exceptions;
using Application.Helpers;
using Application.ICommands.UserCommands;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands.UserEfCommands
{
    public class EfUpdateUserPasswordCommand : EfBaseCommand, IUpdateUserPasswordCommand
    {
        public EfUpdateUserPasswordCommand(EfCinemakContext context) : base(context)
        {
        }

        public int Id => throw new NotImplementedException();

        public string Name => throw new NotImplementedException();

        public void Execute(UpdatePasswordDto request)
        {
            var user = Context.Users.Find(request.Id);

            if (user == null || user.IsDeleted == true)
                throw new EntityNotFoundException("User");

            if (request.OldPassword != user.Password)
                throw new Exception(Messages.UPDATE_PASSWORD_OLD_NOT_CORRECT);

            if (request.NewPassword != request.ConfirmNewPassword)
                throw new EntityMustHaveConfirmedPassword(Messages.UPDATE_PASSWORD_DIFFERENT);

            user.Password = request.NewPassword;

            Context.SaveChanges();
        }
    }
}
