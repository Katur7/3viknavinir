﻿using _3viknavinir;
using _3viknavinir.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _3viknavinir.Repo
{
	public class RequestRepo
	{
		private _3viknaContext db = new _3viknaContext();
		
		public Requests GetRequestByID(int id)
		{
			var request = (from r in db.Requests 
							where r.Id == id
							select r).FirstOrDefault();
			return request;
		}

		public Requests GetRequestByName(string name)
		{
			var request = (from r in db.Requests
						   where r.title == name
						   select r).FirstOrDefault();
			return request;
		}

		public Requests GetRequestByIMDBID(string imdbid)
		{
			var request = (from r in db.Requests
						   where r.imdbID == imdbid
						   select r).FirstOrDefault();
			return request;
		}

		public IEnumerable<Requests> GetAllRequests()
		{
			IEnumerable<Requests> allRequests = (from r in db.Requests
												select r);
			return allRequests;
		}

		public void AddRequest(Requests r)
		{
			db.Requests.Add(r);
			db.SaveChanges();
		}

		public void UpvoteRequest(int id, string userId)
		{
			var upvote = (from u in db.Upvote
						  where u.Id == id
						  select u).SingleOrDefault();
			//vantar id
			upvote.userID = userId;
			upvote.requestID = id;
			upvote.translationID = null;
			upvote.discussionID = null;
		}
	}
}