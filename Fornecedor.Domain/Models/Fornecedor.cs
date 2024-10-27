﻿using System.ComponentModel.DataAnnotations;

namespace Fornecedores.Domain.Models
{
    public class Fornecedor
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
        public string CNPJ{ get; set; }
    }
}