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
        public string GetUserNameByID(string id)
        {
            var username = ( from u in db.Users
                             where u.Id == id
                             select u.UserName).SingleOrDefault();
            return username;
        }

		public IdentityUser GetUserByID(string id)
		{
			var allUsers = GetAllUsers();
			var user = (from u in allUsers
					   where u.Id == id
					   select u).SingleOrDefault();
			return user;
		}

		public void Dispose()
		{
			db.Dispose();
		}
	}
}