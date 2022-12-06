using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoContato_API.Models;

namespace ProjetoContato_API.Data
{
    public class Repository : IRepository
    {
        private readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Pessoa[]> GetTodasPessoasAsync()
        {
            IQueryable<Pessoa> query = _context.pessoas;
            query = query.AsNoTracking().OrderBy(c => c.Id);
            return await query.ToArrayAsync();
        }
        public async Task<Pessoa> GetPessoaAsyncById(int pessoaId)
        {
            IQueryable<Pessoa> query = _context.pessoas;
            query = query.AsNoTracking().OrderBy(pessoa => pessoa.Id).Where(pessoa => pessoa.Id == pessoaId);
            return await query.FirstOrDefaultAsync();
        }
    }
}