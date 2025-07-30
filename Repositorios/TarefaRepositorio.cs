using user_task_api.Data;
using user_task_api.model;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using user_task_api.Repositorios.Interfaces;



namespace user_task_api.Repositorios
{
    public class TarefaRepositorio : ITarefaRepositorio
    {

        private readonly DataBaseContext _dbContext;

        public TarefaRepositorio(DataBaseContext dataBaseContext)
        {
            _dbContext = dataBaseContext;
        }



        public async Task<TarefaModel> Adicionar(TarefaModel tarefa)
        {
            //throw new NotImplementedException();

            _dbContext.Tarefas.Add(tarefa);
            await _dbContext.SaveChangesAsync();
            return tarefa;

        }



        public async Task<TarefaModel> Atualizar(TarefaModel tarefa, int id)
        {
            var tarefaExistente = await _dbContext.Tarefas.FindAsync(id);
            if (tarefaExistente == null)
            {
                throw new Exception($"Usuário para o ID: {id} não foi encontrado no banco de dados");
            }

            tarefaExistente.Descricao = tarefa.Descricao;
            tarefaExistente.Descricao = tarefa.Descricao;
            tarefaExistente.Status = tarefa.Status;
            // Atualize outras propriedades conforme necessário

            _dbContext.Tarefas.Update(tarefaExistente);
            await _dbContext.SaveChangesAsync();
            return tarefaExistente;
        }




        public async Task<List<TarefaModel>> BuscarTodas()
        {
            return await _dbContext.Tarefas.ToListAsync();
        }



        public async Task<TarefaModel> BuscarPorId(int id)
        {
            return await _dbContext.Tarefas.FindAsync(id);
        }




        public async Task<bool> Apagar(int id)
        {
            var tarefaExistente = await _dbContext.Tarefas.FindAsync(id);
            if (tarefaExistente == null)
            {
                throw new Exception($"Usuário para o ID: {id} não foi encontrado no banco de dados");
            }

            _dbContext.Tarefas.Remove(tarefaExistente);
            await _dbContext.SaveChangesAsync();
            return true;
        }




        public async Task<TarefaModel> AtualizarParcial(int id, Dictionary<string, object> atualizacoes)
        {
            var tarefaExistente = await _dbContext.Tarefas.FindAsync(id);
            if (tarefaExistente == null)
            {
                throw new Exception($"Tarefa para o ID: {id} não foi encontrado no banco de dados");
            }

            var tarefaType = typeof(TarefaModel);
            foreach (var atualizacao in atualizacoes)
            {
                var property = tarefaType.GetProperty(atualizacao.Key, System.Reflection.BindingFlags.IgnoreCase | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
                if (property != null && property.CanWrite)
                {
                    try
                    {
                        var jsonElement = (JsonElement)atualizacao.Value;
                        var newValue = jsonElement.Deserialize(property.PropertyType);
                        property.SetValue(tarefaExistente, newValue);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"Erro ao atualizar a propriedade '{atualizacao.Key}': {ex.Message}");
                    }
                }
            }

            _dbContext.Tarefas.Update(tarefaExistente);
            await _dbContext.SaveChangesAsync();
            return tarefaExistente;
        }

    }

}