using CadastroPessoas.Domain.Entities;
using CadastroPessoas.Domain.Interface.Service;
using CadastroPessoas.Domain.Validacao;
using Microsoft.AspNetCore.Mvc;

namespace CadastroPessoas.Main.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoaFisicaController : ControllerBase
    {
        private readonly IPessoaService<PessoaFisica> _pessoaFisica;

        public PessoaFisicaController(IPessoaService<PessoaFisica> pessoaFisica)
        {
            _pessoaFisica = pessoaFisica;
        }

        [HttpGet]
        public IActionResult Get()
        {

            try
            {
                var resultado = _pessoaFisica.GetAllPessoa();
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            try
            {
                var resultado = _pessoaFisica.GetPessoaById(id);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }

        }

        [HttpPost]
        public IActionResult Create([FromBody] PessoaFisica pessoaFisica)
        {
            try
            {

                if (!ValidacaoPessoa.ValidacaoPF(pessoaFisica, _pessoaFisica)) // Se retornar falsa a validação
                    throw new Exception(ValidacaoPessoa.ErroValidacao);


                _pessoaFisica.AddPessoa(pessoaFisica);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }

        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] PessoaFisica pessoaFisica)
        {
            try
            {
                if (pessoaFisica.Id == 0 && id == 0)
                    throw new Exception("Id não pode ser zero");
                else if (pessoaFisica.Id == 0 && id > 0)
                    pessoaFisica.Id = id;

                if (!ValidacaoPessoa.ValidacaoPF(pessoaFisica, _pessoaFisica)) // Se retornar falsa a validação
                    throw new Exception(ValidacaoPessoa.ErroValidacao);

                _pessoaFisica.UpdatePessoa(pessoaFisica);
                return Ok(pessoaFisica);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPatch("{id}")]
        public IActionResult UpdateField([FromRoute] int id, [FromBody] PessoaFisica pessoaFisica)
        {
            try
            {
                if (pessoaFisica.Id == 0 && id == 0)
                    throw new Exception("Id não pode ser zero");
                else if (pessoaFisica.Id == 0 && id > 0)
                    pessoaFisica.Id = id;

                if (!ValidacaoPessoa.ValidacaoPF(pessoaFisica, _pessoaFisica)) // Se retornar falsa a validação
                    throw new Exception(ValidacaoPessoa.ErroValidacao);

                _pessoaFisica.UpdatePessoa(pessoaFisica);
                return Ok(pessoaFisica);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                _pessoaFisica.DeletePessoa(id);
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
