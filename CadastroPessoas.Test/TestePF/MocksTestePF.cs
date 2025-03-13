using CadastroPessoas.Domain.Entities;
using CadastroPessoas.Domain.Interface.Repository;
using CadastroPessoas.Domain.Interface.Service;
using CadastroPessoas.Domain.Service;
using CadastroPessoas.Domain.Validacao;
using Moq;

namespace CadastroPessoas.Teste.TestePF
{
    public class MocksTestePF
    {
        private Mock<IRepository<PessoaFisica>> _mockPessoaFisicaRepository;
        private IPessoaService<PessoaFisica> _pessoaFisicaService;

        Exception exception = new Exception();

        public MocksTestePF()
        {
            _mockPessoaFisicaRepository = new Mock<IRepository<PessoaFisica>>();
        }


        [Fact(DisplayName = "Adicionando PF")]
        [Trait("Pessoa Física", "Validando Cadastro PF")]

        public void AddPessoa()
        {
            try
            {
                // Arrange
                _mockPessoaFisicaRepository.Setup(mpfr => mpfr.Add(It.IsAny<PessoaFisica>()));
                _pessoaFisicaService = new PessoaService<PessoaFisica>(_mockPessoaFisicaRepository.Object);
                var pessoaFisica = new PessoaFisica()
                {
                    Id = 2,
                    CPF = "66655555555",
                    RG = "2221111111",
                    DataNascimento = DateTime.Parse("1960-09-16"),
                    Nome = "Igor Silva"
                };

                // Act               
                _pessoaFisicaService.AddPessoa(pessoaFisica);

            }
            catch (Exception ex)
            {
                // Assert
                Assert.Fail(ex.Message);
            }

        }

        [Fact(DisplayName = "Adicionando PF Com  Erro")]
        [Trait("Pessoa Física", "Validando Cadastro PF Com Erro")]

        public void ValidarPessoaComErro()
        {
            // Arrange
            _mockPessoaFisicaRepository.Setup(mpfr => mpfr.Add(It.IsAny<PessoaFisica>()));
            _pessoaFisicaService = new PessoaService<PessoaFisica>(_mockPessoaFisicaRepository.Object);
            var pessoaFisica = new PessoaFisica()
            {
                Id = 2,
                CPF = "6665..5555555",
                RG = "2221111111",
                DataNascimento = DateTime.Parse("1960-09-16"),
                Nome = "Igor Silva"
            };

            // Act
            Action validar = () => ValidacaoPessoa.ValidacaoPF(pessoaFisica, _pessoaFisicaService);

            // Assert
            exception = Assert.Throws<Exception>(validar);
            Assert.Contains(ValidacaoPessoa.ErroValidacao, exception.Message);
        }


        [Theory]
        [InlineData(1)]

        public void GetPessoaById(int id)
        {

            try
            {
                // Arrange
                int idPessoaFisica = id;
                _mockPessoaFisicaRepository.Setup(mpfr => mpfr.GetById(It.IsAny<int>())).Returns(this.ObterPessoaFisica);
                _pessoaFisicaService = new PessoaService<PessoaFisica>(_mockPessoaFisicaRepository.Object);

                // Act
                var result = _pessoaFisicaService.GetPessoaById(idPessoaFisica);

                // Assert                
                Assert.NotNull(result);
            }
            catch (Exception ex)
            {
                // Assert   
                Assert.Fail(ex.Message);
            }
        }


        [Fact]
        public void GetAllPessoa()
        {

            try
            {
                // Arrange
                _mockPessoaFisicaRepository.Setup(mpfr => mpfr.GetAll()).Returns(this.ObterTodos);
                _pessoaFisicaService = new PessoaService<PessoaFisica>(_mockPessoaFisicaRepository.Object);

                // Act
                var listResult = _pessoaFisicaService.GetAllPessoa();

                // Assert
                Assert.NotNull(listResult);
                Assert.NotEmpty(listResult);
                Assert.True(listResult.Count() > 0);
            }
            catch (Exception ex)
            {
                // Assert   
                Assert.Fail(ex.Message);
            }
        }


        private PessoaFisica ObterPessoaFisica()
        {
            return new() { Id = 1, CPF = "55555555555", RG = "1111111111", DataNascimento = DateTime.Parse("1970-09-16"), Nome = "João Silva" };
        }

        private List<PessoaFisica> ObterTodos()
        {
            List<PessoaFisica> lPessoas = new List<PessoaFisica>();

            lPessoas.Add(new PessoaFisica
            {
                Id = 1,
                CPF = "55555555555",
                RG = "1111111111",
                DataNascimento = DateTime.Parse("1970-09-16"),
                Nome = "João Silva"
            });

            // Se você quiser adicionar outra pessoa, faça assim:
            lPessoas.Add(new PessoaFisica
            {
                Id = 2,
                CPF = "66666666666",
                RG = "2222222222",
                DataNascimento = DateTime.Parse("1990-05-20"),
                Nome = "Maria Souza"
            });

            return lPessoas;
        }

    }
}
