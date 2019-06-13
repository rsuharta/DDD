namespace WebApplication1.Commands
{
    using MediatR;
    
    public class GetStudentQuery : IRequest<StudentDto>
    {
        public string StudentNumber { get; set; }
    }
}
