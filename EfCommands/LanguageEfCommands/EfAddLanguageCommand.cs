using Application.DataTransfer;
using Application.Exceptions;
using Application.ICommands.LanguageCommands;
using Domain;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.LanguageEfCommands
{
    public class EfAddLanguageCommand : EfBaseCommand, IAddLanguageCommand
    {
        public EfAddLanguageCommand(EfCinemakContext context) : base(context)
        {
        }

        public void Execute(LanguageDto request)
        {
            if (Context.Languages.Any(l => l.Name.ToLower() == request.Name.ToLower()))
                throw new EntityAlreadyExistsException("Language");

            Context.Languages.Add(new Language
            {
                Name = request.Name
            });

            Context.SaveChanges();
        }
    }
}
