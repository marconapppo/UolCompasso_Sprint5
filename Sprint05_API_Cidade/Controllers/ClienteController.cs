using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http.Description;

namespace Sprint05_API_Cidade.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {
        private PaisContext _context;
        private IMapper _mapper;
        private readonly HttpClient _httpClient;

        public ClienteController(IMapper mapper, HttpClient httpClient)
        {
            _mapper = mapper;
            _httpClient = httpClient;
            _context = new PaisContext();
        }

        [HttpPost]
        [ResponseType(typeof(CreateClienteDTO))]
        public async Task<IActionResult> CreateClienteAsync([FromBody] CreateClienteDTO clienteDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    clienteDTO.Cep = clienteDTO.Cep.Replace("-", "");
                    //pegando a cidade da pessoa pelo CEP, utilizando o site abaixo
                    var responseString = await _httpClient.GetStringAsync("https://viacep.com.br/ws/" + clienteDTO.Cep + "/json/");
                    var catalog = JsonConvert.DeserializeObject<CatalogCep>(responseString);
                    //cruzando os valores de cidade com os do banco
                    Cidade cidade = _context.Cidades.FirstOrDefault(cidade => cidade.Nome == catalog.localidade);
                    if (cidade != null)
                    {
                        //recebendo valores de cidade e catalog, e caso logradouro ou bairro seja null, insere o que veio no corpo
                        if (!string.IsNullOrEmpty(catalog.logradouro)) { clienteDTO.Logradouro = catalog.logradouro; }
                        if (!string.IsNullOrEmpty(catalog.bairro)) { clienteDTO.Bairro = catalog.bairro; }
                        //cadastrando cliente
                        Cliente cliente = _mapper.Map<Cliente>(clienteDTO);
                        //o dto nao possui  cidadeId, então eu insero direto
                        cliente.CidadeId = cidade.Id;
                        _context.Clientes.Add(cliente);
                        _context.SaveChanges();
                        return RecuperaClientePorId(cliente.Id);
                    }
                    return NotFound();
                }
                return BadRequest(ModelState);
            }
            catch (Exception e)
            {
                return NotFound();
            }
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
