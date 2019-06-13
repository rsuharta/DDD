namespace WebApplication1.Handlers
{
    using System.Threading;
    using System.Threading.Tasks;

    using Infrastructure.Data;

    using MediatR;

    using WebApplication1.Commands;
    using WebApplication1.V1.UseCases.Enrollment;

    public class CreateSubjectHandler : IRequestHandler<CreateSubjectCommand, CreateSubjectResponse>
    {
        private readonly ISubjectRepository subjectRepository;

        public CreateSubjectHandler(ISubjectRepository subjectRepository)
        {
            this.subjectRepository = subjectRepository;
        }

        public async Task<CreateSubjectResponse> Handle(CreateSubjectCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
