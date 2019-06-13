namespace WebApplication1.Commands
{
    using MediatR;

    using WebApplication1.Requests;
    using WebApplication1.V1.UseCases.Enrollment;

    public class CreateSubjectCommand : CreateSubjectRequest, IRequest<CreateSubjectResponse>
    {
    }
}
