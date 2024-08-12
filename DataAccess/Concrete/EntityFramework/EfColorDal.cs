using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    //aynı anda hem interface hemde base class kullanacağız buda kodu daha kompak bir hale getirecek..
    public class EfColorDal : EfEntityRepositoryBase<Entities.Concrete.Color, CarValueContext>, IColorDal
    {
        

       
    }
}
