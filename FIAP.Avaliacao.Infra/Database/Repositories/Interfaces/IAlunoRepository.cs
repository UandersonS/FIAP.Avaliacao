using FIAP.Avaliacao.Domain.Entities;

namespace FIAP.Avaliacao.Infra.Database.Repositories.Interfaces
{
    public interface IAlunoRepository
    {
        Task AdicionarAluno(Aluno aluno);
        Task<Aluno> ConsultarPorId(int id);
    }
}
