using Application.DataTransfer;
using Application.Exceptions;
using Application.ICommands.LanguageCommands;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands.LanguageEfCommands
{
    public class EfGetLanguageCommand : EfBaseCommand, IGetLanguageCommand
    {
        public EfGetLanguageCommand(EfCinemakContext context) : base(context)
        {
        }

        public LanguageDto Execute(int request)
        {
            var language = Context.Languages.Find(request);

            if (language == null || language.IsDeleted == true)
                throw new EntityNotFoundException("Language");

            return new LanguageDto
            {
                Id = language.Id,
                Name = language.Name
            };
        }
    }
}
