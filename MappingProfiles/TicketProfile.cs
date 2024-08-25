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
            CreateMap<Ticket, TicketDTO>()
            .ForMember(dest => dest.StatusName, opt => opt.MapFrom(src => src.TicketStatus.StatusName))
            .ForMember(dest => dest.PriorityName, opt => opt.MapFrom(src => src.TicketPriority.PriorityName))
            .ForMember(dest => dest.UserFullName, opt => opt.MapFrom(src => src.User.FullName))
            .ForMember(dest => dest.AssignedByUserFullName, opt => opt.MapFrom(src => src.AssignedByUser != null ? src.AssignedByUser.FullName : string.Empty));

            // Mapping for creating/updating Ticket
            CreateMap<Ticket, TicketCreateDTO>().ReverseMap();
            CreateMap<Ticket, TicketUpdateDTO>().ReverseMap();

            CreateMap<TicketUpdateSupportDTO, Ticket>()
           .ForMember(dest => dest.AssignedByUserId, opt => opt.MapFrom(src => src.AssignedByUserId));

            CreateMap<TicketUpdateCustomerDTO, Ticket>()
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.StatusId, opt => opt.MapFrom(src => src.StatusId))
            .ForMember(dest => dest.PriorityId, opt => opt.MapFrom(src => src.PriorityId));
        }
    }
}
