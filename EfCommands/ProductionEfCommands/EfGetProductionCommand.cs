using Application.DataTransfer;
using Application.Exceptions;
using Application.ICommands.ProductionCommands;
using Application.Queries;
using Application.Responses;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands.ProductionEfCommands
{
    public class EfGetProductionCommand : EfBaseCommand, IGetProductionCommand
    {
        public EfGetProductionCommand(EfCinemakContext context) : base(context)
        {
        }

        public ProductionDto Execute(int request)
        {
            var production = Context.Production.Find(request);

            if (production == null || production.IsDeleted == true)
                throw new EntityNotFoundException("Production");

            return new ProductionDto
            {
                Id = production.Id,
                Name = production.Name
            };
        }
    }
}
