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
    public class EfAddUserCasesCommand : EfBaseCommand, IAddUserCasesCommand
    {
        public EfAddUserCasesCommand(EfCinemakContext context) : base(context)
        {
        }

        public int Id => throw new NotImplementedException();

        public string Name => throw new NotImplementedException();

        public void Execute(string username)
        {
            var user = Context.Users
                .Where(user => user.Username == username)
                .FirstOrDefault();

            if (user == null || user.IsDeleted == true)
                throw new EntityNotFoundException("User");

            if (user.RoleId == 2 && user.Id != 0)
            {
                for (int i = 1; i < 200; i++)
                {
                    Context.Cases.Add(new Case
                    {
                        Number = i,
                        UserId = user.Id
                    });
                }
            }

            Context.SaveChanges();
        }
    }
}
