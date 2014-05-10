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