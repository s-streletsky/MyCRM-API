using AutoMapper;
using MyCRM_API.Models.DTO.Clients;
using MyCRM_API.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCRM_API
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<ClientEntity, ClientAllResponse>();
            CreateMap<ClientRequest, ClientEntity>();
            CreateMap<ClientEditRequest, ClientEntity>();
            CreateMap<ClientEntity, ClientResponse>();
            CreateMap<ClientEntity, ClientProfileResponse>();
        }
    }
}
