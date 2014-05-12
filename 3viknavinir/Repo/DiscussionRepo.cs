using _3viknavinir;
using _3viknavinir.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _3viknavinir.Repo
{
    //Svava
    public class DiscussionRepo : IDisposable
    {
        private _3viknaContext db = new _3viknaContext();

        public IEnumerable<Discussion> GetCommentByMediaID(int mediaid)
        {
            var all = (from m in db.Discussion
                       where m.mediaID == mediaid
                       select m).ToList();
            return all;
        }
        public void AddComment(Discussion c)
        {
            db.Discussion.Add(c);
            db.SaveChanges();
        }
        public Discussion GetCommentByID(int id)
        {
            var comment = (from c in db.Discussion
                           where c.ID == id
                               select c).FirstOrDefault();
            return comment;
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

