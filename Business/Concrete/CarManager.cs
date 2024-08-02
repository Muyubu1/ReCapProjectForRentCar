using Business.Abstarct;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            _carDal.Add(car);
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetAllByCategory(int CategoryId)
        {
           return _carDal.GetAllByCategory(CategoryId);
        }

        public List<Car> GetAllByColor(int ColorId)
        {
            return _carDal.GetAllByColor(ColorId);
        }

        public Car GetById(int id)
        {
            return _carDal.GetById(id);

        }

        public void Update(Car car)
        {
           _carDal.Update(car);
        }
    }
}
