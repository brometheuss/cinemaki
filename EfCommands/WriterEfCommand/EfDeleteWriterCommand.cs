using Application.Exceptions;
using Application.ICommands.WriterCommands;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands.WriterEfCommand
{
    public class EfDeleteWriterCommand : EfBaseCommand, IDeleteWriterCommand
    {
        public EfDeleteWriterCommand(EfCinemakContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var writer = Context.Writers.Find(request);

            if (writer == null || writer.IsDeleted == true)
                throw new EntityNotFoundException("Writer");

            writer.IsDeleted = true;

            Context.SaveChanges();
        }
    }
}
