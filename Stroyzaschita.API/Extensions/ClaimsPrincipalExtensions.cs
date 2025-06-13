using System.Security.Claims;

namespace Stroyzaschita.API.Extensions;

public static class HttpContextExtensions {
    public static Guid GetUserId(this ClaimsPrincipal user) {
        var userIdClaim = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        return Guid.TryParse(userIdClaim, out var userId)
            ? userId
            : throw new UnauthorizedAccessException("User ID not found in token.");
    }
}
