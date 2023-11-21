using BCShop.Data.Abstract;
using BCShop.Data.Repositories;
using BCShop.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCShop.Data.EntityFramework
{
	public class EFCommentRepository : GenericRepository<Comment>, ICommentDAL
	{
	}
}
