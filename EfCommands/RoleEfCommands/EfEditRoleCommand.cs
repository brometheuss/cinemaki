using Application.DataTransfer;
using Application.Exceptions;
using Application.ICommands.RoleCommands;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.RoleEfCommands
{
    public class EfEditRoleCommand : EfBaseCommand, IEditRoleCommand
    {
        public EfEditRoleCommand(EfCinemakContext context) : base(context)
        {
        }

        public int Id => 63;

        public string Name => "Edit Role using EntityFramework";

        public void Execute(RoleDto request)
        {
            var role = Context.Roles.Find(request.Id);

            if (role == null || role.IsDeleted == true)
                throw new EntityNotFoundException("Role");

            if (request.Name.ToLower() != role.Name.ToLower() && Context.Roles.Any(r => r.Name.ToLower() == request.Name.ToLower()))
                throw new EntityAlreadyExistsException("Role");

            role.Name = request.Name;

            Context.SaveChanges();
        }
    }
}
