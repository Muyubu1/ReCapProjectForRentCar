using Business.Concrete;
using Business.Abstarct;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using DataAccess.Concrete.EntityFramework;
namespace CarProject
{
    public class Program
    {
        static void Main(string[] args)
        {

            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var c in carManager.GetCarDetails())
            {
                Console.WriteLine(c.CarName+ " Marka==> " + c.BrandName+" Fiyat ==> "+c.DailyPrice+" Renk==>"+c.ColorName);

            }



        }
    }
}
