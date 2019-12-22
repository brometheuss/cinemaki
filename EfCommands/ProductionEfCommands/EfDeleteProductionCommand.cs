using Application.Exceptions;
using Application.ICommands.ProductionCommands;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands.ProductionEfCommands
{
    public class EfDeleteProductionCommand : EfBaseCommand, IDeleteProductionCommand
    {
        public EfDeleteProductionCommand(EfCinemakContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var production = Context.Production.Find(request);

            if (production == null || production.IsDeleted == true)
                throw new EntityNotFoundException("Production");

            production.IsDeleted = true;

            Context.SaveChanges();
        }
    }
}
