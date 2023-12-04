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
    public class AboutManager : IAboutService
    {
        IAboutDAL _aboutDAL;

        public AboutManager(IAboutDAL aboutDAL)
        {
            _aboutDAL = aboutDAL;
        }

        public void AddT(About t)
        {
            _aboutDAL.Insert(t);

        }

        public void DeleteT(About t)
        {
            _aboutDAL.Delete(t);
        }

        public About GetById(int id)
        {
            return _aboutDAL.GetById(id);

        }

        public List<About> GetList()
        {
            return _aboutDAL.GetAll();
        }

        public void UpdateT(About t)
        {
            _aboutDAL.Update(t);
        }
    }
}
