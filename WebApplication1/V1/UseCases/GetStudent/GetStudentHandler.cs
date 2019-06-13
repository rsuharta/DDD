namespace WebApplication1.Commands
{
    using System.Threading;
    using System.Threading.Tasks;

    using global::Domain.Exceptions;

    using Infrastructure.Data;

    using MediatR;

    public class GetStudentHandler : IRequestHandler<GetStudentQuery, StudentDto>
    {
        private readonly IStudentRepository studentRespository;

        public GetStudentHandler(IStudentRepository studentRespository)
        {
            this.studentRespository = studentRespository;
        }

        public async Task<StudentDto> Handle(GetStudentQuery request, CancellationToken cancellationToken)
        {
            // TODO: normally in real-world database, the repo returns a dto object directly from direct querying db view
            var student = await this.studentRespository.GetAsync(request.StudentNumber, cancellationToken);

            if (student == null)
            {
                throw new StudentNotFoundException(request.StudentNumber);
            }

            return new StudentDto { StudentNumber = student.StudentNumber, FullName = student.FullName };
        } 
    }
}
