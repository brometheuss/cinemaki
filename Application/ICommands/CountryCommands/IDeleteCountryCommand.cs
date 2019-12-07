using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ICommands.CountryCommands
{
    public interface IDeleteCountryCommand : ICommand<int>
    {
    }
}
