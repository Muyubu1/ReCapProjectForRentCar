using DataAccess.Abstract;
using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        private List<Car> _cars;
        public InMemoryCarDal()
        {
            //yapay bir veri tabanından veri çekiyormuş gibi simule ediyoruz
            _cars = new List<Car>
            {
                new Car{Id=0,ColorId=0,BrandId=0,ModelYear="2000",DailyPrice=530000,Description="Bu arabadan bulunan özellikler yazılacak"},
                new Car{Id=1,ColorId=1,BrandId=2,ModelYear="2001",DailyPrice=540000,Description="Bu arabadan bulunan özellikler yazılacak"},
                new Car{Id=2,ColorId=2,BrandId=2,ModelYear="2002",DailyPrice=550000,Description="Bu arabadan bulunan özellikler yazılacak"},
                new Car{Id=3,ColorId=2,BrandId=3,ModelYear="2003",DailyPrice=560000,Description="Bu arabadan bulunan özellikler yazılacak"},
                new Car{Id=4,ColorId=1,BrandId=4,ModelYear="2004",DailyPrice=570000,Description="Bu arabadan bulunan özellikler yazılacak"},

            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
          Car carToDelete=_cars.SingleOrDefault(c=>c.Id==car.Id);
          _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAllByCategory(int CategoryId)
        {
            return _cars.Where(c=>c.ColorId==CategoryId).ToList();
        }

        public List<Car> GetAllByColor(int ColorId)
        {
            return _cars.Where(c=>c.ColorId==ColorId).ToList();
        }

        public Car GetById(int id)
        {
            return _cars.SingleOrDefault(c=>c.Id==id); 
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c=>c.Id==car.Id);
            if(carToUpdate!=null) {
                carToUpdate.ColorId=car.ColorId;
                carToUpdate.BrandId=car.BrandId;
                carToUpdate.ModelYear=car.ModelYear;
                carToUpdate.DailyPrice=car.DailyPrice;
                carToUpdate.Description=car.Description;
            }   
        }
    }
}
