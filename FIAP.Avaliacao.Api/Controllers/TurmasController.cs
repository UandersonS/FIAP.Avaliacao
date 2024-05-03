using FIAP.Avaliacao.Application.UseCases.Turmas.CadastrarTurma;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FIAP.Avaliacao.Api.Controllers
{
    [Route("turmas")]
    [ApiController]
    public class TurmasController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TurmasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("adicionar-turma")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> AdicionarTurma([FromBody] CadastrarTurmaInput input)
        {
            input.Validate();

            await _mediator.Send(input);

            return Created();
        }

    }
}
