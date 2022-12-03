using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositorio.Interfaces;

namespace SistemaDeTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }


        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> BuscarTodosUsuarios()
        {
            List<UsuarioModel> usuarios = await _usuarioRepositorio.BuscarTodosUsuarios();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<UserModel>>> BuscarPorId(int id)
        {
            UsuarioModel usuario = await _usuarioRepositorio.BuscarPorId(id);
            if (usuario == null)
            {
                return BadRequest("Usuario não encontrado");
            }
            else
            {
                return Ok(usuario);
            }
        }

        [HttpPost]
        public async Task<ActionResult<List<UsuarioModel>>> Cadastrar([FromBody] UsuarioModel usuarioModel)
        {
            List<UsuarioModel> usuario = await _usuarioRepositorio.Adicionar(usuarioModel);
            return Ok(usuario);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UsuarioModel>> Atualizar([FromBody] UsuarioModel usuarioModel, int id)
        {
            usuarioModel.id = id;
            UsuarioModel user = await _usuarioRepositorio.Atualizar(usuarioModel, id);
            return(user);
            
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuarioModel>> Apagar(int id)
        {
            UsuarioModel usuario = await _usuarioRepositorio.BuscarPorId(id);
            if(usuario == null)
            {
                return NotFound("Usuario não encontrado");
            }
            else
            {
                usuario.id = id;
                bool apagado = await _usuarioRepositorio.Apagar(id);
                return Ok(apagado);
            }
        }
    }
}
