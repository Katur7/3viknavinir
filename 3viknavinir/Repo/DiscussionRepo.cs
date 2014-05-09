using _3viknavinir.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _3viknavinir.Repo
{
    public class DiscussionRepo : VERK014_H3Entities
    {
        private VERK014_H3Entities db = new VERK014_H3Entities();

        public IEnumerable<string> GetCommentByMediaID(int mediaid)
        {
            var all = (from m in db.Discussion
                       where m.mediaID == mediaid
                       select m.comment).ToList();
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
                           where c.Id == id
                               select c).FirstOrDefault();
            return comment;
        }
    }
}

