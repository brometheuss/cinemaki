using Application.DataTransfer;
using Application.Exceptions;
using Application.ICommands.LogCommands;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands.LogEfCommands
{
    public class EfGetLogCommand : EfBaseCommand, IGetLogCommand
    {
        public EfGetLogCommand(EfCinemakContext context) : base(context)
        {
        }

        public int Id => 84;

        public string Name => "Get Log using EntityFramework";

        public LogDto Execute(int request)
        {
            var log = Context.Logs.Find(request);
            var user = Context.Users.Find(log.UserId);

            if (user == null)
                user.Username = "not found";

            if (log == null)
                throw new EntityNotFoundException("Log");

            return new LogDto
            {
                Id = log.Id,
                Action = log.Action,
                Date = log.Date,
                Success = log.Success,
                UserId = log.UserId,
                Username = user.Username
            };
        }
    }
}
