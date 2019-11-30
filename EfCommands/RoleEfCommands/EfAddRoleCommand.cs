using Application.DataTransfer;
using Application.Exceptions;
using Application.ICommands.RoleCommands;
using Domain;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.RoleEfCommands
{
    public class EfAddRoleCommand : EfBaseCommand, IAddRoleCommand
    {
        public EfAddRoleCommand(EfCinemakContext context) : base(context)
        {
        }

        public void Execute(RoleDto request)
        {
            var query = Context.Roles.AsQueryable();

            if (Context.Roles.Any(r => r.Name.ToLower() == request.Name.ToLower()))
                throw new EntityAlreadyExistsException("Role");

            Context.Roles.Add(new Role
            {
                Name = request.Name
            });

            Context.SaveChanges();
        }
    }
}
