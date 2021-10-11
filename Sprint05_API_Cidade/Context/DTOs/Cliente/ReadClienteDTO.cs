using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sprint05_API_Cidade
{
    public class ReadClienteDTO
    {
        [Required(ErrorMessage = "O campo Id é obrigatório")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo Data de Nascimento é obrigatório")]
        public DateTime DataNascimento { get; set; }
        [Required(ErrorMessage = "O campo CidadeId é obrigatório")]
        public Guid CidadeId { get; set; }

        [Required(ErrorMessage = "O campo Cep é obrigatório")]
        [RegularExpression(@"^[0-9]{5}-?[0-9]{3}$",
         ErrorMessage = "O campo Cep é inválido.")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "O campo logradouro é obrigatório, " +
            "algunas CEPs não apresentam logradouro, caso o seu apresente, digite qualquer palavra, caso não, digite seu logradouro")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "O campo bairro é obrigatório, " +
            "algunas CEPs não apresentam bairro, caso o seu apresente, digite qualquer palavra, caso não, digite seu logradouro")]
        public string Bairro { get; set; }
        //public Cidade Cidade { get; set; }
    }
}
