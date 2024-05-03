using MediatR;

namespace FIAP.Avaliacao.Application.UseCases.Students.GetStudent
{
    public class ConsultarAlunoInput : IRequest
    {
        public int Id { get; set; }

        public ConsultarAlunoInput(int id)
        {
            Id = id;
        }
    }
}
