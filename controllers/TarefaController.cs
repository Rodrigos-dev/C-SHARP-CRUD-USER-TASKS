using user_task_api.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;
using user_task_api.model;

namespace user_task_api.Controllers
{
    [Route("api/[controller]")]  //api/Usuario => ISSO AKI INDICA QUE EH O NOME DO CONTROLLER [controller]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaRepositorio _tarefaRepositorio;
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public TarefaController(ITarefaRepositorio tarefaRepositorio, IUsuarioRepositorio usuarioRepositorio)
        {
            _tarefaRepositorio = tarefaRepositorio;
            _usuarioRepositorio = usuarioRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<UsuarioModel>>> BuscarTodosUsuarios()
        {
            var tarefas = await _tarefaRepositorio.BuscarTodas();
            return Ok(tarefas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TarefaModel>> BuscarPorId(int id)
        {
            var tarefa = await _tarefaRepositorio.BuscarPorId(id);
            if (tarefa == null)
                return NotFound();
            return Ok(tarefa);
        }

        [HttpPost]
        public async Task<ActionResult<TarefaModel>> Adicionar([FromBody] TarefaModel tarefa)
        {
            Console.WriteLine("Teste variavel de ambienteeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee");
            // Verifique se o UsuarioId é válido
            var usuario = await _usuarioRepositorio.BuscarPorId(tarefa.UsuarioId);
            if (usuario == null)
            {
                return BadRequest(new { mensagem = "Usuário não encontrado." });
            }

            // Adicione a tarefa           
            var novaTarefa = await _tarefaRepositorio.Adicionar(tarefa);
            return CreatedAtAction(nameof(BuscarPorId), new { id = novaTarefa.Id }, novaTarefa);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TarefaModel>> Atualizar(int id, [FromBody] TarefaModel tarefa)
        {
            var tarefaAtualizado = await _tarefaRepositorio.Atualizar(tarefa, id);
            if (tarefaAtualizado == null)
                return NotFound();
            return Ok(tarefaAtualizado);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Apagar(int id)
        {
            var apagado = await _tarefaRepositorio.Apagar(id);
            if (!apagado)
                return NotFound();
            return Ok(apagado);
        }


        [HttpPatch("{id}")]
        public async Task<ActionResult<TarefaModel>> AtualizarParcial(int id, [FromBody] Dictionary<string, object> atualizacoes)
        {
            try
            {
                var usuarioAtualizado = await _tarefaRepositorio.AtualizarParcial(id, atualizacoes);
                return Ok(usuarioAtualizado);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }
    }
}