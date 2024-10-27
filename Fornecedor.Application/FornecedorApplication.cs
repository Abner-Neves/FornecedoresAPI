using AutoMapper;
using Fornecedores.Domain.DTOs;
using Fornecedores.Domain.Interfaces.Applications;
using Fornecedores.Domain.Interfaces.Repositories;
using Fornecedores.Domain.Models;
using System.Text.RegularExpressions;

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
        public async Task DeleteFornecedor(int id)
            => await _fornecedorRepository.DeleteFornecedor(id);

        public async Task<GetFornecedorDto> GetFornecedorById(int id)
        {
            var fornecedor = await _fornecedorRepository.GetFornecedorById(id);
            return _mapper.Map<GetFornecedorDto>(fornecedor);
        }
        public async Task<IEnumerable<GetFornecedorDto>> GetFornecedores()
        {
            var fornecedores = await _fornecedorRepository.GetFornecedors();
            return _mapper.Map<IEnumerable<GetFornecedorDto>>(fornecedores);
        }

        public async Task<InsertFornecedorDto> InsertFornecedor(InsertFornecedorDto fornecedorDto)
        {
            var fornecedor = _mapper.Map<Fornecedor>(fornecedorDto);
            await ValidaFornecedor(fornecedor);
            var result = await _fornecedorRepository.InsertFornecedor(fornecedor);
            return _mapper.Map<InsertFornecedorDto>(result);
        }

        public async Task<GetFornecedorDto> UpdateFornecedor(int id, UpdateFornecedorDto fornecedorDto)
        {
            var fornecedor = _mapper.Map<Fornecedor>(fornecedorDto);
            await ValidaFornecedor(fornecedor);
            fornecedor.Id = id;
            var result = await _fornecedorRepository.UpdateFornecedor(fornecedor);
            return _mapper.Map<GetFornecedorDto>(result);
        }

        public async Task ValidaFornecedor(Fornecedor fornecedor)
        {
            if(!CpnjValido(fornecedor.CNPJ))
                throw new Exception("O CNPJ informado não é valido");

            if (await CnpjExistente(fornecedor.CNPJ))
                throw new Exception("O CNPJ informado já está cadastrado");

            if (await EmailExistente(fornecedor.Email))
                throw new Exception("O email informado já está cadastrado");
        }

        public async Task<bool> EmailExistente(string email)
        {
            var fornecedor = await _fornecedorRepository.GetFornecedorByEmail(email);
            return fornecedor != null;
        }
        public async Task<bool> CnpjExistente(string cnpj)
        {
            var fornecedor = await _fornecedorRepository.GetFornecedorByCNPJ(cnpj);
            return fornecedor != null;
        }
        public bool CpnjValido(string cnpj)
        {
            cnpj = Regex.Replace(cnpj, @"\D", "");

            if (cnpj.Length != 14)
                return false;
            return true;
        }
    }
}
