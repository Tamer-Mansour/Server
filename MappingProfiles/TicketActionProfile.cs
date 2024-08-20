using AutoMapper;
using Server.DTOs.TicketActionsDTOs;
using Server.Models;

namespace Server.MappingProfiles
{
    public class TicketActionProfile : Profile
    {
        public TicketActionProfile()
        {
            CreateMap<TicketAction, TicketActionDTO>()
                .ReverseMap();
            CreateMap<TicketAction, TicketActionListDTO>()
                .ReverseMap();
            CreateMap<TicketActionCreateDTO, TicketAction>()
                .ReverseMap();
            CreateMap<TicketActionUpdateDTO, TicketAction>()
                .ReverseMap();
        }
    }
}
