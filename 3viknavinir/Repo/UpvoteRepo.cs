using _3viknavinir;
using _3viknavinir.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _3viknavinir.Repo
{
	public class UpvoteRepo : IDisposable
	{
		private _3viknaContext db = new _3viknaContext();
		
		public IEnumerable<Upvote> GetUpvotesByTranslationID(int id)
		{
			var upvotes = from u in db.Upvote
						  where u.translationID == id
						  select u;
			return upvotes;
		}

		public IEnumerable<Upvote> GetUpvotesByRequestID(int id)
		{
			var upvotes = from u in db.Upvote
						  where u.requestID == id
						  select u;
			return upvotes;
		}

		public int CountUpvotesByRequestID(int id)
		{
			var upvotes = (from u in db.Upvote
						   where u.requestID == id
						   select u).Count();
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