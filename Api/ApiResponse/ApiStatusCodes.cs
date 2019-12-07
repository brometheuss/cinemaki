using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.ApiResponse
{
    public class ApiStatusCodes
    {
        public List<string> Errors { get; set; }

        public ApiStatusCodes()
        {
            Errors = new List<string>
            {
                "ErrorCode:200(Ok) - Request successfull.",
                "ErrorCode:201(Created) - Entity successfully created.",
                "ErrorCode:204(No Content) - Request successfully fulfilled.",
                "ErrorCode:404(Not Found) - Entity not found.",
                "ErrorCode:422(Unprocessable Entity) - Data is not valid.",
                "ErrorCode:409(Conflict) - Action not allowed.",
                "ErrorCode:500(Internal Server Error) - Server encountered an unexpected codition."
            };
        }
    }
}
