using AdAstra.DataAccess.Entities;
using AdAstra.Dtos;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdAstra.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Trip, TripViewDto>();
            CreateMap<TripPostDto, Trip>();
            CreateMap<Post, PostViewDto>();
            CreateMap<PostPostDto, Post>();
            CreateMap<Comment, CommentViewDto>();
            CreateMap<CommentPostDto, Comment>();
            CreateMap<RegisterUserDto, ApplicationUser>();
        }
    }
}
