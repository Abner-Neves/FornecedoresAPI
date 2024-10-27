using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fornecedores.Domain.DTOs
{
    public class GetFornecedorDto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }
        [Required]
        [MaxLength(256)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(14)]
        public string CNPJ { get; set; }
    }
}
