using AutoFixture;
using FIAP.Avaliacao.Application.Services.Interfaces;
using FIAP.Avaliacao.Application.UseCases.Alunos.CadastrarAluno;
using FIAP.Avaliacao.Domain.Exceptions;
using FIAP.Avaliacao.Infra.Database.Repositories.Interfaces;
using Moq;

namespace FIAP.Avaliacao.UnitTests.Application.UseCases.Alunos.CadastrarAluno
{
    public class CadastrarAlunoUseCaseTests
    {
        private readonly Mock<IAlunoRepository> _alunoRepositoryMock;
        private readonly Mock<IAesCryptographyService> _cryptographyServiceMock;
        private readonly CadastrarAlunoUseCase _sut;
        private readonly Fixture _fixture;

        public CadastrarAlunoUseCaseTests()
        {
            _fixture = new Fixture();
            _alunoRepositoryMock = new Mock<IAlunoRepository>();
            _cryptographyServiceMock = new Mock<IAesCryptographyService>();
            _sut = new CadastrarAlunoUseCase(_alunoRepositoryMock.Object, _cryptographyServiceMock.Object);
        }

        [Fact]
        public async Task Deve_lancar_excecao_se_a_senha_for_muito_curta()
        {
            // Arrange
            var input = _fixture.Create<CadastrarAlunoInput>();
            input.Senha = "abc123"; // Senha com menos de 8 caracteres

            // Act
            var action = async () => await _sut.Handle(input, It.IsAny<CancellationToken>());

            // Assert
            await Assert.ThrowsAsync<DomainException>(action);
        }

        [Fact]
        public async Task Deve_lancar_excecao_se_a_senha_for_fraca()
        {
            // Arrange
            var input = _fixture.Create<CadastrarAlunoInput>();
            input.Senha = "12345678"; // Senha com 8 caracteres, mas fraca

            // Act
            var action = async () => await _sut.Handle(input, It.IsAny<CancellationToken>());

            // Assert
            await Assert.ThrowsAsync<DomainException>(action);
        }

        [Fact]
        public async Task Deve_cadastrar_um_novo_aluno_com_sucesso()
        {
            // Arrange
            var input = _fixture.Create<CadastrarAlunoInput>();
            var senhaCriptografada = "senha-criptografada";
            _cryptographyServiceMock
                .Setup(s => s.Encrypt(It.IsAny<string>()))
                .Returns(senhaCriptografada);

            // Act
            await _sut.Handle(input, It.IsAny<CancellationToken>());

            // Assert
            _cryptographyServiceMock.Verify(s => s.Encrypt(input.Senha), Times.Once);
            _alunoRepositoryMock.Verify(r => r.AdicionarAluno(It.Is<Domain.Entities.Aluno>(a =>
                a.Nome == input.Nome &&
                a.Senha == senhaCriptografada)), Times.Once);
        }
    }
}
