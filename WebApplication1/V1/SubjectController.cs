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
    public class SubjectController : ControllerBase
    {
        private readonly IMediator mediator;

        public SubjectController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(SubjectDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("{subjectCode}")]
        public async Task<IActionResult> Get(string subjectCode, CancellationToken cancellationToken)
        {
            var query = new GetSubjectQuery { SubjectCode = subjectCode };
            var dto = await this.mediator.Send(query, cancellationToken);
            return this.Ok(dto);
        }

        // TODO: real business use case, i doubt that we need this endpoint !
        [HttpPost]
        [ProducesResponseType(typeof(CreateSubjectResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Create(CreateSubjectCommand request, CancellationToken cancellationToken)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
    }
}