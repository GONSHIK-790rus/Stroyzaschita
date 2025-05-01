namespace Stroyzaschita.Application.Exceptions;

public class InvalidAccountDataException: AppException {
    public InvalidAccountDataException()
        : base(401, "Invalid login or password.")
    { 
    
    }
}
