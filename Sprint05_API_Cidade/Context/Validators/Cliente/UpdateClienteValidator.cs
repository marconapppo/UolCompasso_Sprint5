using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sprint05_API_Cidade
{
    public class UpdateClienteValidator : AbstractValidator<UpdateClienteDTO>
    {
        public UpdateClienteValidator()
        {
            RuleFor(x => x.Nome).NotEmpty().WithMessage("O campo nome é obrigatório");
            RuleFor(x => x.DataNascimento).NotEmpty().WithMessage("O campo data de nascimento é obrigatório");
            RuleFor(x => x.Cep).NotEmpty().WithMessage("O campo cep é obrigatório");
            RuleFor(x => x.Cep).Matches(@"^[0-9]{5}-?[0-9]{3}$").WithMessage("O campo Cep é inválido");
            RuleFor(x => x.Logradouro).NotEmpty()
                .WithMessage("O campo logradouro é obrigatório, algunas CEPs não " +
                "apresentam logradouro, caso o seu apresente, digite qualquer palavra, caso não, digite seu logradouro");
            RuleFor(x => x.Bairro).NotEmpty()
                .WithMessage("O campo bairro é obrigatório, algunas CEPs não " +
                "apresentam bairro, caso o seu apresente, digite qualquer palavra, caso não, digite seu logradouro");
        }
    }
}
