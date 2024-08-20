using AutoMapper;
using Server.DTOs.TicketCategoriesDTOs;

using Server.Models;

namespace Server.MappingProfiles
{
    public class TicketCategoryProfile : Profile
    {
        public TicketCategoryProfile()
        {
            // Mapping between TicketCategory model and TicketCategoryDTO
            CreateMap<TicketCategory, TicketCategoryDTO>().ReverseMap();

            // Mapping for creating/updating TicketCategory
            CreateMap<TicketCategory, TicketCategoryCreateDTO>().ReverseMap();
            CreateMap<TicketCategory, TicketCategoryUpdateDTO>().ReverseMap();
        }
    }
}
