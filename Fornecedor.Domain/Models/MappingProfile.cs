using AutoMapper;
using Fornecedores.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fornecedores.Domain.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Fornecedor, GetFornecedorDto>().ReverseMap();
            CreateMap<Fornecedor, UpdateFornecedorDto>().ReverseMap();
            CreateMap<Fornecedor, InsertFornecedorDto>().ReverseMap();
        }
    }
}
