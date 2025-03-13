using CadastroPessoas.Domain.Entities.Abstract;
using CadastroPessoas.Domain.Interface.Repository;
using CadastroPessoas.Domain.Interface.Service;

namespace CadastroPessoas.Domain.Service
{
    public class PessoaService<T> : IPessoaService<T> where T : Pessoa
    {
        private readonly IRepository<T> _pessoaRepository;

        public PessoaService(IRepository<T> pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public void AddPessoa(T pessoa)
        {
            try
            {
                _pessoaRepository.Add(pessoa);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdatePessoa(T pessoa)
        {
            try
            {
                _pessoaRepository.Update(pessoa);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeletePessoa(int id)
        {
            try
            {
                _pessoaRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public T GetPessoaById(int id)
        {
            try
            {
                return _pessoaRepository.GetById(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<T> GetAllPessoa()
        {
            try
            {
                return _pessoaRepository.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
