﻿using Server.DTOs.Pagination;
using Server.DTOs.TicketsDTOs;
using Server.Models;

namespace Server.Services.Tickets
{
    public interface ITicketService
    {
        Task<PaginatedResult<TicketDTO>> GetAllAsync(int pageNumber, int pageSize);
        Task<TicketDTO> GetByIdAsync(int id);
        Task<TicketResponseDto> AddAsync(TicketCreateDTO ticketCreateDTO, string? assignedByUserId = null);
        Task<TicketResponseDto> UpdateCustomerAsync(int id, TicketUpdateCustomerDTO ticketUpdateCustomerDTO);
        Task<TicketResponseDto> UpdateSupportAsync(int id, TicketUpdateSupportDTO ticketUpdateSupportDTO);

        Task<TicketResponseDto> DeleteAsync(int id);

        Task<TicketResponseDto> GetTicketsByPriorityAsync(int priorityId);
        Task<TicketResponseDto> GetTicketsByStatusAsync(int statusId);

        Task<IEnumerable<TicketDTO>> GetTicketsByUserAsync(string userId);
        Task<IEnumerable<TicketDTO>> GetTicketsAssignedToUserAsync(string userId);
    }
}
