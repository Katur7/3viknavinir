using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _3viknavinir.Models;

namespace _3viknavinir.Repo
{
	public class MediaRepo : IDisposable
	{
		private _3viknaContext db = new _3viknaContext();

		public void AddMedia(Media m)
		{
			db.Media.Add(m);
			db.SaveChanges();
		}

		public void UpdateMedia(Media newmedia)
		{
			int id = newmedia.Id;
			Media mediaToUpdate = (from media in db.Media
								   where media.Id == id
								   select media).SingleOrDefault();
			mediaToUpdate.title = newmedia.title;
			mediaToUpdate.yearOfRelease = newmedia.yearOfRelease;
			mediaToUpdate.description = newmedia.description;
			mediaToUpdate.categoryID = newmedia.categoryID;
			mediaToUpdate.posterPath = newmedia.posterPath;
			db.SaveChanges();
		}

		public IEnumerable<Media> GetAllMedia()
		{
			var allmedia = (from media in db.Media
							select media).ToList();
			return allmedia;
		}

        public IEnumerable<Media> GetMediaByCategoryID(int id)
        {
            var category = (from c in db.Media
                            where c.categoryID == id
                            select c).ToList();
            return category;
        }

		public Media GetMediaByID(int id)
		{
			var media = (from m in db.Media
						 where m.Id == id
						 select m).SingleOrDefault();
			return media;
		}

		public IEnumerable<Media> GetMediaByTitle(string title)
		{
			var media = from m in db.Media
						where m.title == title
						select m;
			return media;
		}

		// Erla
		public IEnumerable<Media> GetMediaLike(string titleLike)
		{
			var media = from m in db.Media
						where m.title.Contains(titleLike) || m.Category.name.Contains(titleLike) || m.imdbID.Contains(titleLike) || m.yearOfRelease.ToString().Contains(titleLike)
						select m;
			return media;
		}

		public int GetNextMediaID()
		{
			int id = ( from m in db.Media
					   select m.Id).Max();

			return id + 1;
		}
		
		public IEnumerable<Media> GetMediaByYear(string year)
		{
			int yearInt = Convert.ToInt32(year);
			var media = from m in db.Media
						where m.yearOfRelease == yearInt
						select m;
			return media;
		}

		public IEnumerable<Media> GetMediaByCategory(string category)
		{
			var media = from m in db.Media
						where m.Category.name.Contains(category)
						select m;
			return media;
		}

		
		// Grímur
		public void Dispose()
		{
			bool disposed = false;
			if (!disposed)
			{
				// TODO
				disposed = true;
			}
		}  
	}
}