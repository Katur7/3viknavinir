using _3viknavinir.Content;
using _3viknavinir.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _3viknavinir.Repo
{
    public class CategoryRepo : VERK014_H3Entities
	{
		private VERK014_H3Entities db = new VERK014_H3Entities();

		public IEnumerable<Category> GetAllCategories()
		{
			var all = db.Category.ToList();
			return all;
		}
        //public string GetCategoryByID( int id )
        //{
            
        //}
        //public string GetCategoryByName( string name )
        //{

        //}
	}
}