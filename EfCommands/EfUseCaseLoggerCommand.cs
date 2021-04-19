using Application.Interfaces;
using Domain;
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

        public void Log(IUseCase useCase, IApplicationActor actor, bool success)
        {
            var user = Context.Users.Where(u => u.Username.ToLower() == actor.Identity.ToLower()).FirstOrDefault();

            Context.Logs.Add(new Domain.Log
            {
                Action = useCase.Name,
                Date = DateTime.Now,
                UserId = actor.Id,
                Success = success
            });

            Context.SaveChanges();
        }
    }
}
