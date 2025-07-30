using user_task_api.model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace user_task_api.Data.Map
{

    public class TaskMap : IEntityTypeConfiguration<TarefaModel>
    {

        public void Configure(EntityTypeBuilder<TarefaModel> builder)
        {
            // Especifica o nome da tabela
            builder.ToTable("Tarefas");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Titulo).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Descricao).HasMaxLength(1000);
            builder.Property(x => x.Status).HasDefaultValue(StatusTarefa.Afazer);

            builder.Property(x => x.DataCreated)
                .IsRequired()
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(x => x.DataUpdated)
                .ValueGeneratedOnUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP");

            builder.Property(x => x.DataDeleted);
        }
    }

}