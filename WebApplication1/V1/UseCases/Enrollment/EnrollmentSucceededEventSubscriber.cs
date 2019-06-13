namespace WebApplication1.V1.UseCases.Enrollment
{
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    using DomainEvent;

    using MediatR;

    public class EnrollmentSucceededEventSubscriber : INotificationHandler<EnrollmentSucceededEvent>
    {
        public async Task Handle(EnrollmentSucceededEvent notification, CancellationToken cancellationToken)
        {
            var fileContent =
                $"Dear {notification.FullName} ({notification.StudentNumber}), you were successfully enrolled in Subject {notification.SubjectCode}";

            var currentDir = Directory.GetCurrentDirectory();
            await File.WriteAllTextAsync($"{currentDir}\\enrollmentConfirmation.txt", fileContent, cancellationToken);
        }
    }
}
