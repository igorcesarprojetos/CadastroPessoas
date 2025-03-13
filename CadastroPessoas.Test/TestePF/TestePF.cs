using CadastroPessoas.Domain.Entities;
using CadastroPessoas.Domain.Interface.Repository;
using CadastroPessoas.Domain.Interface.Service;
using CadastroPessoas.Domain.Service;
using CadastroPessoas.Repository;
using CadastroPessoas.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using CadastroPessoas.Domain.Validacao;


namespace CadastroPessoas.Teste.TestePF
{
    public class TestePF
    {
        private readonly IRepository<PessoaFisica> _pessoaFisicaRepository;
        private readonly IPessoaService<PessoaFisica> _pessoaFisicaService;
        private readonly DbContextOptions<RepositoryPatternContext> _dbContextOptions;

        Exception exception;


        public TestePF()
        {
            // //Configuração do IConfiguration para acessar a connection string
            var configuration = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json") // Certifique-se de que o arquivo appsettings.json está configurado corretamente
           .Build();

            // Obtém a connection string do arquivo de configuração
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            // Configura o DbContext com a connection string real
            _dbContextOptions = new DbContextOptionsBuilder<RepositoryPatternContext>()
                .UseSqlServer(connectionString) // Use a connection string real
                .Options;

            var context = new RepositoryPatternContext(_dbContextOptions);

            _pessoaFisicaRepository = new Repository<PessoaFisica>(context);
            _pessoaFisicaService = new PessoaService<PessoaFisica>(_pessoaFisicaRepository);

        }

        [Fact(DisplayName = "ValidacaoPessoaErro PF")]
        [Trait("Pessoa Física", "Validando Erro Cadastro PF")]

        public void ValidacaoPessoaErro()
        {
            // Arrange
            PessoaFisica pessoaFisica = new() { CPF = "54888..877777", RG = "1121337777", DataNascimento = DateTime.Parse("1986-09-16"), Nome = "João Silva" };

            // Act
            Action validar = () => ValidacaoPessoa.ValidacaoPF(pessoaFisica, _pessoaFisicaService);

            // Assert         
            exception = Assert.Throws<Exception>(validar);
            Assert.Contains(ValidacaoPessoa.ErroValidacao, exception.Message);

        }

        [Fact(DisplayName = "Add PF")]
        [Trait("Pessoa Física", "Add  Cadastro PF")]

        public void AddPessoa()
        {
            try
            {
                // Arrange
                PessoaFisica pessoaFisica = new() { CPF = "54888877777", RG = "1121337777", DataNascimento = DateTime.Parse("1986-09-16"), Nome = "João Silva" };

                // Act
                _pessoaFisicaService.AddPessoa(pessoaFisica);

            }
            catch (Exception ex)
            {
                // Assert
                Assert.Fail(ex.Message);
            }



        }

        [Fact(DisplayName = "Erro CPF Nulo PF")]
        [Trait("Pessoa Física", "Erro Cadastro CPF Nulo PF")]

        public void AddPessoaCPFNuloErro()
        {

            // Arrange
            PessoaFisica pessoaFisica = new() { CPF = null, RG = "1121111111", DataNascimento = DateTime.Parse("1986-09-16"), Nome = "João Silva" };

            // Act           
            var addComErro = () => _pessoaFisicaService.AddPessoa(pessoaFisica);

            // Assert
            exception = Assert.Throws<Exception>(addComErro);
            Assert.Contains("An error occurred while saving the entity changes. See the inner exception for details.", exception.Message);
        }


        [Theory]
        [InlineData(1)]
        [InlineData(2)]        
        public void GetPessoaById(int id)
        {

            try
            {
                // Arrange
                int idPessoaFisica = id;

                // Act
                var result = () => _pessoaFisicaService.GetPessoaById(idPessoaFisica);
                result();
            }
            catch (Exception ex)
            {
                // Assert
                Assert.Fail(ex.Message);
            }
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void GetPessoaByIdProfissionalNull(int id)
        {

            try
            {
                // Arrange
                int idPessoaFisica = id;

                // Act
                var result = _pessoaFisicaService.GetPessoaById(idPessoaFisica);

                // Assert                
                Assert.Null(result.Profissao);
            }
            catch (Exception ex)
            {
                // Assert   
                Assert.Fail(ex.Message);
            }
        }

        [Fact]
        public void UpdatePessoa()
        {
            try
            {
                // Arrange
                PessoaFisica pessoaFisica = new() { Id = 4, CPF = "60036636009", RG = "1111111111", DataNascimento = DateTime.Parse("1986-09-16"), Nome = "João Silva" };

                // Act
                var update = () => _pessoaFisicaService.UpdatePessoa(pessoaFisica);
                update();
            }
            catch (Exception ex)
            {
                //Assert
                Assert.Fail(ex.Message);
            }
        }


        [Fact]
        public void DeletePessoa()
        {
            try
            {
                // Arrange
                int id = 1;

                // Act
                Action result = () => _pessoaFisicaService.DeletePessoa(id);
                result();            
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
                // Act
                IEnumerable<PessoaFisica> lResult = _pessoaFisicaService.GetAllPessoa();

                // Assert
                Assert.NotNull(lResult);
                Assert.NotNull(lResult);
                Assert.NotEmpty(lResult);
                Assert.True(lResult.Count() > 0);
            }
            catch (Exception ex)
            {
                // Assert   
                Assert.Fail(ex.Message);
            }
        }
    }
}