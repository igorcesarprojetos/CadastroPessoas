using CadastroPessoas.Domain.Entities.Abstract;
using CadastroPessoas.Domain.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroPessoas.Domain.Entities
{
    [Table("PessoaJuridica")]
    public class PessoaJuridica : Pessoa
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "CNPJ Obrigatório")]
        public string CNPJ { get; set; }

        [Required(ErrorMessage = "Razão Social Obrigatório")]
        public string RazaoSocial { get; set; }
        public string? NomeFantasia { get; set; }
        public string? Segmento { get; set; }

        public override void GetNatureza()
        {
            SetarIndNaturezaPFPJ(NaturezaEnum.PJ);
        }
    }
}
