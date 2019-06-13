namespace Domain.Exceptions
{
    public sealed class EnrollmentException : DomainException
    {
        public EnrollmentException(string message)
            : base(message)
        {
        }
    }
}
