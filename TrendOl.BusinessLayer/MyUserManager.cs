using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendOl.DataAccessLayer.EntityFramework;
using TrendOl.Entities;
using TrendOl.Entities.ValueObjects;
using TrendOl.Entities.Messages;

namespace TrendOl.BusinessLayer
{
	public class MyUserManager
	{

		private Repository<MyUser> repo_user = new Repository<MyUser>();
		

		public BusinessLayerResult<MyUser> RegisterUser(RegisterViewModel data)
		{
			MyUser user = repo_user.Find(x => x.Username == data.Username || x.Email == data.Email);
			BusinessLayerResult<MyUser> layerResult = new BusinessLayerResult<MyUser>();

			if (user != null)
			{
				if (user.Username == data.Username)
				{
					layerResult.AddError(ErrorMessageCode.UsernameAlreadyExist, "Username is already exist.");
				}
				if (user.Email == data.Email)
				{
					layerResult.AddError(ErrorMessageCode.EmailAlreadyExist, "Email is using by another user.");
				}
			
			}
			else
			{
				int dbResult = repo_user.Insert(new MyUser()
				{
					Username = data.Username,
					Email = data.Email,
					Password = data.Password,
					IsActive =false,
					IsSuperUser=false,
					HasBrand = false,
					Name = "username",
					Surname = "surname",
					ActivateGuid = Guid.NewGuid(),
					
				
				});
				if (dbResult > 0)
				{
					layerResult.Result = repo_user.Find(x => x.Email == data.Email && x.Username == data.Username);

					//TODO: send activation mail

				}

			}

				return layerResult;
			}

		public BusinessLayerResult<MyUser> LoginUser(LoginViewModel data)
		{
			BusinessLayerResult<MyUser> result = new BusinessLayerResult<MyUser>();
			result.Result = repo_user.Find(x => x.Username == data.Username && x.Password == data.Password);

			if(result.Result != null)
			{
				if (!result.Result.IsActive)
				{
					result.AddError(ErrorMessageCode.EmailAlreadyExist, "The user is not activated. Please check your e - mail account.");
				}
			}
			else
			{
				result.AddError(ErrorMessageCode.UsernameOrPassWrong, "Incorrect Username or Password.");
			}
			return result;
		}


		}


	}

