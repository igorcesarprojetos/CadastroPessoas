using CadastroPessoas.Domain.Entities.Abstract;

namespace CadastroPessoas.Domain.Interface.Service
{
    public interface IPessoaService<T> where T : Pessoa
    {
        void AddPessoa(T entity);
        void UpdatePessoa(T entity);
        void DeletePessoa(int id);
        T GetPessoaById(int id);
        IEnumerable<T> GetAllPessoa();
    }
}
