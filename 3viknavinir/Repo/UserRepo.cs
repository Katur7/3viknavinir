using _3viknavinir.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _3viknavinir.Repo
{
	public class UserRepo : IDisposable
	{
		private _3viknaContext db = new _3viknaContext();

		public IEnumerable<IdentityUser> GetAllUsers()
		{
			return from user in db.Users select user;
		}

		public void Dispose()
		{
			db.Dispose();
		}
	}
}