using Application.DataTransfer;
using Application.Exceptions;
using Application.ICommands.CountryCommands;
using Domain;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.CountryEfCommands
{
    public class EfAddCountryCommand : EfBaseCommand, IAddCountryCommand
    {
        public EfAddCountryCommand(EfCinemakContext context) : base(context)
        {
        }

        public int Id => 11;

        public string Name => "Create Country using EntityFramework";

        public void Execute(CountryDto request)
        {
            if (Context.Countries.Any(c => c.Name.ToLower() == request.Name.ToLower()))
                throw new EntityAlreadyExistsException("Country");

            Context.Countries.Add(new Country
            {
                Name = request.Name
            });

            Context.SaveChanges();
        }
    }
}
