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
        private CidadeContexto _context = new CidadeContexto();
        private IMapper _mapper;

        public CidadeController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpPost]
        public void PutCidade([FromBody] CreateCidadeDTO cidadeDTO)
        {
            Cidade cidade = _mapper.Map<Cidade>(cidadeDTO);
            Console.WriteLine(cidadeDTO.Estado);
            Console.WriteLine(cidade.Estado);
            _context.Cidades.Add(cidade);
            _context.SaveChanges();
            //return _context.Cidades;
            //return CreatedAtAction(nameof(RecuperaFilmesPorId), new { Id = filme.Id }, filme);
        }

        //[HttpGet]
        //public IEnumerable<Cidade> GetCidade()
        //{

        //    return _context.Cidades;
        //}
    }
}
