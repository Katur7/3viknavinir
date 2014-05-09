using _3viknavinir;
using _3viknavinir.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _3viknavinir.Repo
{
	public class TranslationRepo : IDisposable
	{
		private _3viknaContext db = new _3viknaContext();

        public void AddTranslation( Translation t )
        {
            db.Translation.Add( t );
            db.SaveChanges( );
        }
        public void UpdateTranslation(Translation t)
        {
            Translation translationToUpdate = ( from translation in db.Translation
                                                where translation.Id == t.Id
                                                select translation ).SingleOrDefault( );
            translationToUpdate.userID = t.userID;
            translationToUpdate.languageID = t.languageID;
            translationToUpdate.mediaID = t.mediaID;
            translationToUpdate.finished = t.finished;
            db.SaveChanges( );
        }
        public void UpvoteTranslation(Translation t)
        {
            // TODO
        }
        public Translation GetTranslationByMediaID(int mediaid)
        {
            var translation = ( from t in db.Translation
                                where t.mediaID == mediaid
                                select t).SingleOrDefault();
            return translation;
        }
        public Translation GetTranslationByLanguageID(int languageID)
        {
            var translation = ( from t in db.Translation
                                where t.languageID == languageID
                                select t).SingleOrDefault();
            return translation;
        }
        public IEnumerable<Translation> GetAllTranslations()
        {
            var all = db.Translation.ToList( );
            return all;
        }
        
	}
}