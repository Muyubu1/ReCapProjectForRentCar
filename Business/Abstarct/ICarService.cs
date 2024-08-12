using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstarct
{
    public interface ICarService
    {
        List<Car>GetAll();
        
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);

        List<Car>GetCarsByBrandId(int BrandId);
        List<Car> GetCarsByColorId(int ColorId);
        Car GetByCarId(int id);
        List<CarDetailDto> GetCarDetails();


    }
}
