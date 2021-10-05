using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sprint05_API_Cidade
{
    public class UpdateCidadeDTO
    {
        [Required(ErrorMessage = "O campo Id � obrigat�rio")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O campo Nome � obrigat�rio")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo Estado � obrigat�rio")]
        public string Estado { get; set; }
        public List<Cliente> Clientes { get; set; }
    }
}
