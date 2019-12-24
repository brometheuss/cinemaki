using Application.DataTransfer;
using Application.Exceptions;
using Application.ICommands.WriterCommands;
using Domain;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands.WriterEfCommand
{
    public class EfGetWriterCommand : EfBaseCommand, IGetWriterCommand
    {
        public EfGetWriterCommand(EfCinemakContext context) : base(context)
        {
        }

        public WriterDto Execute(int request)
        {
            var writer = Context.Writers.Find(request);

            if (writer == null || writer.IsDeleted == true)
                throw new EntityNotFoundException("Writer");

            return new WriterDto
            {
                Id = writer.Id,
                Name = writer.Name
            };
        }
    }
}
