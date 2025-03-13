using CadastroPessoas.Domain.Entities.Abstract;
using CadastroPessoas.Domain.Enum;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CadastroPessoas.Domain.Entities
{
    [Table("PessoaFisica")]
    public class PessoaFisica : Pessoa
    {
        [FromRoute]
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "CPF Obrigatório")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "RG Obrigatório")]
        public string RG { get; set; }

        [Required(ErrorMessage = "Nome Obrigatório")]
        public string Nome { get; set; }

        [Required]
        public DateTime DataNascimento { get; set; }
        public string? Profissao { get; set; }

        public override void GetNatureza()
        {
            SetarIndNaturezaPFPJ(NaturezaEnum.PF);
        }

    }
}
