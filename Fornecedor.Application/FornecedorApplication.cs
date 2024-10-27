using AutoMapper;
using Fornecedores.Domain.DTOs;
using Fornecedores.Domain.Interfaces.Applications;
using Fornecedores.Domain.Interfaces.Repositories;
using Fornecedores.Domain.Models;

namespace Fornecedores.Application
{
    public class FornecedorApplication : IFornecedorApplication
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IMapper _mapper;

        public FornecedorApplication(IFornecedorRepository fornecedorRepository, IMapper mapper)
        {
            _fornecedorRepository = fornecedorRepository;
            _mapper = mapper;
        }
        public Task DeleteFornecedor(int id)
        {
            throw new NotImplementedException();
        }

        public Task<GetFornecedorDto> GetFornecedorById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<GetFornecedorDto>> GetFornecedores()
        {
            var fornecedores = await _fornecedorRepository.GetFornecedors();
            var fornecedoresDto = _mapper.Map<IEnumerable<GetFornecedorDto>>(fornecedores);
            return fornecedoresDto;
        }
        
        public async Task<InsertFornecedorDto> InsertFornecedor(InsertFornecedorDto fornecedorDto)
        {
            var fornecedor = _mapper.Map<Fornecedor>(fornecedorDto);
            var result = await _fornecedorRepository.InsertFornecedor(fornecedor);
            return _mapper.Map<InsertFornecedorDto>(result);
        }

        public Task<GetFornecedorDto> UpdateFornecedor(int id, UpdateFornecedorDto fornecedor)
        {
            throw new NotImplementedException();
        }
    }
}
