namespace Stroyzaschita.Application.Exceptions;

public abstract class AppException: Exception {
    public int StatusCode { get; }

    protected AppException(int statusCode, string exceptionMessage) 
        : base(exceptionMessage) 
    {
        StatusCode = statusCode;
    }
}
