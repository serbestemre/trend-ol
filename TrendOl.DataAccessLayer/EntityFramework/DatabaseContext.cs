using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendOl.Entities;

namespace TrendOl.DataAccessLayer.EntityFramework
{
	public class DatabaseContext : DbContext
	{
		public DatabaseContext(){

			Database.SetInitializer(new MyInitializer());

		}

		public DbSet<Brand> Brands { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Comment> Comments { get; set; }
		public DbSet<MyUser> MyUsers { get; set; }
		public DbSet<Product> Product { get; set; }
		public DbSet<Product_Image> ProductImages { get; set; }
		
		public DbSet<Like> Likes { get; set; }
		public DbSet<Sale> Sales { get; set; }
		public DbSet<Sale_Details> Sale_Details { get; set; }
		public DbSet<Wishlist> Wishlists { get; set; }

		public DbSet<Wishlist_Products> WishlistProduct { get; set; }

	}
}
