using Application.Exceptions;
using Application.ICommands.LanguageCommands;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands.LanguageEfCommands
{
    public class EfDeleteLanguageCommand : EfBaseCommand, IDeleteLanguageCommand
    {
        public EfDeleteLanguageCommand(EfCinemakContext context) : base(context)
        {
        }

        public int Id => 27;

        public string Name => "Delete Language using EntityFramework";

        public void Execute(int request)
        {
            var language = Context.Languages.Find(request);

            if (language == null || language.IsDeleted == true)
                throw new EntityNotFoundException("Language");

            language.IsDeleted = true;

            Context.SaveChanges();
        }
    }
}
