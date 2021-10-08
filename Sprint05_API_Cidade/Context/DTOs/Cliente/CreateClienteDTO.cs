using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sprint05_API_Cidade
{
    public class CreateClienteDTO
    {
        [Required(ErrorMessage = "O campo Nome � obrigat�rio")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Data de Nascimento � obrigat�rio")]
        public DateTime DataNascimento { get; set; }

        //[Required(ErrorMessage = "O campo CidadeId � obrigat�rio")]
        //public Guid CidadeId { get; set; }

        [Required(ErrorMessage = "O campo Cep � obrigat�rio")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "O campo Logradouro � obrigat�rio")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "O campo Bairro � obrigat�rio")]
        public string Bairro { get; set; }
        //public Cidade Cidade { get; set; }
    }
}
