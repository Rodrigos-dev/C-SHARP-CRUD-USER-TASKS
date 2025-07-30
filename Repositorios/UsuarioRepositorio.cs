using user_task_api.Data;
using user_task_api.model;
using user_task_api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;



namespace user_task_api.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {

        private readonly DataBaseContext _dbContext;

        public UsuarioRepositorio(DataBaseContext dataBaseContext)
        {
            _dbContext = dataBaseContext;
        }

        public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
        {
            //throw new NotImplementedException();

            _dbContext.Usuarios.Add(usuario);
            await _dbContext.SaveChangesAsync();
            return usuario;

        }

        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
        {
            var usuarioExistente = await _dbContext.Usuarios.FindAsync(id);
            if (usuarioExistente == null)
            {
                throw new Exception($"Usuário para o ID: {id} não foi encontrado no banco de dados");
            }

            usuarioExistente.Nome = usuario.Nome;
            usuarioExistente.Email = usuario.Email;
            // Atualize outras propriedades conforme necessário

            _dbContext.Usuarios.Update(usuarioExistente);
            await _dbContext.SaveChangesAsync();
            return usuarioExistente;
        }

        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _dbContext.Usuarios
            .Include(u => u.Tarefas) // Inclui tarefas relacionadas
            .ToListAsync();
        }

        public async Task<UsuarioModel> BuscarPorId(int id)
        {
            return await _dbContext.Usuarios.FindAsync(id);
        }

        public async Task<bool> Apagar(int id)
        {
            var usuarioExistente = await _dbContext.Usuarios.FindAsync(id);
            if (usuarioExistente == null)
            {
                throw new Exception($"Usuário para o ID: {id} não foi encontrado no banco de dados");
            }

            _dbContext.Usuarios.Remove(usuarioExistente);
            await _dbContext.SaveChangesAsync();
            return true;
        }


        public async Task<UsuarioModel> AtualizarParcial(int id, Dictionary<string, object> atualizacoes)
        {
            var usuarioExistente = await _dbContext.Usuarios.FindAsync(id);
            if (usuarioExistente == null)
            {
                throw new Exception($"Usuário para o ID: {id} não foi encontrado no banco de dados");
            }

            var usuarioType = typeof(UsuarioModel);
            foreach (var atualizacao in atualizacoes)
            {
                var property = usuarioType.GetProperty(atualizacao.Key, System.Reflection.BindingFlags.IgnoreCase | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
                if (property != null && property.CanWrite)
                {
                    try
                    {
                        var jsonElement = (JsonElement)atualizacao.Value;
                        var newValue = jsonElement.Deserialize(property.PropertyType);
                        property.SetValue(usuarioExistente, newValue);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"Erro ao atualizar a propriedade '{atualizacao.Key}': {ex.Message}");
                    }
                }
            }

            _dbContext.Usuarios.Update(usuarioExistente);
            await _dbContext.SaveChangesAsync();
            return usuarioExistente;
        }

    }

}