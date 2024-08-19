using Server.DTOs.TicketsDTOs;

namespace Server.Utilities
{
    public static class ResponseHelper
    {
        public static TicketResponseDto CreateResponse(bool isSuccess, string message, int statusCode)
        {
            return new TicketResponseDto
            {
                IsSuccess = isSuccess,
                Message = message,
                MessageCode = statusCode
            };
        }

        public static TicketResponseDto CreateDynamicErrorResponse(string entityName, int id, string operation, int statusCode)
        {
            return new TicketResponseDto
            {
                IsSuccess = false,
                Message = $"{entityName} with ID {id} could not be {operation}.",
                MessageCode = statusCode
            };
        }
    }
}