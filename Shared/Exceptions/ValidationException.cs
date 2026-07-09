namespace Shared.Exceptions;

public class ValidationException(string detail) : Exception(detail)
{
}
