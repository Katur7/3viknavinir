namespace _3viknavinir.Migrations
{
	using _3viknavinir.Models;
	using System;
	using System.Data.Entity;
	using System.Data.Entity.Migrations;
	using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<_3viknavinir.Models._3viknaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(_3viknavinir.Models._3viknaContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.

            context.Category.AddOrUpdate(
				c => c.Id,
				new Category { Id = 0, name = "Ævintýramyndir", posterPath = "~/Content/categoryImg/adventure.jpg"},
                new Category { Id = 1, name = "Gamanmynd", posterPath = "~/Content/categoryImg/comedy.jpg" },
                new Category { Id = 2, name = "Fjölskyldumyndir", posterPath = "~/Content/categoryImg/family.jpg" },
                new Category { Id = 3, name = "Íslenskar", posterPath = "~/Content/categoryImg/icelandic.jpg" },
                new Category { Id = 4, name = "Söngleikur", posterPath = "~/Content/categoryImg/musical.jpg" },
                new Category { Id = 5, name = "Rómantík", posterPath = "~/Content/categoryImg/romantic.jpg" },
                new Category { Id = 6, name = "Spennumyndir", posterPath = "~/Content/categoryImg/thiller.jpg" },
                new Category { Id = 7, name = "Hryllingsmyndir", posterPath = "~/Content/categoryImg/horror.jpg" },
                new Category { Id = 8, name = "Hasarmyndir", posterPath = "~/Content/categoryImg/action.jpg" },
                new Category { Id = 9, name = "Barnamyndir", posterPath = "~/Content/categoryImg/kids.jpg" },
                new Category { Id = 10, name = "Drama", posterPath = "~/Content/categoryImg/drama.jpg" },
                new Category { Id = 11, name = "Vísindaskáldskapur", posterPath = "~/Content/categoryImg/scifi.jpg" },
                new Category { Id = 12, name = "Þættir", posterPath = "~/Content/categoryImg/show.jpg" },
                new Category { Id = 13, name = "Anime", posterPath = "~/Content/categoryImg/anime.jpg" },
                new Category { Id = 14, name = "Heimildamyndir", posterPath = "~/Content/categoryImg/documentary.jpg" }
            );

			context.Language.AddOrUpdate(
				l => l.Id,
				new Language { Id = 0, name = "Íslenska"}
            );

			context.SaveChanges();
        }
    }
}
