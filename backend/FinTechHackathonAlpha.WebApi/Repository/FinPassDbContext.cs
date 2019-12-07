using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinTechHackathonAlpha.WebApi.Entity;
using Microsoft.EntityFrameworkCore;

namespace FinTechHackathonAlpha.WebApi.Repository
{
	public class FinPassDbContext : DbContext
	{
		public FinPassDbContext(DbContextOptions<FinPassDbContext> options)
			: base(options)
		{
		}

		public DbSet<Profile> Profiles { get; set; }

		public DbSet<ProfileArtifact> ProfileArtifacts { get; set; }

		public DbSet<DocumentTemplate> DocumentTemplates { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
		}
	}
}
