namespace Domain.Exceptions
{
    using System;

    public abstract class DomainException : Exception
    {
        protected DomainException(string message)
        : base (message)
        {
        }
    }
}
