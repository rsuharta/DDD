namespace WebApplication1.Commands
{
    using System.Threading;
    using System.Threading.Tasks;

    using global::Domain.Exceptions;

    using Infrastructure.Data;

    using MediatR;

    public class GetSubjectHandler : IRequestHandler<GetSubjectQuery, SubjectDto>
    {
        private readonly ISubjectRepository subjectRepository;

        public GetSubjectHandler(ISubjectRepository subjectRepository)
        {
            this.subjectRepository = subjectRepository;
        }

        public async Task<SubjectDto> Handle(GetSubjectQuery request, CancellationToken cancellationToken)
        {
            // TODO: normally in real-world database, the repo returns a dto object directly from direct querying db view
            var subject = await this.subjectRepository.GetAsync(request.SubjectCode, cancellationToken);

            if (subject == null)
            {
                throw new SubjectNotFoundException(request.SubjectCode);
            }

            return new SubjectDto { SubjectCode = request.SubjectCode, NumberOfStudentEnrolled = subject.NumberOfStudentEnrolled };
        } 
    }
}
