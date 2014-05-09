using _3viknavinir.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _3viknavinir.Repo
{
	public class MediaRepo : VERK014_H3Entities
	{
		private VERK014_H3Entities db = new VERK014_H3Entities();

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

		
	}
}