using Application.DataTransfer;
using Application.Exceptions;
using Application.ICommands.ProductionCommands;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.ProductionEfCommands
{
    public class EfEditProductionCommand : EfBaseCommand, IEditProductionCommand
    {
        public EfEditProductionCommand(EfCinemakContext context) : base(context)
        {
        }

        public int Id => 43;

        public string Name => "Edit Production using EntityFramework";

        public void Execute(ProductionDto request)
        {
            var production = Context.Production.Find(request.Id);

            if (production == null || production.IsDeleted == true)
                throw new EntityNotFoundException("Production");

            if (request.Name.ToLower() != production.Name.ToLower() && Context.Production.Any(p => p.Name.ToLower() == request.Name.ToLower()))
                throw new EntityAlreadyExistsException("Production");

            if (request.Name == "")
                throw new EntityCannotBeNullException("Production");

            production.Name = request.Name;

            Context.SaveChanges();
        }
    }
}
