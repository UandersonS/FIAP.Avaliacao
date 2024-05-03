using MediatR;

namespace FIAP.Avaliacao.Application.UseCases.Students.GetStudent
{
    public class ConsultarAlunoUseCase : IRequestHandler<ConsultarAlunoInput>
    {
        public Task Handle(ConsultarAlunoInput request, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Get student with id {request.Id}");
            return Task.CompletedTask;
        }
    }
}
