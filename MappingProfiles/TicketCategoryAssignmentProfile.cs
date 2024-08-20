using AutoMapper;
using Server.DTOs.TicketCategoryAssignmentsDTOs;
using Server.Models;

namespace Server.MappingProfiles
{
    public class TicketCategoryAssignmentProfile : Profile
    {
        public TicketCategoryAssignmentProfile()
        {
            // Mapping between TicketCategoryAssignment model and TicketCategoryAssignmentDTO
            CreateMap<TicketCategoryAssignment, TicketCategoryAssignmentDTO>().ReverseMap();

            // Mapping for creating/updating TicketCategoryAssignment
            CreateMap<TicketCategoryAssignment, TicketCategoryAssignmentCreateDTO>().ReverseMap();
            CreateMap<TicketCategoryAssignment, TicketCategoryAssignmentUpdateDTO>().ReverseMap();
        }
    }
}
