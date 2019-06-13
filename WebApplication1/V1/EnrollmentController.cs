namespace WebApplication1.Controllers.V1
{
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    using WebApplication1.Commands;
    using WebApplication1.V1.UseCases.Enrollment;

    [Route("api/v1/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly IMediator mediator;

        public EnrollmentController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        
        [HttpPost]
        [ProducesResponseType(typeof(EnrollStudentResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Create(EnrollStudentCommand request, CancellationToken cancellationToken)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
    }
}