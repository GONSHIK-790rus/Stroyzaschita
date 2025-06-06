using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Stroyzaschita.Domain.Entities;
using Stroyzaschita.Shared.Constants;

namespace Stroyzaschita.Persistence.Configurations;

public class MessageConfiguration : IEntityTypeConfiguration<Message> {
    public void Configure(EntityTypeBuilder<Message> builder) {
        builder.ToTable("messages");

        builder.HasKey(mesage => mesage.Id);

        builder.Property(message => message.Id)
            .HasColumnName("id");

        builder.Property(message => message.Text)
            .HasColumnName("text")
            .HasMaxLength(FieldLengths.LONG_FIELD_LENGTH)
            .IsRequired();

        builder.Property(message => message.SenderId)
            .HasColumnName("sender_id");

        builder.Property(message => message .ReceiverId)
            .HasColumnName("receiver_id");

        builder.Property(message => message.AttchedRequestFileId)
            .HasColumnName("attched_request_file_id");

        builder.Property(message => message.CreatedAt)
            .HasColumnName("created_at");

        builder.Property(message => message.IsRead)
            .HasColumnName("is_read");

        builder.HasOne(message => message.Sender)
            .WithMany()
            .HasForeignKey(message => message.SenderId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(message => message.Receiver)
            .WithMany()
            .HasForeignKey(message => message.ReceiverId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(message => message.AttachedRequest)
            .WithMany()
            .HasForeignKey(message => message.AttchedRequestFileId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}

