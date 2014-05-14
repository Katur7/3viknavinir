using _3viknavinir;
using _3viknavinir.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// Grímur
namespace _3viknavinir.Repo
{
	public class UpvoteRepo : IDisposable
	{
		private _3viknaContext db = new _3viknaContext();
		/*
		public IEnumerable<Upvote> GetUpvotesByTranslationID(int translationId)
		{
		
			var upvotes = (from u in db.Upvote
						   where u.translationID == translationId
						   select u).ToList();
			return upvotes;
			
		}
	    */

		public IEnumerable<Upvote> GetUpvotesByTranslationID(int id)
		{
			var upvotes = from u in db.Upvote
						  where u.translationID == id
						  select u;
			return upvotes;
		}

		public void AddUpvote(Upvote u)
		{
			db.Upvote.Add(u);
			db.SaveChanges();
		}

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