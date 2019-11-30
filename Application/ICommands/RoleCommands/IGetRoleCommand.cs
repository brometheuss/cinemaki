using Application.DataTransfer;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ICommands.RoleCommands
{
    public interface IGetRoleCommand : ICommand<int, RoleDto>
    {
    }
}
