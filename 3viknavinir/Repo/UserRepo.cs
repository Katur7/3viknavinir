using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _3viknavinir.Content;
//Fanney
namespace _3viknavinir.Repo
{
    public class UserRepo
    {
        private VERK014_H3Entities db = new VERK014_H3Entities();

        public Users GetUserByID(int id)
        {
            var user = (from u in db.Users
                        where u.Id == id
                        select u).FirstOrDefault();
            return user;
        }
        public Users GetUserByName(string name)
        {
            var user = (from u in db.Users
                        where u.name == name
                        select u).FirstOrDefault();
            return user;
        }
        public IEnumerable<Users> GetAllUsers()
        {
            IEnumerable<Users> allUsers = (from u in db.Users
                                              select u);
            return allUsers;
                                               
        }
        public IEnumerable<string> GetAllEmails()
        {
            IEnumerable<string> allEmails = (from u in db.Users
                                             select u.email);
            return allEmails;
        }
        public void AddUser(Users U)
        {
            db.Users.Add(U);
            db.SaveChanges();
        }
        public void UpdateUser(Users newUser)
        {
            int id = newUser.Id;
            Users userToUpdate = (from u in db.Users
                                   where u.Id == id
                                   select u).SingleOrDefault();
            userToUpdate.name = newUser.name;
            userToUpdate.email = newUser.email;
            userToUpdate.userName = newUser.userName;
            userToUpdate.password = newUser.password;
            userToUpdate.isBannedUser = newUser.isBannedUser;
            userToUpdate.isAdmin = newUser.isAdmin;
            db.SaveChanges();
        }

    }	
}