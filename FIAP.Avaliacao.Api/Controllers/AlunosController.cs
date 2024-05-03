using FIAP.Avaliacao.Application.UseCases.Alunos.CadastrarAluno;
using FIAP.Avaliacao.Application.UseCases.Students.GetStudent;
using FIAP.Avaliacao.Application.UseCases.Turmas.CadastrarTurma;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FIAP.Avaliacao.Api.Controllers
{
    [ApiController]
    [Route("alunos")]
    public class AlunosController : ControllerBase
    {
        private readonly ILogger<AlunosController> _logger;
        private readonly IMediator _mediator;

        public AlunosController(ILogger<AlunosController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }


        [HttpGet("consultar-por-id/{id}")]
        public async Task<IActionResult> ConsultarAluno(int id)
        {
            var input = new ConsultarAlunoInput(id);
            await _mediator.Send(input);
            return Ok();
        }


        [HttpPost("adicionar-aluno")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> AdicionarAluno([FromBody] CadastrarAlunoInput input)
        {
            input.Validate();

            await _mediator.Send(input);

            return Created();
        }

    }
}
