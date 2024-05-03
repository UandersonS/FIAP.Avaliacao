namespace FIAP.Avaliacao.Infra.Database.Querys.Alunos
{
    public class AlunosQuerys
    {
        public static string ConsultarAlunoPorId =>
           @"
                SELECT
                    Aluno.Id AS Id,
                    Aluno.Nome AS Nome,
                    Aluno.Usuario AS Usuario,
                    Aluno.Senha AS Senha
                FROM
                    aluno AS Aluno
                WHERE
                    Aluno.Id = @AlunoId;
            ";

        public static string Insert =>
           @"
                INSERT INTO aluno (nome, usuario, senha)
                VALUES (@nome, @usuario, @senha);
            ";
    }
}
