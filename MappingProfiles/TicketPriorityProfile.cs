using AutoMapper;
using Server.DTOs.TicketPrioritiesDTOs;
using Server.Models;

namespace Server.MappingProfiles
{
    public class TicketPriorityProfile : Profile
    {
        public TicketPriorityProfile()
        {
            CreateMap<TicketPriority, TicketPriorityDTO>()
                .ReverseMap();
            CreateMap<TicketPriority, TicketPriorityUpdateDTO>()
                .ReverseMap();
            CreateMap<TicketPriority, TicketPriorityCreateDTO>()
                .ReverseMap();
        }
    }
}
