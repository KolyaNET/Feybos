using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Feybos.WebApp.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			var prefix = "Core";

			builder.Entity<IdentityUser>().ToTable(prefix + "Users");
			builder.Entity<IdentityUserRole<string>>().ToTable(prefix + "UserRoles");
			builder.Entity<IdentityUserLogin<string>>().ToTable(prefix + "UserLogins");
			builder.Entity<IdentityUserClaim<string>>().ToTable(prefix + "UserClaims");
			builder.Entity<IdentityRole>().ToTable(prefix + "Roles");
			builder.Entity<IdentityRoleClaim<string>>().ToTable(prefix + "RoleClaims");
			builder.Entity<IdentityUserToken<string>>().ToTable(prefix + "UserTokens");
		}
	}
}