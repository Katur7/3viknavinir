namespace _3viknavinir.Models
{
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;
	using Microsoft.AspNet.Identity.EntityFramework;

	public partial class _3viknaContext : IdentityDbContext
	{
		public _3viknaContext()
			: base("DefaultConnection")
		{
		}

		public virtual DbSet<Category> Category { get; set; }
		public virtual DbSet<Discussion> Discussion { get; set; }
		public virtual DbSet<Language> Language { get; set; }
		public virtual DbSet<Media> Media { get; set; }
		public virtual DbSet<Requests> Requests { get; set; }
		public virtual DbSet<Translation> Translation { get; set; }
		public virtual DbSet<TranslationLines> TranslationLines { get; set; }
		public virtual DbSet<Upvote> Upvote { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Language>()
				.HasMany(e => e.Translation)
				.WithRequired(e => e.Language)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Translation>()
				.HasMany(e => e.TranslationLines)
				.WithRequired(e => e.Translation)
				.WillCascadeOnDelete(false);

			base.OnModelCreating(modelBuilder);
		}
	}
}
