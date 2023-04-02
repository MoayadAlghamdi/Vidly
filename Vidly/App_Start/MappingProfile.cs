using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Dto
            CreateMap<Customer, CustomerDto>();
            CreateMap<Movie, MovieDto>();
            CreateMap<MembershipType, MembershipTypeDto>();


            // Dto to Domain
            CreateMap<CustomerDto, Customer>()
                .ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<MovieDto, Movie>()
                .ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<MembershipTypeDto, MembershipType>()
                .ForMember(x => x.Id, opt => opt.Ignore());

        }
    }
}