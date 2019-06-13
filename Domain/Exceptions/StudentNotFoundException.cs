namespace Domain.Exceptions
{
    public sealed class StudentNotFoundException : DomainException
    {
        public StudentNotFoundException(string studentNumber)
            : base($"StudentNumber {studentNumber} could not be found")
        {
        }
    }
}
