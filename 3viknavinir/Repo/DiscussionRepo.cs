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
	}
}


/*public class LanguageRepo : VERK014_H3Entities
    {
        private VERK014_H3Entities db = new VERK014_H3Entities( );

        public string GetLanguageByID(int id)
        {
            var language = (from l in db.Language
                            where l.Id == id
                            select l.name).FirstOrDefault();
            return language;
        }*/