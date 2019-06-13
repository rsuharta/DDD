namespace Domain.Exceptions
{
    public sealed class SubjectNotFoundException : DomainException
    {
        public SubjectNotFoundException(string subjectCode)
            : base($"Subject {subjectCode} could not be found")
        {
        }
    }
}
