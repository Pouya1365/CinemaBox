using CinemaBox.Domain.Servers.Servers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaBox.Configuration.Servers.Servers;

public class ServerConfiguration : IEntityTypeConfiguration<Server>
{
    public void Configure(EntityTypeBuilder<Server> builder)
    {
        builder.ToTable<Server>(name: "Servers", schema: "Server");

        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id).UseIdentityColumn().ValueGeneratedOnAdd().IsRequired().HasColumnName("ServerId").HasComment(comment: "شناسه سرور");
        builder.Property(s => s.ServerTypeId).HasComment(comment: "شناسه نوع سرور");
        builder.Property(s => s.ServerName).HasMaxLength(50).HasComment(comment: "عنوان سرور");
        builder.Property(s => s.Path).HasMaxLength(250).HasComment(comment: "مسیر");
        builder.HasOne(s => s.ServerType).WithMany(s => s.Servers).HasForeignKey(s => s.ServerTypeId);
        builder.HasData(new Server { Path = "Images/People", ServerName = "PeoplePrimaryImage", ServerTypeId = 1, Id = 1 });
        builder.HasData(new Server { Path = "Images/Movie", ServerName = "MoviePrimaryImage", ServerTypeId = 2, Id = 2 });
    }
}