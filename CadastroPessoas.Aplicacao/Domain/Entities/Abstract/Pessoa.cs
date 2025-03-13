using CadastroPessoas.Domain.Enum;

namespace CadastroPessoas.Domain.Entities.Abstract
{
    public abstract class Pessoa
    {
        public bool IndNaturezaPFPJ { get; private set; }

        public abstract void GetNatureza();

        public bool SetarIndNaturezaPFPJ(NaturezaEnum nat)
        {
            if (nat.Equals(NaturezaEnum.PF))
                IndNaturezaPFPJ = false;
            else if (nat.Equals(NaturezaEnum.PJ))
                IndNaturezaPFPJ = true;

            return IndNaturezaPFPJ;
        }
    }
}
