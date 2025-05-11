namespace Stroyzaschita.Application.Exceptions;

public class InvalidAccountDataException: AppException {
    public InvalidAccountDataException(string? message = null)
        : base(401, message ?? "Invalid login or password.")
    { 
    
    }
}
