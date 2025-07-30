using System.ComponentModel;

namespace user_task_api.model
{

    public enum StatusTarefa
    {
        [Description("A fazer")]
        Afazer = 1,

        [Description("Em Andamento")]
        EmAndamento = 2,

        [Description("Concluido")]
        Concluido = 3

    }

}