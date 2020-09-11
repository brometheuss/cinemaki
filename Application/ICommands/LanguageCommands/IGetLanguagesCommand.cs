using Application.DataTransfer;
using Application.Interfaces;
using Application.Queries;
using Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ICommands.LanguageCommands
{
    public interface IGetLanguagesCommand : IQuery<LanguageQuery, PagedResponse<LanguageDto>>
    {
    }
}
