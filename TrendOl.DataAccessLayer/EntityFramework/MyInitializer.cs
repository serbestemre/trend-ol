using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using TrendOl.Entities;

namespace TrendOl.DataAccessLayer.EntityFramework
{
	class MyInitializer : CreateDatabaseIfNotExists<DatabaseContext>
	{
		protected override void Seed(DatabaseContext context)
		{
			List<Brand> brandList = new List<Brand>();
			List<MyUser> brandUsers = new List<MyUser>();
			List<Product> productList = new List<Product>();


			//Only one super user is creating
			MyUser SuperUser = new MyUser()
			{
				Name = "Emre",
				Surname = "Serbest",
				ActivateGuid = Guid.NewGuid(),
				Email = "eserbest1903@gmail.com",
				Address = FakeData.PlaceData.GetAddress(),
				Gender = "Male",
				IsActive = true,
				IsSuperUser = true,
				HasBrand = false,
				Username = "eserbest",
				Password = "123456",
				UserImage = FakeData.NetworkData.GetDomain(),
				CreatedOn = DateTime.Now,
				ModifiedOn = DateTime.Now,
				ModifiedUsername = "system",

			};

			context.MyUsers.Add(SuperUser);
			context.SaveChanges();


			//Creating 7 Admins (Brand Users)
			for (int i = 0; i < 7; i++)
			{
				MyUser BrandUser = new MyUser()
				{
					Name = FakeData.NameData.GetFirstName(),
					Surname = FakeData.NameData.GetSurname(),
					Email = FakeData.NetworkData.GetEmail(),
					Address = FakeData.PlaceData.GetAddress(),
					Gender = FakeData.BooleanData.GetBoolean() ? "Male" : "Female",
					UserImage = FakeData.NetworkData.GetDomain(),
					ActivateGuid = Guid.NewGuid(),
					IsActive = true,
					IsSuperUser = false,
					HasBrand = true,
					Username = $"brandUser{i}",
					Password = "b1234567",
					CreatedOn = DateTime.Now,
					ModifiedOn = DateTime.Now,
					ModifiedUsername = "system",
				};
				brandUsers.Add(BrandUser);
				context.MyUsers.Add(BrandUser);
			}
				context.SaveChanges();


			//List<MyUser> users = context.MyUsers.ToList();
			//Creating a Brand for the current BrandUser
			foreach (MyUser item in brandUsers)
			{
				Brand newBrand = new Brand()
				{
					BrandName = FakeData.NameData.GetCompanyName(),
					BrandImage = "BrandImage.jpg",
					Tag = FakeData.TextData.GetSentence(),
					MyUser = item,
					CreatedOn = DateTime.Now,
					ModifiedOn = DateTime.Now,
					ModifiedUsername = "system",
				};
				brandList.Add(newBrand);
				context.Brands.Add(newBrand);

			}
			context.SaveChanges();

		

			


			List<string> sizeList = new List<string>();
			sizeList.Add("XS");
			sizeList.Add("S");
			sizeList.Add("M");
			sizeList.Add("L");
			sizeList.Add("XL");
			sizeList.Add("XXL");

			List<string> colorList = new List<string>();
			colorList.Add("black");
			colorList.Add("white");
			colorList.Add("pink");
			colorList.Add("green");
			colorList.Add("red");

			// Creating Categories MEN, WOMEN, KidsAndBabies

			Category Men = new Category()
			{
				Title = "Men",
				Description = "Only for men shopping items",
				CreatedOn = DateTime.Now,
				ModifiedOn = DateTime.Now,
				ModifiedUsername = "system",
			};
			context.Categories.Add(Men);

			Category Women = new Category()
			{
				Title = "Women",
				Description = "Only for women shopping items",
				CreatedOn = DateTime.Now,
				ModifiedOn = DateTime.Now,
				ModifiedUsername = "system",
			};
			context.Categories.Add(Women);

			Category KidsAndBabies = new Category()
			{
				Title = "Kids & Babies",
				Description = "Kids and Babies shopping items",
				CreatedOn = DateTime.Now,
				ModifiedOn = DateTime.Now,
				ModifiedUsername = "system",
			};
			context.Categories.Add(KidsAndBabies);
			context.SaveChanges();
			List<Category> mainCategories = new List<Category>();
			List<SubCategory> MenSubCategories = new List<SubCategory>();
			List<SubCategory> WomenSubCategories = new List<SubCategory>();
			List<SubCategory> KidsAndBabiesSubCategories = new List<SubCategory>();

			List<string> MenCatNames = new List<string>()
			{
				"Hoodies",
				"Jackets",
				"T-shirts",
				"Shirts",
				"Socks",
				"Jeans",
				"Casual Pants",
				"Cargo Pants",
				"Suits",
				"Boxers",
				"Men's Sleep Lounge",
				"Accessories",
			};

			List<string> WomenCatNames = new List<string>()
			{
				"Dress",
				"Blouses",
				"T-shirts",
				"Beach Style",
				"Skirts",
				"Shorts",
				"Jean",
				"Blazers",
				"Bra",
				"Sleep Lounge",
				"Accessories",
			};

			List<string> KidsCatNames = new List<string>()
			{
				"Dresses",
				"Clothing Sets",
				"Family Matching Clothes",
				"Shoes",
				"Swim Suits",
				"Shorts",
				"Baby Mother",
				"Toys",
			};

			foreach (string subCat in MenCatNames)
			{
				SubCategory subCatMen = new SubCategory()
				{
					Title = subCat,
					Description = "Men Shopping",
					Category = Men,
					CreatedOn = DateTime.Now,
					ModifiedOn = DateTime.Now,
					ModifiedUsername = "system",
				};

				MenSubCategories.Add(subCatMen);
				context.SubCategories.Add(subCatMen);
			}

			foreach (string subCat in WomenCatNames)
			{
				SubCategory subCatWomen = new SubCategory()
				{
					Title = subCat,
					Description = "Women Shopping",
					Category = Women,
					CreatedOn = DateTime.Now,
					ModifiedOn = DateTime.Now,
					ModifiedUsername = "system",
				};

				WomenSubCategories.Add(subCatWomen);
				context.SubCategories.Add(subCatWomen);
			}

			foreach (string subCat in KidsCatNames)
			{
				SubCategory subCatKidsAndBabies = new SubCategory()
				{
					Title = subCat,
					Description = "Kids & Babies Shopping",
					Category = KidsAndBabies,
					CreatedOn = DateTime.Now,
					ModifiedOn = DateTime.Now,
					ModifiedUsername = "system",
				};

				KidsAndBabiesSubCategories.Add(subCatKidsAndBabies);
				context.SubCategories.Add(subCatKidsAndBabies);
			}

			context.SaveChanges();

			mainCategories.Add(Men);
			mainCategories.Add(Women);
			mainCategories.Add(KidsAndBabies);
			

			//Creating 50 products
			for (int j=0; j<50; j++)
			{
				Category randomCat = mainCategories[FakeData.NumberData.GetNumber(0, mainCategories.Count - 1)];
				SubCategory randomSubCat;
				if (randomCat == Men)
				{
					randomSubCat = MenSubCategories[FakeData.NumberData.GetNumber(0, MenSubCategories.Count - 1)];
				} else if (randomCat == Women)
				{
					randomSubCat = WomenSubCategories[FakeData.NumberData.GetNumber(0, WomenSubCategories.Count - 1)];
				}
				else
				{
					randomSubCat = KidsAndBabiesSubCategories[FakeData.NumberData.GetNumber(0, KidsAndBabiesSubCategories.Count - 1)];
				}

				Product newProduct = new Product()
				{
					ProductName = FakeData.NameData.GetCompanyName(),
					ProductDescription = FakeData.TextData.GetSentence(),
					Brand = brandList[(FakeData.NumberData.GetNumber(0, brandList.Count - 1))],
					Size = sizeList[(FakeData.NumberData.GetNumber(0, sizeList.Count - 1))],
					Color = colorList[(FakeData.NumberData.GetNumber(0, colorList.Count - 1))],
					Stock = FakeData.NumberData.GetNumber(10, 100),
					Price = FakeData.NumberData.GetNumber(15,150),
					DiscountPercentage = FakeData.NumberData.GetNumber(0, 10),
					Category = randomCat,
					SubCategory = randomSubCat,
					CreatedOn = DateTime.Now,
					ModifiedOn = DateTime.Now,
					ModifiedUsername = "system",

				};

				productList.Add(newProduct);
				context.Product.Add(newProduct);

			}
			context.SaveChanges();


			List<MyUser> standartUserList = new List<MyUser>();

			for (int s = 0; s < 10; s++)
			{
				MyUser standartUser = new MyUser()
				{
					Name = FakeData.NameData.GetFirstName(),
					Surname = FakeData.NameData.GetSurname(),
					Email = FakeData.NetworkData.GetEmail(),
					Address = FakeData.PlaceData.GetAddress(),
					Gender = FakeData.BooleanData.GetBoolean() ? "Male" : "Female",
					UserImage = FakeData.NetworkData.GetDomain(),
					ActivateGuid = Guid.NewGuid(),
					IsActive = true,
					IsSuperUser = false,
					HasBrand = false,
					Username = $"standartUser{s}",
					Password = "standart1234",
					CreatedOn = DateTime.Now,
					ModifiedOn = DateTime.Now,
					ModifiedUsername = "system",
				};
				standartUserList.Add(standartUser);
				context.MyUsers.Add(standartUser);
				context.SaveChanges();

				//Creating Wishlist for standartusers randomly.
				if (FakeData.BooleanData.GetBoolean())
				{
					Wishlist wishlist = new Wishlist()
					{
						IsPublic = FakeData.BooleanData.GetBoolean(),
						Title = FakeData.BooleanData.GetBoolean() ? "Specialized-WishList-Title" : "WishList",
						MyUser = standartUser,
					};
					context.Wishlists.Add(wishlist);
					
					//Adding products to the wishlist randomly
					for (int i = 0; i < FakeData.NumberData.GetNumber(3,10); i++)
					{
						Wishlist_Products wishlist_products = new Wishlist_Products()
						{
							Product = productList[FakeData.NumberData.GetNumber(0,45)],
							Wishlist = wishlist
						};
						context.WishlistProduct.Add(wishlist_products);

					}
				}

				//Creating Sale for standart users randomly
				if (FakeData.BooleanData.GetBoolean())
				{

					for (int salecounter = 0; salecounter < FakeData.NumberData.GetNumber(3,20); salecounter++)
					{
						double totalPrice = 0;

						Sale_Details saleDetail = new Sale_Details()
						{ };

						Sale sale = new Sale()
						{ };
						for (int saleDetailCounter = 0; saleDetailCounter < FakeData.NumberData.GetNumber(2,8); saleDetailCounter++)
						{
							Product soldProduct = productList[FakeData.NumberData.GetNumber(0, 49)];
							int tempQuantity = FakeData.NumberData.GetNumber(1, 4);
							double tempSubTotal = soldProduct.Price * tempQuantity;
							totalPrice += tempSubTotal;


							saleDetail.Quantity = tempQuantity;
							saleDetail.Product = soldProduct;
							saleDetail.InstantPrice = soldProduct.Price;
							saleDetail.SubTotal = tempSubTotal;
							saleDetail.Sale = sale;
							

							context.Sale_Details.Add(saleDetail);
							
						}


						sale.Customer = standartUser;
						sale.Date = FakeData.DateTimeData.GetDatetime();
						sale.Time = FakeData.DateTimeData.GetDatetime();
						sale.TotalPrice = totalPrice;
						sale.TotalVat = 18;
						
						

						context.Sales.Add(sale);
					}

				}	


			}

			context.SaveChanges();

			

			//Adding product images
			foreach (Product itemProduct in productList)
			{
				for (int i = 0; i < FakeData.NumberData.GetNumber(3,7); i++)
				{
					Product_Image productImage = new Product_Image()
					{
						Url = $"picture{i}.jpg",
						Product = itemProduct,
					};
					context.ProductImages.Add(productImage);


					MyUser owner = standartUserList[FakeData.NumberData.GetNumber(0, standartUserList.Count - 1)];
					//Adding comments
					Comment newComment = new Comment()
					{
						Text = FakeData.TextData.GetSentences(FakeData.NumberData.GetNumber(1, 3)),
						Owner = owner,
						Product = itemProduct,
						CreatedOn = DateTime.Now,
						ModifiedOn = DateTime.Now,
						ModifiedUsername = owner.Username,
					};
					context.Comments.Add(newComment);


					//Creating likes
					Rate Rate = new Rate()
					{
						RateOwner = standartUserList[FakeData.NumberData.GetNumber(0, standartUserList.Count - 1)],
						Product = itemProduct,

					};
					context.Rates.Add(Rate);
				}
			}
			context.SaveChanges();	

		}

	}
}
