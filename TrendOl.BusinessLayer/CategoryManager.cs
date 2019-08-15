using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendOl.DataAccessLayer.EntityFramework;
using TrendOl.Entities;

namespace TrendOl.BusinessLayer
{
	public class CategoryManager
	{

		private Repository<Category> repo_category = new Repository<Category>();

		public List<Category> GetCategories()
		{
			return repo_category.List();
		}

	}
}
