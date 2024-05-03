using FIAP.Avaliacao.Domain.Entities;

namespace FIAP.Avaliacao.Infra.Database.Repositories.Interfaces
{
    public interface ITurmaRepository
    {
        public void AdicionarTurma(Turma turma);
        public Task<Turma> ConsultarPorNomeAsync(string nomeTurma);
        public Task<Turma> ConsultarPorIdAsync(int id);
    }
}
