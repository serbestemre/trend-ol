using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendOl.DataAccessLayer.EntityFramework;
using TrendOl.Entities;
using TrendOl.Entities.ValueObjects;
using TrendOl.Entities.Messages;
using TrendOl.Common.Helpers;

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
			{ // Create User Obj and Insert into DB
				int dbResult = repo_user.Insert(new MyUser()
				{
					Username = data.Username,
					Email = data.Email,
					Password = data.Password,
					IsActive =false,
					IsSuperUser=false,
					HasBrand = false,
					Name = "name",
					Surname = "surname",
					UserImage = "default_user_avatar.png",
					ActivateGuid = Guid.NewGuid(),
					
				
				});
				if (dbResult > 0)
				{
					layerResult.Result = repo_user.Find(x => x.Email == data.Email && x.Username == data.Username);

					//TODO: send activation mail
					string siteUri = ConfigHelper.Get<string>("SiteRootUri");
					string activateUri = $"{siteUri}/Home/UserActivate/{layerResult.Result.ActivateGuid}";
					string body = $"Hello {layerResult.Result.Username};<br><br>" +
						$"Activate your account by clicking <a href='{activateUri}' target='_blank'>here</a>.";
					MailHelper.SendMail(body, layerResult.Result.Email, "TrendOl Account Activation Code");


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

		public BusinessLayerResult<MyUser> ActivateUser(Guid activateId)
		{
			BusinessLayerResult<MyUser> result = new BusinessLayerResult<MyUser>();
			result.Result = repo_user.Find(x => x.ActivateGuid == activateId);

			if(result.Result != null)
			{
				if (result.Result.IsActive)
				{
					result.AddError(ErrorMessageCode.UserAlreadyActive, "The user is already activated.");
					return result;
				}

				result.Result.IsActive = true;
				repo_user.Update(result.Result);

				return result;

			}
			else
			{
				result.AddError(ErrorMessageCode.ActivateIdDoesNotExist, "Ooops!! The user could not found!  ");

			}
			return result;
		}

		public BusinessLayerResult<MyUser> GetUserById(int Id)
		{
			BusinessLayerResult<MyUser> res = new BusinessLayerResult<MyUser>();
			res.Result = repo_user.Find(x => x.Id == Id);

			if(res.Result == null)
			{
				res.AddError(ErrorMessageCode.UserNotFound, "User not found!");
			}
			return res;
			
		}

		public BusinessLayerResult<MyUser> UpdateProfile(MyUser data)
		{
			MyUser db_user = repo_user.Find(x => x.Id != data.Id && (x.Username == data.Username || x.Email == data.Email));
			BusinessLayerResult<MyUser> res = new BusinessLayerResult<MyUser>();

			if(db_user != null && db_user.Id != data.Id)
			{
				if(db_user.Username == data.Username)
				{
					res.AddError(ErrorMessageCode.UsernameAlreadyExist, "Username is already Exists");
				}
				if(db_user.Email == data.Email)
				{
					res.AddError(ErrorMessageCode.EmailAlreadyExist, "E-mail is already exists");
				}
				return res;
			}

			res.Result = repo_user.Find(x => x.Id == data.Id);
			res.Result.Name = data.Name;
			res.Result.Surname = data.Surname;
			res.Result.Email = data.Email;
			res.Result.Password = data.Password;
			res.Result.Username = data.Username;
			res.Result.Gender = data.Gender;
			res.Result.Address = data.Address;

			if (string.IsNullOrEmpty(data.UserImage) == false)
			{
				res.Result.UserImage = data.UserImage;
			}

			if(repo_user.Update(res.Result)==0){
				res.AddError(ErrorMessageCode.ProfileCouldNotUpdated, "Profile could not updated.");
			}

			return res;

			
		}

		public BusinessLayerResult<MyUser> DeleteUserById(int Id)
		{

			MyUser db_user = repo_user.Find(x => x.Id == Id);
			BusinessLayerResult<MyUser> res = new BusinessLayerResult<MyUser>();

			if(db_user != null)
			{
				if (repo_user.Delete(db_user) == 0)
				{
					res.AddError(ErrorMessageCode.UserCouldNotRemoved, "The user could not removed!");
					return res;
				}

			}
			else
			{
				res.AddError(ErrorMessageCode.UserNotFound, "User could not found!");
			}
				return res;
		}
	}


	}

