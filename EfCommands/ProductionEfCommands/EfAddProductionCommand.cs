using Application.DataTransfer;
using Application.Exceptions;
using Application.ICommands.ProductionCommands;
using Domain;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.ProductionEfCommands
{
    public class EfAddProductionCommand : EfBaseCommand, IAddProductionCommand
    {
        public EfAddProductionCommand(EfCinemakContext context) : base(context)
        {
        }

        public void Execute(ProductionDto request)
        {
            if (Context.Production.Any(p => p.Name.ToLower() == request.Name.ToLower()))
                throw new EntityAlreadyExistsException("Production");

            Context.Production.Add(new Production
            {
                Name = request.Name
            });

            Context.SaveChanges();
        }
    }
}
