using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendOl.DataAccessLayer.EntityFramework;
using TrendOl.Entities;

namespace TrendOl.BusinessLayer
{
public class ProductManager
	{

		private Repository<Product> repo_product = new Repository<Product>();


		public List<Product> GetAllProducts()
		{
			return repo_product.List();
		}

		public IQueryable<Product> GetAllProductsQueryable()
		{
			return repo_product.ListQueryable();
		}
	}

}
