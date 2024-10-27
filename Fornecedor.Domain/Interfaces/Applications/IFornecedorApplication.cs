using Fornecedores.Domain.DTOs;
using Fornecedores.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fornecedores.Domain.Interfaces.Applications
{
    public interface IFornecedorApplication
    {
        public Task<IEnumerable<GetFornecedorDto>> GetFornecedores();
        public Task<GetFornecedorDto> GetFornecedorById(int id);
        public Task<InsertFornecedorDto> InsertFornecedor(InsertFornecedorDto fornecedor);
        public Task<GetFornecedorDto> UpdateFornecedor(int id, UpdateFornecedorDto fornecedor);
        public Task DeleteFornecedor(int id);

    }
}
