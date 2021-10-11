using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sprint05_API_Cidade
{
    public class UpdateCidadeValidator : AbstractValidator<UpdateCidadeDTO>
    {
        public UpdateCidadeValidator()
        {
            RuleFor(x => x.Nome).NotEmpty().WithMessage("O campo nome � obrigat�rio");
            RuleFor(x => x.Estado).NotEmpty().WithMessage("O campo estado � obrigat�rio");
        }
    }
}
