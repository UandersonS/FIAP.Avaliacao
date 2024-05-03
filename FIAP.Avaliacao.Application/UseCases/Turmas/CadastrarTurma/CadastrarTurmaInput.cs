using FIAP.Avaliacao.Application.UseCases.Alunos.CadastrarAluno;
using FIAP.Avaliacao.Domain.Exceptions;
using MediatR;

namespace FIAP.Avaliacao.Application.UseCases.Turmas.CadastrarTurma
{
    public class CadastrarTurmaInput : IRequest
    {
        public int IdCurso { get; set; }
        public string Nome { get; set; }
        public int Ano { get; set; }
        public DateTime DataCadastro { get; set; }
    }

    public static class CadastrarTurmaInputExtensions
    {
        public static Domain.Entities.Turma ToEntity(this CadastrarTurmaInput input)
        {
            return new Domain.Entities.Turma
            {
                IdCurso = input.IdCurso,
                Nome = input.Nome,
                Ano = input.Ano,
                DataCadastro = input.DataCadastro,
            };
        }

        public static void Validate(this CadastrarTurmaInput input)
        {
            if (input == null)
                throw new Exception("Aluno não pode ser nulo");

            if (string.IsNullOrEmpty(input.Nome))
                throw new DomainException("Obrigatório informar nome da turma.");

            if (input.IdCurso < 1)
                throw new DomainException("id do curso em formato incorreto.");

            if (input.DataCadastro < DateTime.Today)
                throw new DomainException("Data de Cadastro da turma não pode ser anterior ao dia atual.");

            if (input.Ano < DateTime.Today.Year)
                throw new DomainException("Ano não pode ser anterior ao ano atual.");

            if (input.DataCadastro.Year != input.Ano)
                throw new DomainException("Ano da data de Cadastro diferente do ano informado.");
        }
    }
}
