using _3viknavinir.Content;
using _3viknavinir.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _3viknavinir.Repo
{
	// Grímur
    public class CategoryRepo : VERK014_H3Entities1
	{
		private VERK014_H3Entities1 db = new VERK014_H3Entities1();

		public IEnumerable<Category> GetAllCategories()
		{
			var all = db.Category.ToList();
			return all;
		}
		public Category GetCategoryByID(int id)
		{
			Category category = (from c in db.Category
							   where c.Id == id
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
	}
}