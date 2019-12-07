using Application.Exceptions;
using Application.ICommands.UserCommands;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands.UserEfCommands
{
    public class EfDeleteUserCommand : EfBaseCommand, IDeleteUserCommand
    {
        public EfDeleteUserCommand(EfCinemakContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var user = Context.Users.Find(request);

            if (user == null || user.IsDeleted == true)
                throw new EntityNotFoundException("User");

            user.IsDeleted = true;

            Context.SaveChanges();
        }
    }
}
