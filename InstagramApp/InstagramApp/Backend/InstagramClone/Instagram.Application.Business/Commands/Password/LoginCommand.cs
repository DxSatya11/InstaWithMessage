using Instagram.Application.Business.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.Application.Business.Commands.Password
{
    public class LoginCommand : IRequest<ApiResponse>
    {
        public string UserData {  get; set; }   
        public string Password { get; set; }    
    }
}
