using AutoMapper;
using Instagram.Application.Business.Commands.Follow;
using Instagram.Application.Business.Commands.Password;
using Instagram.Application.Business.Commands.Post;
using Instagram.Application.Business.Commands.User;
using Instagram.Application.Business.Request.UserRequest;
using Instagram.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.Application.Business.Mapper
{
    public class MappingProfil : Profile
    {
        public MappingProfil()
        {
            CreateMap<Users, CreateUserCommand>();
            CreateMap<Posts, AddPostCommand>();
            //CreateMap<Users, GetUserRequest>();
            //CreateMap<Posts, GetPostsRequest>();


            //FollowRelation
            CreateMap<Follow, FollowingCommand>();

            //Password
            CreateMap<UserPassword, CreatePasswordCommand>();

        }
    }
}
