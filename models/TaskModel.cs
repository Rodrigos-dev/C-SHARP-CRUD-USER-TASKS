using System.Text.Json.Serialization;

namespace user_task_api.model
{
    public class TarefaModel
    {
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }

        public StatusTarefa Status { get; set; }


        public DateTime DataCreated { get; set; } = DateTime.UtcNow;
        public DateTime? DataUpdated { get; set; }
        public DateTime? DataDeleted { get; set; }

        // Chave estrangeira para UsuarioModel
        public int UsuarioId { get; set; }

        [JsonIgnore] // Ignora a propriedade durante a serialização
        public UsuarioModel? Usuario { get; set; }
    }
}