using Fornecedores.Domain.Interfaces.Repositories;
using Fornecedores.Domain.Models;
using Fornecedores.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace Fornecedores.Infrastructure.Repositories
{
    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly AppDbContext _context;

        public FornecedorRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task DeleteFornecedor(int id)
        {
            var fornecedor = await _context.Set<Fornecedor>().Where(f => f.Id == id).FirstOrDefaultAsync();
            if (fornecedor != null)
            {
                _context.Fornecedores.Remove(fornecedor);
                await _context.SaveChangesAsync();
            }
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

        public async Task<Fornecedor> UpdateFornecedor(Fornecedor fornecedor)
        {
            var oldFornecedor = await _context.Set<Fornecedor>().Where(f => f.Id == fornecedor.Id).FirstOrDefaultAsync();

            if (oldFornecedor != null)
            {
                oldFornecedor.Nome = fornecedor.Nome;
                oldFornecedor.Email = fornecedor.Email;
                oldFornecedor.CNPJ = fornecedor.CNPJ;
                await _context.SaveChangesAsync();
            }
            return fornecedor;
        }
    }
}
