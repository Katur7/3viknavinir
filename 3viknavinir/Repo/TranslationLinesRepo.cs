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

        public void addTranslationLine(TranslationLines t)
        {
            db.TranslationLines.Add(t);
            db.SaveChanges();
        }
        public void UpdateTranslationLine( TranslationLines t )
        {
            TranslationLines translationLinesToUpdate = ( from translationLine in db.TranslationLines
                                                where translationLine.Id == t.Id
                                                select translationLine ).SingleOrDefault( );
            translationLinesToUpdate.chapterNumber = t.chapterNumber;
            translationLinesToUpdate.startTime = t.startTime;
            translationLinesToUpdate.endTime = t.endTime;
            translationLinesToUpdate.subtitle = t.subtitle;
            translationLinesToUpdate.isEditing = t.isEditing;
            translationLinesToUpdate.dateOfSubmission = t.dateOfSubmission;
            translationLinesToUpdate.translationID = t.translationID;

            db.SaveChanges( );
        }
        public void RemoveTranslationLine(TranslationLines t)
        {
            db.TranslationLines.Remove(t);
            db.SaveChanges();
        }
        public TranslationLines GetTranslationLineByID(int id)
        {
            var translationLine = ( from t in db.TranslationLines 
                                    where t.Id == id
                                    select t).SingleOrDefault();

            return translationLine;
        }
        public TranslationLines GetTranslationLineByTranslationID(int id)
        {
            var translationLine = ( from t in db.TranslationLines
                                    where t.translationID == id
                                    select t).SingleOrDefault();

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