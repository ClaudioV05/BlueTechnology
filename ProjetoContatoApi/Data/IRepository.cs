using System.Threading.Tasks;
using ProjetoContato_API.Models;

namespace ProjetoContato_API.Data
{
    public interface IRepository
    {
        // Geral.
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        // Pessoa.
        Task<Pessoa[]> GetTodasPessoasAsync();
        Task<Pessoa> GetPessoaAsyncById(int pessoaId);
    }
}