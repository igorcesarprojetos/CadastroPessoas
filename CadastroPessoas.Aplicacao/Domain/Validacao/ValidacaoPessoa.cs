using CadastroPessoas.Domain.Entities;
using CadastroPessoas.Domain.Interface.Service;

namespace CadastroPessoas.Domain.Validacao
{
    public class ValidacaoPessoa
    {
        public static string ErroValidacao { get; set; }
        public static bool ValidacaoPF(PessoaFisica pessoaFisica, IPessoaService<PessoaFisica> _pessoaFisica)
        {
            try
            {
                var listPessoaFisica = _pessoaFisica.GetAllPessoa();

                if (pessoaFisica.CPF.Contains(".") || pessoaFisica.CPF.Contains("-"))
                    throw new Exception("Não pode conter caracteres.");

                if (pessoaFisica.RG.Contains(".") || pessoaFisica.RG.Contains("-"))
                    throw new Exception("Não pode conter caracteres.");

                if (pessoaFisica.Id > 0)
                    listPessoaFisica = _pessoaFisica.GetAllPessoa().Where(pf => pf.Id != pessoaFisica.Id);

                if (listPessoaFisica.Where(pf => pf.CPF.Equals(pessoaFisica.CPF)).Count() > 0)
                    throw new Exception("CPF já existe.");
                else if (listPessoaFisica.Where(pf => pf.RG.Equals(pessoaFisica.RG)).Count() > 0)
                    throw new Exception("RG já existe.");

                if (pessoaFisica.DataNascimento.ToShortDateString().Equals("01/01/0001"))
                    throw new Exception("Data de Nascimento obrigatória.");

                return true;
            }
            catch (Exception ex)
            {
                ErroValidacao = ex.Message;
                throw new Exception(ex.Message);
            }
        }

        public static bool ValidacaoPJ(PessoaJuridica pessoaJuridica, IPessoaService<PessoaJuridica> _pessoaJuridica)
        {
            try
            {
                var listPessoaJuridica = _pessoaJuridica.GetAllPessoa();

                if (pessoaJuridica.CNPJ.Contains(".") || pessoaJuridica.CNPJ.Contains("-") || pessoaJuridica.CNPJ.Contains("/"))
                    throw new Exception("Não pode conter caracteres.");

                if (pessoaJuridica.Id > 0)
                    listPessoaJuridica = _pessoaJuridica.GetAllPessoa().Where(pj => pj.Id != pessoaJuridica.Id);

                if (listPessoaJuridica.Where(pj => pj.CNPJ.Equals(pessoaJuridica.CNPJ)).Count() > 0)
                    throw new Exception("CNPJ já existe.");
                else if (listPessoaJuridica.Where(pj => pj.RazaoSocial.Equals(pessoaJuridica.RazaoSocial)).Count() > 0)
                    throw new Exception("Razao Social já existe.");

                return true;
            }
            catch (Exception ex)
            {
                ErroValidacao = ex.Message;
                throw new Exception(ex.Message);
            }
        }
    }
}
