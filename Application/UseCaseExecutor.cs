using Application.Exceptions;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    public class UseCaseExecutor
    {
        private readonly IApplicationActor actor;
        private readonly IUseCaseLogger logger;

        public UseCaseExecutor(IApplicationActor actor, IUseCaseLogger logger, IHttpContextAccessor accessor)
        {
            this.actor = actor;
            this.logger = logger;
        }

        public TResult ExecuteQuery<TRequest, TResult>(IQuery<TRequest, TResult> query, TRequest search)
        {
            if (!actor.AllowedUseCases.Contains(query.Id))
            {
                logger.Log(query, actor, false);
                throw new EntityNotAllowedException("You're not allowed to perform this action.");
            }
            logger.Log(query, actor, true);
            return query.Execute(search);
        }

        public void ExecuteCommand<TRequest>(
            ICommand<TRequest> command,
            TRequest request )
        {
            if (!actor.AllowedUseCases.Contains(command.Id))
            {
                logger.Log(command, actor, false);
                throw new EntityNotAllowedException("You're not allowed to perform this action.");
            }
            logger.Log(command, actor, true);
            command.Execute(request);
        }
    }
}
