using FIAP.Avaliacao.Application.Services.Interfaces;
using FIAP.Avaliacao.Domain.Exceptions;
using MediatR;

namespace FIAP.Avaliacao.Application.UseCases.Alunos.CadastrarAluno
{
    public class CadastrarAlunoInput : IRequest
    {
        public string Nome { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
    }

    public static class CadastrarAlunoInputExtensions
    {
        public static Domain.Entities.Aluno ToEntity(this CadastrarAlunoInput input, IAesCryptographyService cryptographyService)
        {
            return new Domain.Entities.Aluno
            {
                Nome = input.Nome,
                Senha = cryptographyService.Encrypt(input.Senha),
                Usuario = input.Usuario,
            };
        }

        public static void Validate(this CadastrarAlunoInput input)
        {
            if (input == null)
                throw new Exception("Aluno não pode ser nulo");

            if (string.IsNullOrEmpty(input.Senha))
                throw new DomainException("Obrigatório informar senha");

            if (string.IsNullOrEmpty(input.Nome))
                throw new DomainException("Obrigatório informar nome do aluno");

            if (string.IsNullOrEmpty(input.Usuario))
                throw new DomainException("Obrigatório informar usuario do aluno");

        }
    }
}
