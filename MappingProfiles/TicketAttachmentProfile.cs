using AutoMapper;
using Server.DTOs.TicketAttachmentsDTOs;
using Server.Models;

namespace Server.MappingProfiles
{
    public class TicketAttachmentProfile : Profile
    {
        public TicketAttachmentProfile()
        {
            CreateMap<TicketAttachment, TicketAttachmentDTO>()
                .ReverseMap();

            CreateMap<TicketAttachment, TicketAttachmentListDTO>()
                .ReverseMap();

            CreateMap<TicketAttachment, TicketAttachmentCreateDTO>()
                .ReverseMap();

            CreateMap<TicketAttachment, TicketAttachmentUpdateDTO>()
                .ReverseMap();
        }
    }
}
