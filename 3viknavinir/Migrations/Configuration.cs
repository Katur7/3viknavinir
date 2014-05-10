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
                new Category { Id = 14, name = "Heimildamyndir", posterPath = "~/Content/categoryImg/documentary.jpg" },
				new Category { Id = 15, name = "Annað", posterPath = "~/Content/categoryImg/other.jpg" }
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
                new Media { Id = 2, title = "Notebook", yearOfRelease = 2004, description = "Þriggja vasaklúta mynd.", posterPath = "~/Content/categoryImg/romantic.jpg", categoryID = 5 },
				new Media { Id = 3, title = "Fight Club", yearOfRelease = 1999, description = "First rule of Fight Club, you don't talk about the fight club.", posterPath = null, categoryID = 6 },
				new Media { Id = 4, title = "Pulp Fiction", yearOfRelease = 1997, description = "Quintin Tarantino, nuff said.", posterPath = null, categoryID = 6 },
				new Media { Id = 5, title = "The Expendables", yearOfRelease = 2011, description = "Testesteron.", posterPath = null, categoryID = 8 },
				new Media { Id = 6, title = "Sódóma Reykjavík", yearOfRelease = 1995, description = "Hver hata ekki þegar fjarstýringin týnist, þúst steinöld much.", posterPath = null, categoryID = 3 },
				new Media { Id = 7, title = "Braveheart", yearOfRelease = 1998, description = "Skotar skutu skota, nema það voru ekki til skot.", posterPath = null, categoryID = 2 },
				new Media { Id = 8, title = "Sound of Music", yearOfRelease = 1998, description = "Kona að syngja", posterPath = null, categoryID = 4 },
				new Media { Id = 9, title = "Saw", yearOfRelease = 2004, description = "Fjallar um smið sem týnir söginni sinni og lendir í miklum vandræðum þegar hann fer að leita að henni", posterPath = null, categoryID = 7 },
				new Media { Id = 10, title = "Cars", yearOfRelease = 2009, description = "Talandi bílar", posterPath = null, categoryID = 9 },
				new Media { Id = 11, title = "Green Mile", yearOfRelease = 2000, description = "Fangavörður fær krabbamein", posterPath = null, categoryID = 10 },
				new Media { Id = 12, title = "Star Wars", yearOfRelease = 1996, description = "Loðinn kall og Indiana Jones fljúga um geiminn", posterPath = null, categoryID = 11 },
				new Media { Id = 13, title = "Friends", yearOfRelease = 1998, description = "Nokkrir vinir búa í New York", posterPath = null, categoryID = 12 },
				new Media { Id = 14, title = "Pokemon", yearOfRelease = 1997, description = "Skrímsli í kúlum", posterPath = null, categoryID = 13 },
				new Media { Id = 15, title = "Planet Earth", yearOfRelease = 2012, description = "Breski gamli kallinn skoða jörðina", posterPath = null, categoryID = 14 },
				new Media { Id = 16, title = "Pirates", yearOfRelease = 2005, description = "Það eru sjóræningjar og beinagrindur og fleira", posterPath = null, categoryID = 15 }
            );

            context.Requests.AddOrUpdate(
                r => r.Id,
                new Requests { Id = 0, dateOfRequest = DateTime.Now, title = "Superstar", yearOfRelease = 1999, imdbID = "", userID = "419deb0b-479c-4daa-93c5-4d15180d7bce" },
                new Requests { Id = 1, dateOfRequest = DateTime.Now, title = "300", yearOfRelease = 2006, imdbID = "", userID = "419deb0b-479c-4daa-93c5-4d15180d7bce" } 
            );

            context.Translation.AddOrUpdate(
                t => t.Id,
				new Translation { Id = 0, finished = false, mediaID = 0, languageID = 0, userID = "419deb0b-479c-4daa-93c5-4d15180d7bce", dateAdded = DateTime.Now },
				new Translation { Id = 1, finished = false, mediaID = 1, languageID = 0, userID = "419deb0b-479c-4daa-93c5-4d15180d7bce", dateAdded = DateTime.Now }
            );

            context.TranslationLines.AddOrUpdate(
                tl => tl.Id,
                new TranslationLines {Id = 0, chapterNumber = 1, startTime = "01:02", endTime = "01:03", subtitle = "Við erum bílar.", isEditing = false, dateOfSubmission = DateTime.Now, translationID = 0},
                new TranslationLines { Id = 1, chapterNumber = 3, startTime = "03:02", endTime = "03:03", subtitle = "Við keyrum örugglega eitthvað.", isEditing = false, dateOfSubmission = DateTime.Now, translationID = 1}
            );

            context.Upvote.AddOrUpdate(
                u => u.Id,
                new Upvote { Id = 0, userID = "419deb0b-479c-4daa-93c5-4d15180d7bce", translationID = 1, requestID = 0, discussionID = 0 },
                new Upvote { Id = 1, userID = "419deb0b-479c-4daa-93c5-4d15180d7bce", translationID = 0, requestID = 1, discussionID = 0 },
				new Upvote { Id = 2, userID = "419deb0b-479c-4daa-93c5-4d15180d7bce", translationID = 0, requestID = 0, discussionID = 1 }
            );
			context.SaveChanges();
        }
    }
}
