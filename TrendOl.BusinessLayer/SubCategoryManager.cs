using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendOl.DataAccessLayer.EntityFramework;
using TrendOl.Entities;

namespace TrendOl.BusinessLayer
{
	public class SubCategoryManager
	{
		private Repository<SubCategory> repo_subCategory = new Repository<SubCategory>();

		public List<SubCategory> GetSubCategories(int mainCatId)
		{

			return repo_subCategory.List().Where(x => x.Category.Id == mainCatId).ToList();
		}

		public SubCategory GetSubCategoryById(int subCatId)
		{
			return repo_subCategory.Find(x => x.Id == subCatId);
		}

	}


}
