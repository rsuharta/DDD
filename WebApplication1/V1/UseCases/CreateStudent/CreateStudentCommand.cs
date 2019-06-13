namespace WebApplication1.V1.UseCases.CreateStudent
{
    using MediatR;

    using WebApplication1.Requests;

    public class CreateStudentCommand : CreateStudentRequest, IRequest<CreateStudentResponse>
    {
    }
}
