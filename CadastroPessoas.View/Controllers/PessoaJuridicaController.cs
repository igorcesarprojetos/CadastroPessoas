using CadastroPessoas.Domain.Entities;
using CadastroPessoas.Domain.Interface.Service;
using CadastroPessoas.Domain.Validacao;
using Microsoft.AspNetCore.Mvc;

namespace CadastroPessoas.Main.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoaJuridicaController : ControllerBase
    {
        private readonly IPessoaService<PessoaJuridica> _pessoaJuridica;

        public PessoaJuridicaController(IPessoaService<PessoaJuridica> pessoaJuridica)
        {
            _pessoaJuridica = pessoaJuridica;
        }

        [HttpGet]
        public IActionResult Get()
        {

            try
            {
                var resultado = _pessoaJuridica.GetAllPessoa();
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
                var resultado = _pessoaJuridica.GetPessoaById(id);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }

        }

        [HttpPost]
        public IActionResult Create([FromBody] PessoaJuridica pessoaJuridica)
        {
            try
            {
                if (!ValidacaoPessoa.ValidacaoPJ(pessoaJuridica, _pessoaJuridica)) // Se retornar falsa a validação
                    throw new Exception(ValidacaoPessoa.ErroValidacao);

                pessoaJuridica.GetNatureza();

                _pessoaJuridica.AddPessoa(pessoaJuridica);

                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }

        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] PessoaJuridica pessoaJuridica)
        {
            try
            {
                if (pessoaJuridica.Id == 0 && id == 0)
                    throw new Exception("Id não pode ser zero");
                else if (pessoaJuridica.Id == 0 && id > 0)
                    pessoaJuridica.Id = id;


                if (!ValidacaoPessoa.ValidacaoPJ(pessoaJuridica, _pessoaJuridica)) // Se retornar falsa a validação
                    throw new Exception(ValidacaoPessoa.ErroValidacao);

                pessoaJuridica.GetNatureza();

                _pessoaJuridica.UpdatePessoa(pessoaJuridica);
                return Ok(pessoaJuridica);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPatch("{id}")]
        public IActionResult UpdateField([FromRoute] int id, [FromBody] PessoaJuridica pessoaJuridica)
        {
            try
            {
                if (pessoaJuridica.Id == 0 && id == 0)
                    throw new Exception("Id não pode ser zero");
                else if (pessoaJuridica.Id == 0 && id > 0)
                    pessoaJuridica.Id = id;

                if (!ValidacaoPessoa.ValidacaoPJ(pessoaJuridica, _pessoaJuridica)) // Se retornar falsa a validação
                    throw new Exception(ValidacaoPessoa.ErroValidacao);

                pessoaJuridica.GetNatureza();

                _pessoaJuridica.UpdatePessoa(pessoaJuridica);
                return Ok(pessoaJuridica);
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
                _pessoaJuridica.DeletePessoa(id);
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
