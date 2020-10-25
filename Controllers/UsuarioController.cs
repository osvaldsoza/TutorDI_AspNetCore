using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TutorDI.Model;

namespace TutorDI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepository;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepository = usuarioRepositorio;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_usuarioRepository.GetListaTodosUsuarios());
        }
    }
}
