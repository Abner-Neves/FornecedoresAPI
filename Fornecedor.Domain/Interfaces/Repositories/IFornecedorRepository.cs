
using Fornecedores.Domain.Models;

namespace Fornecedores.Domain.Interfaces.Repositories
{
    public interface IFornecedorRepository
    {
        public Task<IEnumerable<Fornecedor>> GetFornecedors();
        public Task<Fornecedor> GetFornecedorById(int id);
        public Task<Fornecedor> GetFornecedorByEmail(string email);
        public Task<Fornecedor> GetFornecedorByCNPJ(string cpnj);
        public Task<Fornecedor> InsertFornecedor(Fornecedor fornecedor);
        public Task<Fornecedor> UpdateFornecedor(Fornecedor fornecedor);
        public Task DeleteFornecedor(int id);
    }
}
