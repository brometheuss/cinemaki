using Application.DataTransfer;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ICommands.LanguageCommands
{
    public interface IGetLanguageCommand : ICommand<int, LanguageDto>
    {
    }
}
