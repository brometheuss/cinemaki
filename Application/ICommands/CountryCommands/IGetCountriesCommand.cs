using Application.DataTransfer;
using Application.Interfaces;
using Application.Queries;
using Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ICommands.CountryCommands
{
    public interface IGetCountriesCommand : ICommand<CountryQuery, PagedResponse<CountryDto>>
    {
    }
}
