using CinemaBox.Domain.Servers.ServerTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaBox.Configuration.Servers.ServerTypes;
public class ServerTypeConfiguration : IEntityTypeConfiguration<ServerType>
{
    public void Configure(EntityTypeBuilder<ServerType> builder)
    {
        builder.ToTable<ServerType>(name: "ServerTypes", schema: "Server");

        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).UseIdentityColumn().ValueGeneratedOnAdd().IsRequired().HasColumnName("ServerTypeId").HasComment(comment: "شناسه نوع سرور");
        builder.Property(c => c.ServerTypeName).HasMaxLength(50).IsRequired(true).HasComment(comment: "عنوان سرور");
        builder.HasData(new ServerType { Id = 1, ServerTypeName = "People"  }, new ServerType { Id = 2, ServerTypeName = "Movie"},new ServerType { Id = 3, ServerTypeName = "UserMovie" });
    }
}