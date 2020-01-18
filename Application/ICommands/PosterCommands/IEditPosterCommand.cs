using Application.DataTransfer;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ICommands.PosterCommands
{
    public interface IEditPosterCommand : ICommand<PosterDto>
    {
    }
}
