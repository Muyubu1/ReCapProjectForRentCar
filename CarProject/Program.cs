using Business.Concrete;
using Business.Abstarct;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
namespace CarProject
{
    internal class Program
    {
        static void Main(string[] args)
        {

            CarManager carManager = new CarManager(new InMemoryCarDal());

            //carManager.Delete(carManager.GetAll().SingleOrDefault(c => c.Id == 0));
            //carManager.Delete(carManager.GetAll().SingleOrDefault(c => c.Id == 1));

            //Car yeniCar = new Car()
            //{
            //    Id = 0,
            //    ColorId = 1,
            //    Description = "YENİLERDEN",
            //    BrandId = 3,
            //    DailyPrice = 1200000,
            //    ModelYear = "2024"
            //};
            //Car yeniCar2 = new Car()
            //{
            //    Id = 1,
            //    ColorId = 2,
            //    Description = "YENİ ENLENDİ SICAK SICAK",
            //    BrandId = 3,
            //    DailyPrice = 300000,
            //    ModelYear = "2018"
            //};
            //Car yeniCar3 = new Car()
            //{
            //    Id = 1,
            //    ColorId = 8,
            //    Description = "GUNCELLENDİ",
            //    BrandId = 0,
            //    DailyPrice = 3000000,
            //    ModelYear = "2025"
            //};

            //carManager.Add(yeniCar);
            //carManager.Add(yeniCar2);
            //carManager.Update(yeniCar3);


            foreach (var c in carManager.GetAll())
            {
                Console.WriteLine(c.Id + ": Nolu araç ==> " + c.Description+" Fiyat ==> "+c.DailyPrice);

            }



        }
    }
}
