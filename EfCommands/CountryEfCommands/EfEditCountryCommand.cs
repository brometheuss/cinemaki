using Application.DataTransfer;
using Application.Exceptions;
using Application.ICommands.CountryCommands;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.CountryEfCommands
{
    public class EfEditCountryCommand : EfBaseCommand, IEditCountryCommand
    {
        public EfEditCountryCommand(EfCinemakContext context) : base(context)
        {
        }

        public int Id => 13;

        public string Name => "Edit Country using EntityFramework";

        public void Execute(CountryDto request)
        {
            var country = Context.Countries.Find(request.Id);

            if (country == null || country.IsDeleted == true)
                throw new EntityNotFoundException("Country");

            if (request.Name.ToLower() != country.Name.ToLower() && Context.Countries.Any(c => c.Name.ToLower() == request.Name.ToLower()))
                throw new EntityAlreadyExistsException("Country");

            country.Name = request.Name;

            Context.SaveChanges();
        }
    }
}
