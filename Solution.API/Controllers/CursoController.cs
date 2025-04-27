using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Solution.Application.Cursos;
using Solution.Application.DTO;

namespace Solution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        private IMediator _mediator;

        public CursoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<CursoDTO>>> Get()
        {
            return await _mediator.Send(new GetCursoQuery.GetCursoQueryRequest());
        }

        [HttpGet("{id}", Name = "GetById")]
        public async Task<ActionResult<CursoDTO>> GetById(Guid id)
        {
            var request = new GetCursoByIdQuery.GetCursoByIdQueryRequest() { Id = id };

            return await _mediator.Send(request);
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Post(CreateCursoCommand.CreateCursoCommandRequest request)
        {
            return await _mediator.Send(request);
        }
    }
}
