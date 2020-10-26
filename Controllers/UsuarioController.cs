using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TutorDI.Dtos;
using TutorDI.Model;
using TutorDI.Repository;

namespace TutorDI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepository;

        private readonly IMapper _mapper;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio, IMapper mapper)
        {
            _usuarioRepository = usuarioRepositorio;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var usuarios = await _usuarioRepository.GetTodosUsuariosAsync();

                var results = _mapper.Map<IEnumerable<UsuarioDTO>>(usuarios);

                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no banco de dados");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var usuario = await _usuarioRepository.GetUsuarioByIdAsync(id);

                if (usuario == null)
                {
                    return this.StatusCode(StatusCodes.Status404NotFound, "Usuário não encontrado");
                }
                var result = _mapper.Map<UsuarioDTO>(usuario);

                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no banco de dados");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Usuario usuario)
        {
            try
            {
                _usuarioRepository.Add(usuario);

                if (await _usuarioRepository.SaveChangesAsync())
                {
                    return Created($"/usuario/{usuario.UsuarioId}", usuario);
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no banco de dados");
            }

            return this.StatusCode(StatusCodes.Status400BadRequest, "Parâmetros inválidos");
        }

        [HttpPut("{usuarioId}")]
        public async Task<IActionResult> Put(int usuarioId, Usuario usuario)
        {
            try
            {
                if (await _usuarioRepository.GetUsuarioByIdAsync(usuarioId) == null)
                {
                    return this.StatusCode(StatusCodes.Status404NotFound, "Usuário não encontrado");
                }

                _usuarioRepository.Update(usuario);

                if (await _usuarioRepository.SaveChangesAsync())
                {
                    return Created($"/usuario/{usuario.UsuarioId}", usuario);
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no banco de dados");
            }

            return this.StatusCode(StatusCodes.Status400BadRequest, "Parâmetros inválidos");
        }


        [HttpDelete("{usuarioId}")]
        public async Task<IActionResult> Delete(int usuarioId)
        {
            try
            {
                var usuario = await _usuarioRepository.GetUsuarioByIdAsync(usuarioId);

                if (usuario == null)
                {
                    return this.StatusCode(StatusCodes.Status404NotFound, "Usuário não encontrado");
                }

                _usuarioRepository.Delete(usuario);

                if (await _usuarioRepository.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no banco de dados");
            }

            return this.StatusCode(StatusCodes.Status400BadRequest, "Parâmetro inválido");
        }
    }
}
