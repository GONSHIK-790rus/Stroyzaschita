namespace Stroyzaschita.Application.Exceptions;

public class UserAlreadyExistsException : AppException {
    public UserAlreadyExistsException() 
        : base(409, "User is already exists.")
    {

    }
}
