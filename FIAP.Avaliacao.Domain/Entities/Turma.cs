namespace FIAP.Avaliacao.Domain.Entities
{
    public class Turma
    {
        public int Id { get; set; }
        public int IdCurso { get; set; }
        public string Nome { get; set; }
        public int Ano { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
