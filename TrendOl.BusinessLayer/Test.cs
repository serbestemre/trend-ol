using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendOl.DataAccessLayer.EntityFramework;
using TrendOl.Entities;

namespace TrendOl.BusinessLayer
{
	public class Test
	{
		private  Repository<Category> repo = new Repository<Category>();
		private  Repository<Product> repoProduct = new Repository<Product>();
		private Repository<MyUser> repoUser = new Repository<MyUser>();
		private Repository<Comment> repoComment = new Repository<Comment>();
		public Test()
		{
			//DataAccessLayer.DatabaseContext db = new DataAccessLayer.DatabaseContext();
			//db.Database.CreateIfNotExists();
			//db.MyUsers.ToList();
			List<Category> categories = repo.List();
			List<Category> filteredCategories = repo.List(x => x.Id > 10);
		}

		public void InsertTest()
		{

			int result = repoUser.Insert(new MyUser()
			{
				Name = "TestName",
				Surname = "TestSurname",
				Email = "test@email.com",
				UserImage = "TestImage",
				ActivateGuid = Guid.NewGuid(),
				IsActive = true,
				IsSuperUser = false,
				HasBrand = true,
				Username = $"testUser",
				Password = "123"

			});
		}

		public void UpdateTest()
		{
			MyUser updatingUser = repoUser.Find(x => x.Username == "testUser");

			if(updatingUser != null)
			{
				updatingUser.Username = "TESTUSER";
				int result = repoUser.Update(updatingUser);
			}
		}

		public void DeleteTest()
		{

			MyUser deletingUser = repoUser.Find(x => x.Username == "testUser");

			repoUser.Delete(deletingUser);
		}

		public void CommentTest()
		{

			MyUser commentOwner = repoUser.Find(x => x.Id == 10);
			Product product = repoProduct.Find(x => x.Id == 30);

			Comment testComment = new Comment()
			{
				Owner = commentOwner,
				Product = product,
				Text = "it's a test comment for the product which's id is 30"

			};


			repoComment.Insert(testComment);
		}
	}
}
