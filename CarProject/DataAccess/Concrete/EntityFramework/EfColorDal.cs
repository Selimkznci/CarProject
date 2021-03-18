using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfColorDal : EfEntityRepositoryBase<Color, MyDatabaseContext>, IColorDal
    {
        public List<Color> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}
