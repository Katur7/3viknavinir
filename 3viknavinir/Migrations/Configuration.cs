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
			/*
			context.Category.AddOrUpdate(
				c => c.ID,
				new Category { ID = 0, name = "Ævintýramyndir", posterPath = "~/Content/categoryImg/adventure.jpg" },
				new Category { ID = 1, name = "Gamanmynd", posterPath = "~/Content/categoryImg/comedy.jpg" },
				new Category { ID = 2, name = "Fjölskyldumyndir", posterPath = "~/Content/categoryImg/family.jpg" },
				new Category { ID = 3, name = "Íslenskar", posterPath = "~/Content/categoryImg/icelandic.jpg" },
				new Category { ID = 4, name = "Söngleikur", posterPath = "~/Content/categoryImg/musical.jpg" },
				new Category { ID = 5, name = "Rómantík", posterPath = "~/Content/categoryImg/romantic.jpg" },
				new Category { ID = 6, name = "Spennumyndir", posterPath = "~/Content/categoryImg/thiller.jpg" },
				new Category { ID = 7, name = "Hryllingsmyndir", posterPath = "~/Content/categoryImg/horror.jpg" },
				new Category { ID = 8, name = "Hasarmyndir", posterPath = "~/Content/categoryImg/action.jpg" },
				new Category { ID = 9, name = "Barnamyndir", posterPath = "~/Content/categoryImg/kids.jpg" },
				new Category { ID = 10, name = "Drama", posterPath = "~/Content/categoryImg/drama.jpg" },
				new Category { ID = 11, name = "Vísindaskáldskapur", posterPath = "~/Content/categoryImg/scifi.jpg" },
				new Category { ID = 12, name = "Þættir", posterPath = "~/Content/categoryImg/show.jpg" },
				new Category { ID = 13, name = "Anime", posterPath = "~/Content/categoryImg/anime.jpg" },
				new Category { ID = 14, name = "Heimildamyndir", posterPath = "~/Content/categoryImg/documentary.jpg" },
				new Category { ID = 15, name = "Annað", posterPath = "~/Content/categoryImg/other.jpg" }
			);
			context.SaveChanges();
			
			context.Language.AddOrUpdate(
				l => l.ID,
				new Language { ID = 0, name = "Íslenska" }
			);

			context.Discussion.AddOrUpdate(
				d => d.ID,
				new Discussion { ID = 0, comment = "First!", dateAdded = DateTime.Now, userID = "419deb0b-479c-4daa-93c5-4d15180d7bce", mediaID = 0 },
				new Discussion { ID = 1, comment = "Second!", dateAdded = DateTime.Now, userID = "419deb0b-479c-4daa-93c5-4d15180d7bce", mediaID = 1 },
				new Discussion { ID = 2, comment = "Yolo", dateAdded = DateTime.Now, userID = "419deb0b-479c-4daa-93c5-4d15180d7bce", mediaID = 2 }
			);

			context.Media.AddOrUpdate(
				m => m.ID,
				new Media { ID = 0, title = "Narnia", yearOfRelease = 2005, description = "Skemmtileg mynd um skápa.", posterPath = "/Content/categoryImg/adventure.jpg", categoryID = 0 },
				new Media { ID = 1, title = "Ace Ventura: Pet Detective", yearOfRelease = 1994, description = "Mjög fyndin mynd.", posterPath = "/Content/categoryImg/comedy.jpg", categoryID = 1 },
				new Media { ID = 2, title = "Notebook", yearOfRelease = 2004, description = "Þriggja vasaklúta mynd.", posterPath = "/Content/categoryImg/romantic.jpg", categoryID = 5 },
				new Media { ID = 3, title = "Fight Club", yearOfRelease = 1999, description = "First rule of Fight Club, you don't talk about the fight club.", posterPath = null, categoryID = 6 },
				new Media { ID = 4, title = "Pulp Fiction", yearOfRelease = 1997, description = "Quintin Tarantino, nuff said.", posterPath = null, categoryID = 6 },
				new Media { ID = 5, title = "The Expendables", yearOfRelease = 2011, description = "Testesteron.", posterPath = null, categoryID = 8 },
				new Media { ID = 6, title = "Sódóma Reykjavík", yearOfRelease = 1995, description = "Hver hata ekki þegar fjarstýringin týnist, þúst steinöld much.", posterPath = null, categoryID = 3 },
				new Media { ID = 7, title = "Braveheart", yearOfRelease = 1998, description = "Skotar skutu skota, nema það voru ekki til skot.", posterPath = null, categoryID = 2 },
				new Media { ID = 8, title = "Sound of Music", yearOfRelease = 1998, description = "Kona að syngja", posterPath = null, categoryID = 4 },
				new Media { ID = 9, title = "Saw", yearOfRelease = 2004, description = "Fjallar um smið sem týnir söginni sinni og lendir í miklum vandræðum þegar hann fer að leita að henni", posterPath = null, categoryID = 7 },
				new Media { ID = 10, title = "Cars", yearOfRelease = 2009, description = "Talandi bílar", posterPath = null, categoryID = 9 },
				new Media { ID = 11, title = "Green Mile", yearOfRelease = 2000, description = "Fangavörður fær krabbamein", posterPath = null, categoryID = 10 },
				new Media { ID = 12, title = "Star Wars", yearOfRelease = 1996, description = "Loðinn kall og Indiana Jones fljúga um geiminn", posterPath = null, categoryID = 11 },
				new Media { ID = 13, title = "Friends", yearOfRelease = 1998, description = "Nokkrir vinir búa í New York", posterPath = null, categoryID = 12 },
				new Media { ID = 14, title = "Pokemon", yearOfRelease = 1997, description = "Skrímsli í kúlum", posterPath = null, categoryID = 13 },
				new Media { ID = 15, title = "Planet Earth", yearOfRelease = 2012, description = "Breski gamli kallinn skoða jörðina", posterPath = null, categoryID = 14 },
				new Media { ID = 16, title = "Pirates", yearOfRelease = 2005, description = "Það eru sjóræningjar og beinagrindur og fleira", posterPath = null, categoryID = 15 }
			);
			
			context.Requests.AddOrUpdate(
				r => r.ID,
				new Requests { ID = 0, dateOfRequest = DateTime.Now, title = "Superstar", yearOfRelease = 1999, imdbID = "", userID = "419deb0b-479c-4daa-93c5-4d15180d7bce" },
				new Requests { ID = 1, dateOfRequest = DateTime.Now, title = "300", yearOfRelease = 2006, imdbID = "", userID = "419deb0b-479c-4daa-93c5-4d15180d7bce" }
			);
			
			context.Translation.AddOrUpdate(
				t => t.ID,
				new Translation { ID = 0, finished = false, mediaID = 0, languageID = 0, userID = "5914b583-645b-4793-a9da-b2d49669706f", dateAdded = DateTime.Now },
				new Translation { ID = 1, finished = false, mediaID = 1, languageID = 0, userID = "5914b583-645b-4793-a9da-b2d49669706f", dateAdded = DateTime.Now },
				new Translation { ID = 2, finished = false, mediaID = 2, languageID = 0, userID = "5914b583-645b-4793-a9da-b2d49669706f", dateAdded = DateTime.Now },
				new Translation { ID = 3, finished = false, mediaID = 3, languageID = 0, userID = "5914b583-645b-4793-a9da-b2d49669706f", dateAdded = new DateTime(2001, 12, 7) },
				new Translation { ID = 4, finished = false, mediaID = 4, languageID = 0, userID = "5914b583-645b-4793-a9da-b2d49669706f", dateAdded = DateTime.Now },
				new Translation { ID = 5, finished = false, mediaID = 5, languageID = 0, userID = "5914b583-645b-4793-a9da-b2d49669706f", dateAdded = DateTime.Now },
				new Translation { ID = 6, finished = false, mediaID = 6, languageID = 0, userID = "5914b583-645b-4793-a9da-b2d49669706f", dateAdded = DateTime.Now },
				new Translation { ID = 7, finished = false, mediaID = 7, languageID = 0, userID = "5914b583-645b-4793-a9da-b2d49669706f", dateAdded = DateTime.Now },
				new Translation { ID = 8, finished = false, mediaID = 8, languageID = 0, userID = "5914b583-645b-4793-a9da-b2d49669706f", dateAdded = DateTime.Now },
				new Translation { ID = 9, finished = false, mediaID = 9, languageID = 0, userID = "5914b583-645b-4793-a9da-b2d49669706f", dateAdded = DateTime.Now },
				new Translation { ID = 10, finished = false, mediaID = 10, languageID = 0, userID = "5914b583-645b-4793-a9da-b2d49669706f", dateAdded = DateTime.Now },
				new Translation { ID = 11, finished = false, mediaID = 11, languageID = 0, userID = "5914b583-645b-4793-a9da-b2d49669706f", dateAdded = DateTime.Now },
				new Translation { ID = 12, finished = false, mediaID = 12, languageID = 0, userID = "5914b583-645b-4793-a9da-b2d49669706f", dateAdded = DateTime.Now },
				new Translation { ID = 13, finished = false, mediaID = 13, languageID = 0, userID = "5914b583-645b-4793-a9da-b2d49669706f", dateAdded = new DateTime(2000, 12, 7) },
				new Translation { ID = 14, finished = false, mediaID = 14, languageID = 0, userID = "5914b583-645b-4793-a9da-b2d49669706f", dateAdded = DateTime.Now },
				new Translation { ID = 15, finished = false, mediaID = 15, languageID = 0, userID = "5914b583-645b-4793-a9da-b2d49669706f", dateAdded = DateTime.Now },
				new Translation { ID = 16, finished = false, mediaID = 16, languageID = 0, userID = "5914b583-645b-4793-a9da-b2d49669706f", dateAdded = new DateTime(2002, 12, 7) }
			);
			
			context.TranslationLines.AddOrUpdate(
				tl => tl.ID,
				new TranslationLines { ID = 0, chapterNumber = 1, startTime = "01:02", endTime = "01:03", subtitle = "Við erum bílar.", isEditing = false, dateOfSubmission = DateTime.Now, translationID = 0 },
				new TranslationLines { ID = 1, chapterNumber = 2, startTime = "03:02", endTime = "03:03", subtitle = "Við keyrum örugglega eitthvað.", isEditing = false, dateOfSubmission = DateTime.Now, translationID = 0 }
			);
			
			context.Upvote.AddOrUpdate(
				u => u.Id,
				new Upvote { Id = 0, userID = "419deb0b-479c-4daa-93c5-4d15180d7bce", translationID = 1, requestID = 0, discussionID = 0 },
				new Upvote { Id = 1, userID = "419deb0b-479c-4daa-93c5-4d15180d7bce", translationID = 0, requestID = 1, discussionID = 0 },
				new Upvote { Id = 2, userID = "419deb0b-479c-4daa-93c5-4d15180d7bce", translationID = 0, requestID = 0, discussionID = 1 }
			);
			context.SaveChanges();
			*/
		}
    }
}
