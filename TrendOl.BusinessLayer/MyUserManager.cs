using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendOl.DataAccessLayer.EntityFramework;
using TrendOl.Entities;
using TrendOl.Entities.ValueObjects;

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
					layerResult.Errors.Add(data.Username + " is already exist.");
				}
				if (user.Email == data.Email)
				{
					layerResult.Errors.Add(data.Email + " is using by another user.");
				}
			
			}
			else
			{
				int dbResult = repo_user.Insert(new MyUser()
				{
					Username = data.Username,
					Email = data.Email,
					Password = data.Password
				});
				if (dbResult > 0)
				{
					layerResult.Result = repo_user.Find(x => x.Email == data.Email && x.Username == data.Username);

					//TODO: send activation mail

				}

			}

				return layerResult;
			}


		}


	}

