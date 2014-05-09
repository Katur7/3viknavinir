﻿using _3viknavinir.Content;
using _3viknavinir.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _3viknavinir.Repo
{
    public class CategoryRepo : VERK014_H3Entities
	{
		private ApplicationDbContext db = new ApplicationDbContext();

		public IEnumerable<Category> GetAllCategories()
		{
			var all = from c in db.Categories
					  select c;
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