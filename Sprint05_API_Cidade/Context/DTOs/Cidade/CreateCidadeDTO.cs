using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sprint05_API_Cidade
{
    public class CreateCidadeDTO
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo Estado é obrigatório")]
        public string Estado { get; set; }
        //public List<Cliente> Clientes { get; set; }
    }
}
