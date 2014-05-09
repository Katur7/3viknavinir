using _3viknavinir;
using _3viknavinir.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _3viknavinir.Repo
{
    public class LanguageRepo
    {
		private _3viknaContext db = new _3viknaContext();

        public Language GetLanguageByID(int id)
        {
            var language = (from l in db.Language
                            where l.Id == id
                            select l).FirstOrDefault();
            return language;
        }
        public Language GetLanguageByName( string name )
        {
            var language = ( from l in db.Language
                             where l.name == name
                             select l ).FirstOrDefault();
            return language;
        }
        public IEnumerable<Language> GetAllLanguages()
        {
            var all = db.Language.ToList( );
            return all;
        }

        
    }
}