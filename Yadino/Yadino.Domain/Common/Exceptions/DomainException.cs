namespace Yadino.Domain.Common.Exceptions;

public sealed class DomainException(string code, string message) : Exception(message)
{
    public string Code { get; } = code;
}