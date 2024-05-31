using Instagram.Application.Business.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.Application.Business.Query.User
{
    public record GetAllUserQuery : IRequest<GetAllUserResponses>;
   
}
