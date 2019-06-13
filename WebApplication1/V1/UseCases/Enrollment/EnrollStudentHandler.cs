namespace WebApplication1.Handlers
{
    using System.Threading;
    using System.Threading.Tasks;

    using DomainEvent;

    using global::Domain.Exceptions;

    using Infrastructure.Data;

    using MediatR;

    using WebApplication1.Commands;
    using WebApplication1.V1.UseCases.Enrollment;
    
    public class EnrollStudentHandler : IRequestHandler<EnrollStudentCommand, EnrollStudentResponse>
    {
        private readonly ISubjectRepository subjectRepository;

        private readonly IStudentRepository studentRepository;

        private readonly IMediator mediator;

        public EnrollStudentHandler(
            ISubjectRepository subjectRepository, 
            IStudentRepository studentRepository,
            IMediator mediator)
        {
            this.subjectRepository = subjectRepository;
            this.studentRepository = studentRepository;
            this.mediator = mediator;
        }

        public async Task<EnrollStudentResponse> Handle(EnrollStudentCommand request, CancellationToken cancellationToken)
        {
            var subject = await this.subjectRepository.GetAsync(request.SubjectCode, cancellationToken);
            if (subject == null)
            {
                throw new SubjectNotFoundException(request.SubjectCode);
            }

            var student = await this.studentRepository.GetAsync(request.StudentNumber, cancellationToken);
            if (student == null)
            {
                throw new StudentNotFoundException(request.StudentNumber);
            }

            student.EnrollIn(subject);
            await this.studentRepository.SaveAsync(student, cancellationToken);

            // TODO: can be refactored using decorator pattern
            await this.mediator.Publish(new EnrollmentSucceededEvent(student.StudentNumber, student.FullName, request.SubjectCode), cancellationToken);

            return new EnrollStudentResponse { StudentCode = request.StudentNumber, SubjectCode = request.SubjectCode, IsEnrolled = true};
        }
    }
}
