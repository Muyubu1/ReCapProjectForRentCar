using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private readonly ICarImageDal _carImageDal;
        private readonly IFileHelperService _fileHelperService;

        public CarImageManager(ICarImageDal carImageDal, IFileHelperService fileHelperService)
        {
            _carImageDal = carImageDal;
            _fileHelperService = fileHelperService;
        }

        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(GetCheckCarImageLimit(carImage.CarImageId));
            if (result != null)
            {
                return result;
            }

            if (file.Length > 0)
            {
                var fileName = _fileHelperService.Upload(file, "root/images");

                if (fileName == null)
                {
                    return new ErrorResult(Messages.FileUploadError);
                }

                carImage.ImagePath = fileName;
                _carImageDal.Add(carImage);
                return new SuccessResult(Messages.ImageAdded);
            }
            return new ErrorResult(Messages.InvalidFile);
        }

        public IResult Delete(CarImage carImage)
        {
            var filePath = Path.Combine("root/images", carImage.ImagePath);
            _fileHelperService.Delete(filePath);

            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.ImageDeleted);
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            if (file.Length > 0)
            {
                var oldCarImage = _carImageDal.Get(c => c.CarImageId == carImage.CarImageId);
                if (oldCarImage != null)
                {
                    var oldFilePath = Path.Combine("root/images", oldCarImage.ImagePath);
                    _fileHelperService.Delete(oldFilePath);
                }

                var fileName = _fileHelperService.Upload(file, "root/images");
                if (fileName == null)
                {
                    return new ErrorResult(Messages.FileUploadError);
                }

                carImage.ImagePath = fileName;
                _carImageDal.Update(carImage);
                return new SuccessResult(Messages.ImageUpdated);
            }
            return new ErrorResult(Messages.InvalidFile);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            var carImages = _carImageDal.GetAll(c => c.CarId == carId);

            // Eğer araba için resim yoksa, varsayılan resmi ekleyin
            if (carImages == null || carImages.Count == 0)
            {
                // Varsayılan resmi listeye ekleyelim
                carImages = new List<CarImage>
        {
            new CarImage
            {
                CarId = carId,
                ImagePath = "root/defaultImage.png", // Varsayılan resim yolu
                Date = DateTime.Now
            }
        };
            }

            return new SuccessDataResult<List<CarImage>>(carImages);
        }

        public IDataResult<CarImage> GetById(int carImageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.CarImageId == carImageId));
        }

        private IResult GetCheckCarImageLimit(int carId)
        {
            var result = _carImageDal.GetAll(i => i.CarId == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult(Messages.CarImageLimitReached);
            }
            return new SuccessResult();
        }
    }
}