using Application.DataTransfer;
using Application.Exceptions;
using Application.ICommands.WriterCommands;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.WriterEfCommand
{
    public class EfEditWriterCommand : EfBaseCommand, IEditWriterCommand
    {
        public EfEditWriterCommand(EfCinemakContext context) : base(context)
        {
        }

        public int Id => 79;

        public string Name => "Edit Writer using EntityFramework";

        public void Execute(WriterDto request)
        {
            var writer = Context.Writers.Find(request.Id);

            if (writer == null || writer.IsDeleted == true)
                throw new EntityNotFoundException("Writer");

            if (writer.Name.ToLower() != request.Name.ToLower() && Context.Writers.Any(w => w.Name.ToLower() == request.Name.ToLower()))
                throw new EntityAlreadyExistsException("Writer");

            writer.Name = request.Name;

            Context.SaveChanges();
        }
    }
}
