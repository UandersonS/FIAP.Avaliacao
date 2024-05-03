using Dapper;
using FIAP.Avaliacao.Domain.Entities;
using FIAP.Avaliacao.Infra.Database.Querys.Turmas;
using FIAP.Avaliacao.Infra.Database.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace FIAP.Avaliacao.Infra.Database.Repositories
{
    public class TurmaRepository : ITurmaRepository
    {
        private readonly string _connectionString;

        public TurmaRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Fiap");
        }

        public async void AdicionarTurma(Turma turma)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            await db.ExecuteAsync(TurmasQuerys.Insert, new { curso_id = turma.IdCurso, turma.Nome, turma.Ano, dataCadastro = turma.DataCadastro });
        }

        public async Task<Turma> ConsultarPorNomeAsync(string nomeTurma)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            return await db.QueryFirstOrDefaultAsync<Turma>(TurmasQuerys.ConsultarTurmaPorNome, new { Nome = nomeTurma });
        }

        public async Task<Turma> ConsultarPorIdAsync(int id)
        {
            using IDbConnection db = new SqlConnection(_connectionString);

            return await db.QueryFirstOrDefaultAsync<Turma>(TurmasQuerys.ConsultarTurmaPorId, new { Id = id });
        }
    }
}
