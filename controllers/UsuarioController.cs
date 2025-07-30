using user_task_api.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;
using user_task_api.model;

namespace user_task_api.Controllers
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
        public async Task<ActionResult<List<UsuarioModel>>> BuscarTodosUsuarios()
        {
            var usuarios = await _usuarioRepositorio.BuscarTodosUsuarios();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioModel>> BuscarPorId(int id)
        {
            var usuario = await _usuarioRepositorio.BuscarPorId(id);
            if (usuario == null)
                return NotFound();
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> Adicionar([FromBody] UsuarioModel usuario)
        {
            var novoUsuario = await _usuarioRepositorio.Adicionar(usuario);
            return CreatedAtAction(nameof(BuscarPorId), new { id = novoUsuario.Id }, novoUsuario);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UsuarioModel>> Atualizar(int id, [FromBody] UsuarioModel usuario)
        {
            var usuarioAtualizado = await _usuarioRepositorio.Atualizar(usuario, id);
            if (usuarioAtualizado == null)
                return NotFound();
            return Ok(usuarioAtualizado);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Apagar(int id)
        {
            var apagado = await _usuarioRepositorio.Apagar(id);
            if (!apagado)
                return NotFound();
            return Ok(apagado);
        }


        [HttpPatch("{id}")]
        public async Task<ActionResult<UsuarioModel>> AtualizarParcial(int id, [FromBody] Dictionary<string, object> atualizacoes)
        {
            try
            {
                var usuarioAtualizado = await _usuarioRepositorio.AtualizarParcial(id, atualizacoes);
                return Ok(usuarioAtualizado);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }
    }
}