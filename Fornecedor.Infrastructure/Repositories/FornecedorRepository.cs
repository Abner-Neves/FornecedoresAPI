using Fornecedores.Domain.Interfaces.Repositories;
using Fornecedores.Domain.Models;
using Fornecedores.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Fornecedores.Infrastructure.Repositories
{
    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly AppDbContext _context;

        public FornecedorRepository(AppDbContext context)
        {
            _context = context;
        }
        public Task DeleteFornecedor(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Fornecedor> GetFornecedorById(int id)
            => await _context.Set<Fornecedor>().Where(f => f.Id == id).FirstOrDefaultAsync();

        public async Task<IEnumerable<Fornecedor>> GetFornecedors()
            => await _context.Set<Fornecedor>().OrderBy(f => f.Id).ToListAsync();  

        public async Task<Fornecedor> InsertFornecedor(Fornecedor fornecedor)
        {
            await _context.Set<Fornecedor>().AddAsync(fornecedor);
            _context.SaveChanges();
            return fornecedor;
        }

        public Task<Fornecedor> UpdateFornecedor(Fornecedor fornecedor)
        {
            throw new NotImplementedException();
        }
    }
}
