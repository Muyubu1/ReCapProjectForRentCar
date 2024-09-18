using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IColourService
    {
        IDataResult<List<Colour>> GetAll();
        IDataResult<List<Colour>> GetByColorId(int id);
        IResult Add(Colour color);
        IResult Delete(Colour color);
        IResult Update(Colour color);
    }
}
