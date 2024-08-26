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
            CreateMap<TicketHistory, TicketHistoryDTO>()
                .ForMember(dest => dest.TicketTitle, opt => opt.MapFrom(src => src.Ticket.Title))
                .ForMember(dest => dest.UserFullName, opt => opt.MapFrom(src => src.Ticket.User.FullName))
                .ForMember(dest => dest.AssignedByUserId, opt => opt.MapFrom(src => src.Ticket.AssignedByUserId))
                .ForMember(dest => dest.AssignedByUserFullName, opt => opt.MapFrom(src => src.Ticket.AssignedByUser.FullName))
                .ForMember(dest => dest.ActionName, opt => opt.MapFrom(src => src.TicketAction.ActionName))
                .ReverseMap();

            // Mapping for creating/updating TicketHistory
            CreateMap<TicketHistory, TicketHistoryCreateDTO>().ReverseMap();
            CreateMap<TicketHistory, TicketHistoryUpdateDTO>().ReverseMap();
        }
    }
}
