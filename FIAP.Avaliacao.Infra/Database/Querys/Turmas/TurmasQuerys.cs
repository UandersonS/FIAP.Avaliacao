namespace FIAP.Avaliacao.Infra.Database.Querys.Turmas
{
    public class TurmasQuerys
    {
        public static string ConsultarTurmaPorId =>
           @"
               SELECT
                    Turma.id AS Id,
                    Turma.curso_id AS CursoId,
                    Turma.turma AS Turma,
                    Turma.ano AS Ano
                    Turma.data_cadastro as DataCadastro
                FROM
                    turma AS Turma
                WHERE
                    Turma.Id = @TurmaId;
            ";

        public static string ConsultarTurmaPorNome =>
           @"
               SELECT
                    Turma.id AS Id,
                    Turma.curso_id AS CursoId,
                    Turma.turma AS Turma,
                    Turma.ano AS Ano
                FROM
                    turma AS Turma
                WHERE
                    Turma.Turma = @Nome;
            ";

        public static string Insert =>
            @"INSERT INTO turma (curso_id, turma, ano,data_cadastro) VALUES (@curso_id, @turma, @ano, @dataCadastro)";
    }
}
