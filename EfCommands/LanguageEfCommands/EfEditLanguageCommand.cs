using Application.DataTransfer;
using Application.Exceptions;
using Application.ICommands.LanguageCommands;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.LanguageEfCommands
{
    public class EfEditLanguageCommand : EfBaseCommand, IEditLanguageCommand
    {
        public EfEditLanguageCommand(EfCinemakContext context) : base(context)
        {
        }

        public int Id => 28;

        public string Name => "Edit Language using EntityFramework";

        public void Execute(LanguageDto request)
        {
            var language = Context.Languages.Find(request.Id);

            if (language == null || language.IsDeleted == true)
                throw new EntityNotFoundException("Language");

            if (request.Name.ToLower() != language.Name.ToLower() && Context.Languages.Any(l => l.Name.ToLower() == request.Name.ToLower()))
                throw new EntityAlreadyExistsException("Language");

            language.Name = request.Name;

            Context.SaveChanges();
        }
    }
}
