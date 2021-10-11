using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sprint05_API_Cidade
{
    public class ReadClienteDTO
    {
        [Required(ErrorMessage = "O campo Id � obrigat�rio")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O campo Nome � obrigat�rio")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo Data de Nascimento � obrigat�rio")]
        public DateTime DataNascimento { get; set; }
        [Required(ErrorMessage = "O campo CidadeId � obrigat�rio")]
        public Guid CidadeId { get; set; }

        [Required(ErrorMessage = "O campo Cep � obrigat�rio")]
        [RegularExpression(@"^[0-9]{5}-?[0-9]{3}$",
         ErrorMessage = "O campo Cep � inv�lido.")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "O campo logradouro � obrigat�rio, " +
            "algunas CEPs n�o apresentam logradouro, caso o seu apresente, digite qualquer palavra, caso n�o, digite seu logradouro")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "O campo bairro � obrigat�rio, " +
            "algunas CEPs n�o apresentam bairro, caso o seu apresente, digite qualquer palavra, caso n�o, digite seu logradouro")]
        public string Bairro { get; set; }
        //public Cidade Cidade { get; set; }
    }
}
