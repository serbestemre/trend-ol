﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrendOl.BusinessLayer
{
	public class Test
	{
		public Test()
		{
			DataAccessLayer.DatabaseContext db = new DataAccessLayer.DatabaseContext();
			//db.Database.CreateIfNotExists();
			db.MyUsers.ToList();
		}
	}
}
