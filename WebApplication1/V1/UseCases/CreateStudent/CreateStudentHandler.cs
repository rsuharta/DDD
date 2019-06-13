namespace WebApplication1.V1.UseCases.CreateStudent
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using Infrastructure.Data;

    using MediatR;

    public class CreateStudentHandler : IRequestHandler<CreateStudentCommand, CreateStudentResponse>
    {
        private readonly IStudentRepository studentRepository;

        public CreateStudentHandler(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        public Task<CreateStudentResponse> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
