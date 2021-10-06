using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sprint05_API_Cidade.Controllers
{
    [Controller]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private PaisContext _context = new PaisContext();
        private IMapper _mapper;

        public ClienteController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpPost("{CEP}")]
        public IActionResult CreateCliente([FromBody] CreateClienteDTO clienteDTO, String cep)
        {
            Cliente cliente = _mapper.Map<Cliente>(clienteDTO);
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaClientePorId), new { Id = cliente.Id }, cliente);
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
