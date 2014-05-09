using _3viknavinir.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _3viknavinir.Repo
{
	public class MediaRepo : VERK014_H3Entities1
	{
		private VERK014_H3Entities1 db = new VERK014_H3Entities1();

		public void AddMedia(Media m)
		{
			db.Media.Add(m);
			db.SaveChanges();
		}

		public void UpdateMedia(Media m)
		{
			int id = m.Id;
			Media mediaToUpdate = (from media in db.Media
								   where media.Id == id
								   select media).SingleOrDefault();
			mediaToUpdate.title = m.title;
			mediaToUpdate.yearOfRelease = m.yearOfRelease;
			mediaToUpdate.description = m.description;
			mediaToUpdate.categoryID = m.categoryID;
			mediaToUpdate.posterPath = m.posterPath;
			db.SaveChanges();
		}

		
	}
}