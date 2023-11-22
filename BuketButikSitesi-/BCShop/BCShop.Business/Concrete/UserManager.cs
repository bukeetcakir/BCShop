using BCShop.Business.Abstract;
using BCShop.Data.Abstract;
using BCShop.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCShop.Business.Concrete
{
	public class UserManager : IUserService
	{
		IUserDAL _userDAL;

		public UserManager(IUserDAL userDAL)
		{
			_userDAL = userDAL;
		}

		public void UserAdd(User user)
		{
			_userDAL.Insert(user);
		}
	}
}
