using Application.DataTransfer;
using Application.Exceptions;
using Application.ICommands.RoleCommands;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands.RoleEfCommands
{
    public class EfGetRoleCommand : EfBaseCommand, IGetRoleCommand
    {
        public EfGetRoleCommand(EfCinemakContext context) : base(context)
        {
        }

        public RoleDto Execute(int request)
        {
            var role = Context.Roles.Find(request);

            if (role == null || role.IsDeleted == true)
                throw new EntityNotFoundException("Role");

            return new RoleDto
            {
                Id = role.Id,
                Name = role.Name
            };
        }
    }
}
