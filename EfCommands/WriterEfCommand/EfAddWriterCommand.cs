using Application.DataTransfer;
using Application.Exceptions;
using Application.ICommands.WriterCommands;
using Domain;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.WriterEfCommand
{
    public class EfAddWriterCommand : EfBaseCommand, IAddWriterCommand
    {
        public EfAddWriterCommand(EfCinemakContext context) : base(context)
        {
        }

        public void Execute(WriterDto request)
        {
            if (Context.Writers.Any(w => w.Name.ToLower() == request.Name.ToLower()))
                throw new EntityAlreadyExistsException("Writer");

            Context.Writers.Add(new Writer
            {
                Name = request.Name
            });

            Context.SaveChanges();
        }
    }
}
