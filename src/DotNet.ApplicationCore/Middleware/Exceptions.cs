using System;

namespace DotNet.ApplicationCore.Middleware
{
    public class BadRequestException(string message) : Exception(message)
    {
    }
    public class KeyNotFoundException(string message) : Exception(message)
    {
    }
    public class NotFoundException(string message) : Exception(message)
    {
    }
    public class NotImplementedException(string message) : Exception(message)
    {
    }
    public class UnauthorizedAccessException(string message) : Exception(message)
    {
    }
    public class HadReferanceException(string message) : Exception(message)
    {
    }
}
