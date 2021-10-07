using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Sprint05_API_Cidade.Controllers
{
    [Controller]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private PaisContext _context = new PaisContext();
        private IMapper _mapper;
        private readonly HttpClient _httpClient;

        public ClienteController(IMapper mapper, HttpClient httpClient)
        {
            _mapper = mapper;
            _httpClient = httpClient;
        }

        [HttpPost("{CEP}")]
        public async Task<IActionResult> CreateClienteAsync([FromBody] CreateClienteDTO clienteDTO, String cep)
        {
            //pegando a cidade da pessoa pelo CEP, utilizando o site abaixo
            var responseString = await _httpClient.GetStringAsync("https://viacep.com.br/ws/" + cep + "/json/");
            var catalog = JsonConvert.DeserializeObject<CatalogCep>(responseString);
            //cruzando os valores de cidade com os do banco
            Cidade cidade = _context.Cidades.FirstOrDefault(cidade => cidade.Nome == catalog.localidade);
            clienteDTO.CidadeId = cidade.Id;
            //cadastrando cliente
            Cliente cliente = _mapper.Map<Cliente>(clienteDTO);
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
            return RecuperaClientePorId(cliente.Id);
        }

        [HttpGet]
        public List<ReadClienteDTO> GetCliente()
        {
            List<ReadClienteDTO> clienteDto = new List<ReadClienteDTO>();
            foreach (var cliente in _context.Clientes)
            {
                clienteDto.Add(_mapper.Map<ReadClienteDTO>(cliente));
            }
            return clienteDto;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaClientePorId(Guid id)
        {
            Cliente cliente = _context.Clientes.FirstOrDefault(cliente => cliente.Id == id);
            if (cliente != null)
            {
                ReadClienteDTO ClienteDto = _mapper.Map<ReadClienteDTO>(cliente);

                return Ok(ClienteDto);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaCliente(Guid id, [FromBody] UpdateClienteDTO clienteDto)
        {
            Cliente cliente = _context.Clientes.FirstOrDefault(cliente => cliente.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }
            _mapper.Map(clienteDto, cliente);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaCliente(Guid id)
        {
            Cliente cliente = _context.Clientes.FirstOrDefault(cliente => cliente.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }
            _context.Remove(cliente);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
