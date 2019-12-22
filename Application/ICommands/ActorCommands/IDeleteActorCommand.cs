using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ICommands.ActorCommands
{
    public interface IDeleteActorCommand : ICommand<int>
    {
    }
}
