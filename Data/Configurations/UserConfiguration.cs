using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeSheets.Models.Enities;

namespace TimeSheets.Data.Configurations
{
	public class UserConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.ToTable("users");

			builder.Property(x => x.Id)
				.ValueGeneratedNever()
				.HasColumnName("Id");

		}
	}
}