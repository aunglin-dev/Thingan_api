namespace Shared.Exceptions;

public class NotFoundException(string detail) : Exception(detail)
{
}
