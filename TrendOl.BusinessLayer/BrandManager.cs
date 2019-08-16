using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendOl.DataAccessLayer.EntityFramework;
using TrendOl.Entities;

namespace TrendOl.BusinessLayer
{
	public class BrandManager
	{
		private Repository<Brand> repo_brand = new Repository<Brand>();

		public List<Brand> GetBrands()
		{
			return repo_brand.List();
		}
	}
}
