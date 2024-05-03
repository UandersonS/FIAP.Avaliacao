using FIAP.Avaliacao.Domain.Exceptions;
using FIAP.Avaliacao.Infra.Database.Repositories.Interfaces;
using MediatR;

namespace FIAP.Avaliacao.Application.UseCases.Turmas.CadastrarTurma
{
    public class CadastrarTurmaUseCase : IRequestHandler<CadastrarTurmaInput>
    {
        private readonly ITurmaRepository _turmaRepository;

        public CadastrarTurmaUseCase(ITurmaRepository turmaRepository)
        {
            _turmaRepository = turmaRepository;
        }

        public async Task Handle(CadastrarTurmaInput request, CancellationToken cancellationToken)
        {
            var novaTurma = request.ToEntity();
            await ValidarNovaTurmaAsync(novaTurma);

            _turmaRepository.AdicionarTurma(novaTurma);
        }

        private async Task ValidarNovaTurmaAsync(Domain.Entities.Turma novaTurma)
        {
            var turmaExistente = await _turmaRepository.ConsultarPorNomeAsync(novaTurma.Nome);
            
            if (turmaExistente != null)
                throw new DomainException("Turma já cadastrada.");  
        }
    }
}
