using AutoMapper;
using Server.DTOs.TicketCommentsDTOs;
using Server.Models;

namespace Server.MappingProfiles
{
    public class TicketCommentProfile : Profile
    {
        public TicketCommentProfile()
        {
            // Mapping between TicketComment model and TicketCommentDTO
            CreateMap<TicketComment, TicketCommentDTO>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
                .ReverseMap();

            // Mapping for creating/updating TicketComment
            CreateMap<TicketComment, TicketCommentCreateDTO>().ReverseMap();
            CreateMap<TicketComment, TicketCommentUpdateDTO>().ReverseMap();
        }
    }
}
