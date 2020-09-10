using Application.DataTransfer;
using Application.ICommands;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands
{
    public class EfLoginUserCommand : EfBaseCommand, ILoginUserCommand
    {
        public EfLoginUserCommand(EfCinemakContext context) : base(context)
        {
        }

        public ShowUserDto Execute(LoginUserDto request)
        {
            var user = Context.Users.Where(x => x.Email.ToLower() == request.Email.ToLower()).Where(p => p.Password == request.Password).FirstOrDefault();

            if (user == null || user.IsDeleted == true)
                throw new ArgumentException("Invalid credentials, try again.");

            return new ShowUserDto
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Id = user.Id,
                RoleId = user.RoleId,
                Username = user.Username
            };
        }
    }
}
