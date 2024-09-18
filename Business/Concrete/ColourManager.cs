using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ColourManager : IColourService
    {
        IColourDal _ColorDal;
        public ColourManager(IColourDal colorDal)
        {
            _ColorDal = colorDal;
        }
        [ValidationAspect(typeof(ColourValidator))]
        public IResult Add(Colour color)
        {
            IResult result = BusinessRules.Run(CheckIfColorNameExist(color.ColourName));
            if (result != null)
            {
                return new ErrorResult(Messages.ColorNotAdded);
            }
            _ColorDal.Add(color);
            return new SuccessResult(Messages.ColorAdded);
        }

        public IResult Delete(Colour color)
        {
            _ColorDal.Delete(color);
            return new SuccessResult();
        }
        [ValidationAspect(typeof(ColourValidator))]
        public IResult Update(Colour color)
        {
            _ColorDal.Update(color);
            return new SuccessResult();
        }

        public IDataResult<List<Colour>> GetAll()
        {
            return new SuccessDataResult<List<Colour>>(_ColorDal.GetAll());
        }





        private IResult CheckIfColorNameExist(string colorName)
        {
            var result = _ColorDal.GetAll(c => c.ColourName == colorName).Any();
            if (result)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
        private IResult CheckColorExist(int colorId)
        {
            var result = _ColorDal.GetAll(c => c.ColourId == colorId).Any();
            if (!result)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        public IDataResult<List<Colour>> GetByColorId(int colorId)
        {
            return new SuccessDataResult<List<Colour>>(_ColorDal.GetAll(c => c.ColourId == colorId));

        }


    }
}