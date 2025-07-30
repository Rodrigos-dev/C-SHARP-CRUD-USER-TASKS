using user_task_api.model;

namespace user_task_api.Repositorios.Interfaces
{

    public interface ITarefaRepositorio
    {
        Task<List<TarefaModel>> BuscarTodas();
        Task<TarefaModel> BuscarPorId(int id);
        Task<TarefaModel> Adicionar(TarefaModel usuario);
        Task<TarefaModel> Atualizar(TarefaModel usuario, int id);
        Task<TarefaModel> AtualizarParcial(int id, Dictionary<string, object> atualizacoes);
        Task<bool> Apagar(int id);

    }
}
