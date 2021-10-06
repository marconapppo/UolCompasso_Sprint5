using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sprint05_API_Cidade.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CidadeController : ControllerBase
    {
        private PaisContext _context = new PaisContext();
        private IMapper _mapper;

        public CidadeController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateCidade([FromBody] CreateCidadeDTO cidadeDTO)
        {
            Cidade cidade = _mapper.Map<Cidade>(cidadeDTO);
            _context.Cidades.Add(cidade);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaCidadePorId), new { Id = cidade.Id }, cidade);
        }

        [HttpGet]
        public List<ReadCidadeDTO> GetCidade()
        {
            List<ReadCidadeDTO> cidadeDto = new List<ReadCidadeDTO>();
            
            foreach (var cidade in _context.Cidades)
            {
                cidadeDto.Add(_mapper.Map<ReadCidadeDTO>(cidade));
            }
            return cidadeDto;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaCidadePorId(Guid id)
        {
            Cidade cidade = _context.Cidades.FirstOrDefault(cidade => cidade.Id == id);
            if (cidade != null)
            {
                ReadCidadeDTO cidadeDto = _mapper.Map<ReadCidadeDTO>(cidade);

                return Ok(cidadeDto);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaCidade(Guid id, [FromBody] UpdateCidadeDTO cidadeDto)
        {
            Cidade cidade = _context.Cidades.FirstOrDefault(cidade => cidade.Id == id);
            if (cidade == null)
            {
                return NotFound();
            }
            _mapper.Map(cidadeDto, cidade);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaCidade(Guid id)
        {
            Cidade cidade = _context.Cidades.FirstOrDefault(cidade => cidade.Id == id);
            if (cidade == null)
            {
                return NotFound();
            }
            _context.Remove(cidade);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
