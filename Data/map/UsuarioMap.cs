using user_task_api.model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace user_task_api.Data.Map
{

    public class UsuarioMap : IEntityTypeConfiguration<UsuarioModel>
    {

        public void Configure(EntityTypeBuilder<UsuarioModel> builder)
        {
            // Especifica o nome da tabela
            builder.ToTable("Usuarios");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(150);

            builder.Property(x => x.DataCreated)
            .IsRequired()
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(x => x.DataUpdated)
                .ValueGeneratedOnUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP");

            builder.Property(x => x.DataDeleted);

            // Adiciona o índice na coluna Email
            builder.HasIndex(x => x.Email).HasDatabaseName("IX_Usuario_Email");

            // Configuração do relacionamento one-to-many
            builder.HasMany(u => u.Tarefas)
                   .WithOne(t => t.Usuario)
                   .HasForeignKey(t => t.UsuarioId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }

}