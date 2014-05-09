using _3viknavinir.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _3viknavinir.Repo
{
	public class RequestRepo
	{
		private VERK014_H3Entities db = new VERK014_H3Entities();
		
		public string GetRequestByID(int id)
		{
			var request = (from r in db.Requests 
							where r.Id == id
							select r.title).FirstOrDefault();
			return request;
		}

		public string GetRequestByName(string name)
		{
			var request = (from r in db.Requests
						   where r.title == name
						   select r.title).FirstOrDefault();
			return request;
		}
	}
}