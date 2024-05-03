using FIAP.Avaliacao.Application.Services.Interfaces;
using FIAP.Avaliacao.Domain.Exceptions;
using FIAP.Avaliacao.Infra.Database.Repositories.Interfaces;
using MediatR;

namespace FIAP.Avaliacao.Application.UseCases.Alunos.CadastrarAluno
{
    public class CadastrarAlunoUseCase : IRequestHandler<CadastrarAlunoInput>
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly IAesCryptographyService _cryptographyService;

        public CadastrarAlunoUseCase(IAlunoRepository alunoRepository, IAesCryptographyService cryptographyService)
        {
            _alunoRepository = alunoRepository;
            _cryptographyService = cryptographyService;
        }

        public async Task Handle(CadastrarAlunoInput request, CancellationToken cancellationToken)
        {
            this.ValidarComplexidadeSenha(request.Senha);
            var novoAluno = request.ToEntity(_cryptographyService);
            await _alunoRepository.AdicionarAluno(novoAluno);
        }

        private void ValidarComplexidadeSenha(string senha)
        {
            if (senha.Length < 8)
                throw new DomainException("Senha precisa ter mais de pelo meons 8 caracteres.");

            if (!senha.Any(char.IsUpper) || !senha.Any(char.IsLower) || !senha.Any(char.IsDigit) || senha.All(c => !char.IsLetterOrDigit(c)))
                throw new DomainException("Senha fraca, tente informar uma senha forte.");
        }
    }
}
