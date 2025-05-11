namespace Stroyzaschita.Application.Exceptions;

public class UserAlreadyExistsException : AppException {
    public UserAlreadyExistsException(string? message = null) 
        : base(409, message ?? "User is already exists.")
    {

    }
}
