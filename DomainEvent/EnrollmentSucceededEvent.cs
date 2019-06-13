namespace DomainEvent
{
    using MediatR;

    public class EnrollmentSucceededEvent : INotification
    {
        public EnrollmentSucceededEvent(string studentNumber, string fullName, string subjectCode)
        {
            this.StudentNumber = studentNumber;
            this.FullName = fullName;
            this.SubjectCode = subjectCode;
        }

        public string StudentNumber { get; set; }

        public string FullName { get; }

        public string SubjectCode { get; }
    }
}
