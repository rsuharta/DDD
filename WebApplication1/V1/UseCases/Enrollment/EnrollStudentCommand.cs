namespace WebApplication1.Commands
{
    using Contract.Requests;

    using MediatR;

    using WebApplication1.V1.UseCases.Enrollment;

    public class EnrollStudentCommand : EnrollStudentRequest, IRequest<EnrollStudentResponse>
    {
    }
}
