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
	public class ContactManager : IContactService
	{
		IContactDAL _contactDAL;

		public ContactManager(IContactDAL contactDAL)
		{
			_contactDAL = contactDAL;
		}

		public void ContactAdd(Contact contact)
		{
			_contactDAL.Insert(contact);
		}
	}
}
