using AutoFixture;
using FIAP.Avaliacao.Application.UseCases.Turmas.CadastrarTurma;
using FIAP.Avaliacao.Domain.Entities;
using FIAP.Avaliacao.Domain.Exceptions;
using FIAP.Avaliacao.Infra.Database.Repositories.Interfaces;
using Moq;

namespace FIAP.Avaliacao.UnitTests.Application.UseCases.Turmas.CadastrarTurma
{
    public class CadastrarTurmaUseCaseTests
    {
        private readonly Mock<ITurmaRepository> _turmaRepositoryMock;
        private readonly CadastrarTurmaUseCase _sut;
        private readonly Fixture _fixture;

        public CadastrarTurmaUseCaseTests()
        {
            _fixture = new Fixture();
            _turmaRepositoryMock = new Mock<ITurmaRepository>();
            _sut = new CadastrarTurmaUseCase(_turmaRepositoryMock.Object);
        }



        [Fact]
        public async Task Deve_lancar_excecao_se_existir_turma_com_mesmo_nomeAsync()
        {
            // Arrange
            var input = _fixture.Create<CadastrarTurmaInput>();
            var turma = _fixture.Create<Turma>();

            _turmaRepositoryMock
                .Setup(r => r.ConsultarPorNomeAsync(It.IsAny<string>()))
                .ReturnsAsync(turma);

            // Act
            var action = async () => await _sut.Handle(input, It.IsAny<CancellationToken>());

            // Assert
            await Assert.ThrowsAsync<DomainException>(action);
            _turmaRepositoryMock.Verify(r => r.ConsultarPorNomeAsync(input.Nome), Times.Once);
        }

        [Fact]
        public async Task Deve_cadastrar_uma_nova_turma_com_sucesso()
        {
            // Arrange
            var input = _fixture.Create<CadastrarTurmaInput>();
            var turma = _fixture.Create<Turma>();

            _turmaRepositoryMock
                .Setup(r => r.ConsultarPorNomeAsync(It.IsAny<string>()))
                .ReturnsAsync(default(Turma));

            // Act
            await _sut.Handle(input, It.IsAny<CancellationToken>());

            // Assert
            _turmaRepositoryMock.Verify(r => r.ConsultarPorNomeAsync(input.Nome), Times.Once);
            _turmaRepositoryMock.Verify(r => r.AdicionarTurma(It.Is<Turma>(t => t.IdCurso == input.IdCurso && t.Nome == input.Nome)), Times.Once);

        }
    }
}
