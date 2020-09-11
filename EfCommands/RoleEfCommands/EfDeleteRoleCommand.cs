using Application.Exceptions;
using Application.ICommands.RoleCommands;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands.RoleEfCommands
{
    public class EfDeleteRoleCommand : EfBaseCommand, IDeleteRoleCommand
    {
        public EfDeleteRoleCommand(EfCinemakContext context) : base(context)
        {
        }

        public int Id => 62;

        public string Name => "Delete Role using EntityFramework";

        public void Execute(int request)
        {
            var role = Context.Roles.Find(request);

            if (role == null || role.IsDeleted == true)
                throw new EntityNotFoundException("Role");

            role.IsDeleted = true;

            Context.SaveChanges();
        }
    }
}
