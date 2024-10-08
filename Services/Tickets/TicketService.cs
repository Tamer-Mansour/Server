﻿using AutoMapper;
using NuGet.Protocol.Core.Types;
using Server.DTOs.Pagination;
using Server.DTOs.TicketsDTOs;
using Server.Models;
using Server.Repositories.Tickets;

namespace Server.Services.Tickets
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _repository;
        private readonly IMapper _mapper;

        public TicketService(ITicketRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PaginatedResult<TicketDTO>> GetAllAsync(int pageNumber, int pageSize)
        {
            var tickets = await _repository.GetAllAsync(pageNumber, pageSize);
            var totalItems = await _repository.GetCountAsync();

            var ticketDtos = _mapper.Map<IEnumerable<TicketDTO>>(tickets);
            return new PaginatedResult<TicketDTO>
            {
                Items = ticketDtos,
                TotalCount = totalItems,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public async Task<PaginatedResult<TicketDTO>> GetActiveTicketsAsync(int pageNumber, int pageSize)
        {
            var tickets = await _repository.GetActiveTicketsAsync(pageNumber, pageSize);
            var totalItems = await _repository.GetCountAsync();

            var ticketDtos = _mapper.Map<IEnumerable<TicketDTO>>(tickets);
            return new PaginatedResult<TicketDTO>
            {
                Items = ticketDtos,
                TotalCount = totalItems,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public async Task<TicketDTO> GetByIdAsync(int id)
        {
            var ticket = await _repository.GetByIdAsync(id);
            return ticket != null ? _mapper.Map<TicketDTO>(ticket) : null;
        }

        public async Task<TicketResponseDto> AddAsync(TicketCreateDTO ticketCreateDTO, string? assignedByUserId = null)
        {
            var ticket = _mapper.Map<Ticket>(ticketCreateDTO);
            ticket.AssignedByUserId = assignedByUserId;
            ticket.TicketCategoryAssignments = new List<TicketCategoryAssignment>();

            foreach (var categoryId in ticketCreateDTO.CategoryId)
            {
                ticket.TicketCategoryAssignments.Add(new TicketCategoryAssignment
                {
                    CategoryId = categoryId,
                    Ticket = ticket
                });
            }
            if (ticketCreateDTO.Attachments != null && ticketCreateDTO.Attachments.Any())
            {
                foreach (var attachmentDTO in ticketCreateDTO.Attachments)
                {
                    var attachment = new TicketAttachment
                    {
                        TicketId = ticket.TicketId,
                        FilePath = attachmentDTO.FilePath,
                        FileName = attachmentDTO.FileName,
                        UploadedAt = attachmentDTO.UploadedAt
                    };
                    ticket.TicketAttachments.Add(attachment);
                }
            }

            await _repository.AddAsync(ticket);

            return new TicketResponseDto
            {
                IsSuccess = true,
                Message = "Ticket created successfully",
                MessageCode = 200,
                Data = _mapper.Map<TicketDTO>(ticket)
            };
        }

        public async Task<TicketResponseDto> UpdateCustomerAsync(int ticketId, string userId, TicketUpdateCustomerDTO ticketUpdateCustomerDTO)
        {
            var ticket = await _repository.GetByIdAsync(ticketId);
            if (ticket == null)
            {
                return new TicketResponseDto
                {
                    IsSuccess = false,
                    Message = $"Ticket with ID {ticketId} could not be found.",
                    MessageCode = 404
                };
            }

            // Check if the ticket is assigned to someone else
            if (!string.IsNullOrEmpty(ticket.AssignedByUserId))
            {
                var assignedUser = await _repository.GetUserByIdAsync(ticket.AssignedByUserId);
                if (assignedUser != null)
                {
                    return new TicketResponseDto
                    {
                        IsSuccess = false,
                        Message = $"This ticket is assigned to {assignedUser.FullName}. You do not have permission to edit it.",
                        MessageCode = 403
                    };
                }
            }

            ticket.Title = ticketUpdateCustomerDTO.Title;
            ticket.Description = ticketUpdateCustomerDTO.Description;
            ticket.StatusId = ticketUpdateCustomerDTO.StatusId;
            ticket.PriorityId = ticketUpdateCustomerDTO.PriorityId;
            ticket.UpdatedAt = ticketUpdateCustomerDTO.UpdatedAt;

            ticket.TicketCategoryAssignments.Clear();
            ticket.TicketCategoryAssignments.Add(new TicketCategoryAssignment
            {
                CategoryId = ticketUpdateCustomerDTO.CategoryId,
                Ticket = ticket
            });

            await _repository.UpdateAsync(ticket);

            return new TicketResponseDto
            {
                IsSuccess = true,
                Message = "Ticket updated successfully",
                MessageCode = 200,
                Data = _mapper.Map<TicketDTO>(ticket)
            };
        }


        public async Task<TicketResponseDto> UpdateSupportAsync(int ticketId, string userId, TicketUpdateSupportDTO ticketUpdateSupportDTO)
        {
            var ticket = await _repository.GetByIdAsync(ticketId);
            if (ticket == null)
            {
                return new TicketResponseDto
                {
                    IsSuccess = false,
                    Message = $"Ticket with ID {ticketId} could not be found.",
                    MessageCode = 404
                };
            }

            _mapper.Map(ticketUpdateSupportDTO, ticket);
            await _repository.UpdateAsync(ticket);

            return new TicketResponseDto
            {
                IsSuccess = true,
                Message = "Ticket updated successfully",
                MessageCode = 200,
                Data = _mapper.Map<TicketDTO>(ticket)
            };
        }

        public async Task<TicketResponseDto> DeleteAsync(int id)
        {
            var ticket = await _repository.GetByIdAsync(id);
            if (ticket == null)
            {
                return new TicketResponseDto
                {
                    IsSuccess = false,
                    Message = $"Ticket with ID {id} could not be found.",
                    MessageCode = 404
                };
            }

            await _repository.DeleteAsync(ticket);
            return new TicketResponseDto
            {
                IsSuccess = true,
                Message = "Ticket deleted successfully",
                MessageCode = 200
            };
        }

        public async Task<TicketResponseDto> GetTicketsByPriorityAsync(int priorityId)
        {
            var tickets = await _repository.GetByPriorityAsync(priorityId);
            if (tickets == null || !tickets.Any())
            {
                return new TicketResponseDto
                {
                    IsSuccess = false,
                    Message = "No tickets found with the specified priority.",
                    MessageCode = 404
                };
            }

            var ticketDtos = _mapper.Map<IEnumerable<TicketDTO>>(tickets);
            return new TicketResponseDto
            {
                IsSuccess = true,
                Message = "Tickets retrieved successfully",
                MessageCode = 200,
                Data = ticketDtos
            };
        }

        public async Task<TicketResponseDto> GetTicketsByStatusAsync(int statusId)
        {
            var tickets = await _repository.GetByStatusAsync(statusId);
            if (tickets == null || !tickets.Any())
            {
                return new TicketResponseDto
                {
                    IsSuccess = false,
                    Message = "No tickets found with the specified status.",
                    MessageCode = 404
                };
            }

            var ticketDtos = _mapper.Map<IEnumerable<TicketDTO>>(tickets);
            return new TicketResponseDto
            {
                IsSuccess = true,
                Message = "Tickets retrieved successfully",
                MessageCode = 200,
                Data = ticketDtos
            };
        }

        public async Task<IEnumerable<TicketDTO>> GetTicketsByUserAsync(string userId)
        {
            var tickets = await _repository.GetTicketsByUserAsync(userId);
            return _mapper.Map<IEnumerable<TicketDTO>>(tickets);
        }

        public async Task<IEnumerable<TicketDTO>> GetTicketsAssignedToUserAsync(string userId)
        {
            var tickets = await _repository.GetTicketsAssignedToUserAsync(userId);
            return _mapper.Map<IEnumerable<TicketDTO>>(tickets);
        }

        public async Task<int> GetTotalTicketCountAsync()
        {
            return await _repository.GetTotalTicketCountAsync();
        }

        public async Task<int> GetActiveTicketCountAsync()
        {
            return await _repository.GetActiveTicketCountAsync();
        }

        public async Task<int> GetResolvedTicketCountAsync()
        {
            return await _repository.GetResolvedTicketCountAsync();
        }

        public async Task<int> GetHistoryTicketCountAsync()
        {
            return await _repository.GetHistoryTicketCountAsync();
        }

        public async Task<IEnumerable<TicketDTO>> GetTicketsByCategoryAsync(int categoryId)
        {
            var tickets = await _repository.GetTicketsByCategoryAsync(categoryId);
            return _mapper.Map<IEnumerable<TicketDTO>>(tickets);
        }
    }
}
