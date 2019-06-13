namespace WebApplication1.Controllers.V1
{
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    using WebApplication1.Commands;

    [Route("api/v1/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IMediator mediator;

        public StudentController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(StudentDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("{studentNumber}")]
        public async Task<IActionResult> Get(string studentNumber, CancellationToken cancellationToken)
        {
            var query = new GetStudentQuery { StudentNumber = studentNumber };
            var dto = await this.mediator.Send(query, cancellationToken);
            return this.Ok(dto);
        }
    }
}