using AutoMapper;
using Server.DTOs.TicketsDTOs;
using Server.Models;

namespace Server.MappingProfiles
{
    public class TicketProfile : Profile
    {
        public TicketProfile()
        {
            // Mapping between Ticket model and TicketDTO
            CreateMap<Ticket, TicketDTO>().ReverseMap();

            // Mapping for creating/updating Ticket
            CreateMap<Ticket, TicketCreateDTO>().ReverseMap();
            CreateMap<Ticket, TicketUpdateDTO>().ReverseMap();
        }
    }
}
