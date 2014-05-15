using _3viknavinir.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


// Steinunn - Not finished
namespace _3viknavinir.Repo
{
    public class TranslationLinesRepo : IDisposable
	{
		private _3viknaContext db = new _3viknaContext();

        public void AddOrUpdateTranslationLine( TranslationLines t )
        {
            var translationLinesToUpdate = (from tl in db.TranslationLines
                                            where tl.translationID == t.translationID
											where tl.chapterNumber == t.chapterNumber
                                            select tl ).FirstOrDefault( );
			if(translationLinesToUpdate != null)
			{
				translationLinesToUpdate.chapterNumber = t.chapterNumber;
				translationLinesToUpdate.startTime = t.startTime;
				translationLinesToUpdate.endTime = t.endTime;
				translationLinesToUpdate.subtitle = t.subtitle;
				translationLinesToUpdate.dateOfSubmission = t.dateOfSubmission;
				db.SaveChanges();
				return;
			} 
			else
			{
				db.TranslationLines.Add(t);
				db.SaveChanges();
				return;
			}
        }
        
        public IEnumerable<TranslationLines> GetTranslationLinesByTranslationID(int id)
        {
            var translationLine = from t in db.TranslationLines
							      where t.translationID == id
								  select t;

            return translationLine;
        }

        public void Dispose( )
        {
            bool disposed = false;
            if ( !disposed )
            {
                // TODO
                disposed = true;
            }
        }  
    }
}