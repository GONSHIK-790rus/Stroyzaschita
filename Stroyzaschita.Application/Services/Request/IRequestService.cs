using Stroyzaschita.Shared.DTOs.Requests;

namespace Stroyzaschita.Application.Services.Request;

interface IRequestService {
    Task<Guid> CreateRequestAsync(CreateRequestDto dto, Guid userId);
    Task<RequestDto?> GetRequestByIdAsync(Guid requestId);
    Task<IEnumerable<RequestDto>> GetUserRequestsAsync(Guid userId);
    Task<IEnumerable<RequestDto>> GetAllRequestsAsync();
}
