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

            context.Discussion.AddOrUpdate(
                d => d.Id,
                new Discussion { Id = 0, comment = "First!", dateAdded = DateTime.Now, userID = "419deb0b-479c-4daa-93c5-4d15180d7bce", mediaID = 0 },
                new Discussion { Id = 1, comment = "Second!", dateAdded = DateTime.Now, userID = "419deb0b-479c-4daa-93c5-4d15180d7bce", mediaID = 1 },
                new Discussion { Id = 2, comment = "Yolo", dateAdded = DateTime.Now, userID = "419deb0b-479c-4daa-93c5-4d15180d7bce", mediaID = 2 }
            );

            context.Media.AddOrUpdate(
                m => m.Id,
                new Media { Id = 0, title = "Narnia", yearOfRelease = 2005, description = "Skemmtileg mynd um skápa.", posterPath = "~/Content/categoryImg/adventure.jpg", categoryID = 0 },
                new Media { Id = 1, title = "Ace Ventura: Pet Detective", yearOfRelease = 1994, description = "Mjög fyndin mynd.", posterPath = "~/Content/categoryImg/comedy.jpg", categoryID = 1 },
                new Media { Id = 2, title = "Notebook", yearOfRelease = 2004, description = "Þriggja vasaklúta mynd.", posterPath = "~/Content/categoryImg/romantic.jpg", categoryID = 5 }
            );

            context.Requests.AddOrUpdate(
                r => r.Id,
                new Requests { Id = 0, upvote = 5, dateOfRequest = DateTime.Now, title = "Superstar", yearOfRelease = 1999, imdbID = "", userID = "419deb0b-479c-4daa-93c5-4d15180d7bce" },
                new Requests { Id = 1, upvote = 300, dateOfRequest = DateTime.Now, title = "300", yearOfRelease = 2006, imdbID = "", userID = "419deb0b-479c-4daa-93c5-4d15180d7bce" } 
            );

            context.Translation.AddOrUpdate(
                t => t.Id,
                new Translation { Id = 0, finished = false, mediaID = 0, languageID = 0, userID =  "419deb0b-479c-4daa-93c5-4d15180d7bce" },
                new Translation { Id = 1, finished = false, mediaID = 1, languageID = 0, userID = "419deb0b-479c-4daa-93c5-4d15180d7bce" }
            );

            context.TranslationLines.AddOrUpdate(
                tl => tl.Id,
                new TranslationLines {Id = 0, chapterNumber = 1, startTime = "01:02", endTime = "01:03", subtitle = "Við erum bílar.", isEditing = false, dateOfSubmission = DateTime.Now, translationID = 0},
                new TranslationLines { Id = 1, chapterNumber = 3, startTime = "03:02", endTime = "03:03", subtitle = "Við keyrum örugglega eitthvað.", isEditing = false, dateOfSubmission = DateTime.Now, translationID = 1}
            );

            context.Upvote.AddOrUpdate(
                u => u.Id,
                new Upvote { Id = 0, userID = "419deb0b-479c-4daa-93c5-4d15180d7bce", translationID = 0, requestID = 0, discussionID = 0 },
                new Upvote { Id = 1, userID = "419deb0b-479c-4daa-93c5-4d15180d7bce", translationID = 1, requestID = 1, discussionID = 1 }
            );
			context.SaveChanges();
        }
    }
}
