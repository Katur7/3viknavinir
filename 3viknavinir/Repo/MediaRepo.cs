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
			int id = newmedia.ID;
			Media mediaToUpdate = (from media in db.Media
								   where media.ID == id
								   select media).SingleOrDefault();
			mediaToUpdate.title = newmedia.title;
			mediaToUpdate.yearOfRelease = newmedia.yearOfRelease;
			mediaToUpdate.description = newmedia.description;
			mediaToUpdate.categoryID = newmedia.categoryID;
			mediaToUpdate.posterPath = newmedia.posterPath;
			mediaToUpdate.imdbID = newmedia.imdbID;
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
						 where m.ID == id
						 select m).SingleOrDefault();
			return media;
		}

		// Erla
		public IEnumerable<Media> GetMediaLike(string titleLike)
		{
			var media = (from m in db.Media
						 where m.title.Contains(titleLike) || m.Category.name.Contains(titleLike) || m.imdbID.Contains(titleLike) || m.yearOfRelease.ToString().Contains(titleLike)
						 select m).Distinct();
			return media.Distinct();
		}

		public bool IsExistingID(int mediaId)
		{
			var isExisting = (from m in db.Media
							   where m.ID == mediaId
							   select m).SingleOrDefault();
			return (isExisting != null);
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