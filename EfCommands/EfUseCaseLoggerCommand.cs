using Application.Interfaces;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands
{
    public class EfUseCaseLoggerCommand : EfBaseCommand, IUseCaseLogger
    {
        public EfUseCaseLoggerCommand(EfCinemakContext context) : base(context)
        {
        }

        public void Log(IUseCase useCase, IApplicationActor actor)
        {
            var user = Context.Users.Where(u => u.Username.ToLower() == actor.Identity.ToLower()).FirstOrDefault();

            Context.Logs.Add(new Domain.Log
            {
                Action = useCase.Name,
                Date = DateTime.Now,
                UserId = user.Id
            });

            Context.SaveChanges();
        }
    }
}
