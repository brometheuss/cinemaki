using Application.Exceptions;
using Application.ICommands.CountryCommands;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands.CountryEfCommands
{
    public class EfDeleteCountryCommand : EfBaseCommand, IDeleteCountryCommand
    {
        public EfDeleteCountryCommand(EfCinemakContext context) : base(context)
        {
        }

        public int Id => 12;

        public string Name => "Delete Country using EntityFramework";

        public void Execute(int request)
        {
            var country = Context.Countries.Find(request);

            if (country == null || country.IsDeleted == true)
                throw new EntityNotFoundException("Country");

            country.IsDeleted = true;

            Context.SaveChanges();
        }
    }
}
