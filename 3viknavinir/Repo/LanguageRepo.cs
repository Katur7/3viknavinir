using _3viknavinir.Content;
using _3viknavinir.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _3viknavinir.Repo
{
    public class LanguageRepo : VERK014_H3Entities
    {
        private VERK014_H3Entities db = new VERK014_H3Entities( );

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