using user_task_api.model;

namespace user_task_api.Repositorios.Interfaces
{

    public interface IUsuarioRepositorio
    {
        Task<List<UsuarioModel>> BuscarTodosUsuarios();
        Task<UsuarioModel> BuscarPorId(int id);
        Task<UsuarioModel> Adicionar(UsuarioModel usuario);
        Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id);
        Task<UsuarioModel> AtualizarParcial(int id, Dictionary<string, object> atualizacoes);
        Task<bool> Apagar(int id);

    }
}