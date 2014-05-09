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
	}
}