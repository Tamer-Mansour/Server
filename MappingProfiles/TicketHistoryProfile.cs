using AutoMapper;
using Server.DTOs.TicketHistoriesDTOs;
using Server.Models;

namespace Server.MappingProfiles
{
    public class TicketHistoryProfile : Profile
    {
        public TicketHistoryProfile()
        {
            // Mapping between TicketHistory model and TicketHistoryDTO
            CreateMap<TicketHistory, TicketHistoryDTO>().ReverseMap();

            // Mapping for creating/updating TicketHistory
            CreateMap<TicketHistory, TicketHistoryCreateDTO>().ReverseMap();
            CreateMap<TicketHistory, TicketHistoryUpdateDTO>().ReverseMap();
        }
    }
}
