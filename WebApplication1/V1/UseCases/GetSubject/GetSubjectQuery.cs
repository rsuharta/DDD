namespace WebApplication1.Commands
{
    using MediatR;
    
    public class GetSubjectQuery : IRequest<SubjectDto>
    {
        public string SubjectCode { get; set; }
    }
}
