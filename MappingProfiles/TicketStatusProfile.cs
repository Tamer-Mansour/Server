using AutoMapper;
using Server.DTOs.TicketStatusesDTOs;
using Server.Models;

namespace Server.MappingProfiles
{
    public class TicketStatusProfile : Profile
    {
        public TicketStatusProfile()
        {
            CreateMap<TicketStatus, TicketStatusDTO>()
                .ReverseMap();

            CreateMap<TicketStatus, TicketStatusCreateDTO>()
                .ReverseMap();

            CreateMap<TicketStatus, TicketStatusUpdateDTO>()
                .ReverseMap();
        }
    }
}
