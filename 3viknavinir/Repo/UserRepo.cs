using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _3viknavinir.Content;
//Fanney
namespace _3viknavinir.Repo
{	public class UserRepo
	{
    private VERK014_H3Entities db = new VERK014_H3Entities();

    public UserRepo GetUserByID(int id)
    {
        var user = ( from u in db.Users
                        where u.id == id
                        select u).FirstOrDefault();
        return user;
    }
    public UserRepo GetUserByName(string name)
    {
        var user = ( from u in db.Users
                    where u.name == name
                    select u).FirstOrDefault();
        return user;
    }

	}
}