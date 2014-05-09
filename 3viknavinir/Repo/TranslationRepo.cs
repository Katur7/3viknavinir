using _3viknavinir.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _3viknavinir.Repo
{
	public class TranslationRepo
	{
        private VERK014_H3Entities db = new VERK014_H3Entities( );

        public void AddTranslation( Translation t )
        {
            db.Translation.Add( t );
            db.SaveChanges( );
        }
        public void UpdateTranslation(int id)
        {
            
        }
        public void UpvoteTranslation(int id)
        {
        
        }
        public Translation GetTranslationByMediaID(int mediaid)
        {
            var translation = ( from m in db.Translation
                                where m.mediaID == mediaid
                                select m).SingleOrDefault();
            return translation;
        }
        public IEnumerable<Translation> GetAllTranslations()
        {
            var all = db.Translation.ToList( );
            return all;
        }
        //public Translation GetTranslationByName(string name)
        //{

        //}
	}
}