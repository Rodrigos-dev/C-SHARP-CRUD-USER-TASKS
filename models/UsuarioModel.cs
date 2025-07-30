namespace user_task_api.model
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }

        public DateTime DataCreated { get; set; } = DateTime.UtcNow;
        public DateTime? DataUpdated { get; set; }
        public DateTime? DataDeleted { get; set; }

        // Relacionamento com TarefaModel
        public ICollection<TarefaModel> Tarefas { get; set; } = new List<TarefaModel>();
    }
}