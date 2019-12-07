using Application.DataTransfer;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ICommands.CountryCommands
{
    public interface IAddCountryCommand : ICommand<CountryDto>
    {
    }
}
