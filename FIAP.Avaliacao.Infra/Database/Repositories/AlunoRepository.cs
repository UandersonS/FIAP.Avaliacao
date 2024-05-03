using FIAP.Avaliacao.Domain.Entities;
using FIAP.Avaliacao.Infra.Database.Querys.Alunos;
using FIAP.Avaliacao.Infra.Database.Repositories.Interfaces;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;
using Dapper;

namespace FIAP.Avaliacao.Infra.Database.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly string _connectionString;

        public AlunoRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Fiap");
        }
        public async Task AdicionarAluno(Aluno aluno)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            await db.ExecuteAsync(AlunosQuerys.Insert, new { nome = aluno.Nome, usuario = aluno.Usuario, senha = aluno.Senha });
        }

        public async Task<Aluno> ConsultarPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
