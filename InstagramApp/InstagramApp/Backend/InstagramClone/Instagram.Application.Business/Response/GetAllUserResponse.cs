using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.Application.Business.Response
{
    public class GetAllUserResponses
    {
        public List<GetAllUserResponse> GetAllUserResponse { get; set; }
    }


    public class GetAllUserResponse
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string ProfilPicture { get; set; }
    }
}
