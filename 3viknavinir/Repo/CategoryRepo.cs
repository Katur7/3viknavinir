using _3viknavinir;
using _3viknavinir.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _3viknavinir.Repo
{
    public class CategoryRepo : IDisposable
	{
		private _3viknaContext db = new _3viknaContext();

		public IEnumerable<Category> GetAllCategories()
		{
			var all = db.Category.ToList();
			return all;
		}
		public Category GetCategoryByID(int id)
		{
			Category category = (from c in db.Category
							   where c.ID == id
							   select c).SingleOrDefault();
			return category;
		}
		public IEnumerable<Category> GetCategoryByName(string name)
		{
			IEnumerable<Category> category = (from c in db.Category
								 where c.name == name
								 select c).ToList();
			return category;
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