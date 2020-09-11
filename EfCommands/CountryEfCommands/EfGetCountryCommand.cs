using Application.DataTransfer;
using Application.Exceptions;
using Application.ICommands.CountryCommands;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands.CountryEfCommands
{
    public class EfGetCountryCommand : EfBaseCommand, IGetCountryCommand
    {
        public EfGetCountryCommand(EfCinemakContext context) : base(context)
        {
        }

        public int Id => 15;

        public string Name => "Get Country using EntityFramework";

        public CountryDto Execute(int request)
        {
            var country = Context.Countries.Find(request);

            if (country == null || country.IsDeleted == true)
                throw new EntityNotFoundException("Country");

            return new CountryDto
            {
                Id = country.Id,
                Name = country.Name
            };
        }
    }
}
