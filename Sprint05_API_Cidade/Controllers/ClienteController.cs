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
    public class ClienteController : ControllerBase
    {
        private PaisContext _context = new PaisContext();
        private IMapper _mapper;

        public ClienteController(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}
