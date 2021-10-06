using AutoMapper;
using System;
using System.Collections.Generic;

namespace Sprint05_API_Cidade
{
    public class ClienteProfile : Profile
    {
        public ClienteProfile(){
            CreateMap<CreateClienteDTO, Cliente>();
            CreateMap<Cliente, ReadClienteDTO>();
            CreateMap<UpdateClienteDTO, Cliente>();
        }
    }
}
