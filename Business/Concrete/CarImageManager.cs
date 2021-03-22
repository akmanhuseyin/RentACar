using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Constants;
using Core.Utilities.Business;
using Core.Utilities.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

       //[ValidationAspect(typeof(CarImagesOperationDtoValidator))]
        public IResult Add(CarImagesOperationDto carImagesOperationDto)
        {
            var result = BusinessRules.Run(
                CheckCarImageCount(carImagesOperationDto.CarId));
            if (result != null)
            {
                return result;
            }

            foreach (var file in carImagesOperationDto.Images)
            {
                _carImageDal.Add(new CarImage
                {
                    CarId = carImagesOperationDto.CarId,
                    ImagePath = FileHelper.Upload(DefaultNameOrPath.ImageDirectory, file).Data
                });
            }

            return new SuccessResult(Messages.AddCarImageMessage);
        }

        public IResult Delete(CarImage entity)
        {
            var imageData = _carImageDal.Get(p => p.Id == entity.Id);
            FileHelper.Delete(imageData.ImagePath);
            _carImageDal.Delete(imageData);
            return new SuccessResult(Messages.DeleteCarImageMessage);
        }

        public IDataResult<CarImage> Get(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(p => p.Id == id));
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        //[ValidationAspect(typeof(CarImagesOperationDtoValidator))]
        public IResult Update(CarImagesOperationDto carImagesOperationDto)
        {
            foreach (var file in carImagesOperationDto.Images)
            {
                var result = BusinessRules.Run(
                    CheckIfCarImagesId(carImagesOperationDto.Id),
                    CheckCarImageCount(carImagesOperationDto.CarId)
                );
                if (result != null)
                {
                    return result;
                }

                FileHelper.Delete(_carImageDal.Get(p => p.Id == carImagesOperationDto.Id).ImagePath);
                _carImageDal.Update(new CarImage
                {
                    Id = carImagesOperationDto.Id,
                    CarId = carImagesOperationDto.CarId,
                    ImagePath = FileHelper.Upload(DefaultNameOrPath.ImageDirectory, file).Data
                });
            }

            return new SuccessResult(Messages.EditCarImageMessage);
        }

        public IDataResult<List<CarImage>> GetAllByCarId(int carId)
        {


            var getAllbyCarIdResult = _carImageDal.GetAll(p => p.CarId == carId);
            if (getAllbyCarIdResult.Count == 0)
            {
                return new SuccessDataResult<List<CarImage>>(new List<CarImage>
                {
                    new CarImage
                    {
                        Id = -1,
                        CarId = carId,
                        Date = DateTime.MinValue,
                        ImagePath = DefaultNameOrPath.NoImagePath
                    }
                });
            }

            return new SuccessDataResult<List<CarImage>>(getAllbyCarIdResult);
        }

        #region Car Image Business Rules

        private IResult CheckCarImageCount(int carId)
        {
            if (_carImageDal.GetAll(p => p.CarId == carId).Count > 4)
            {
                return new ErrorResult(Messages.AboveImageAddingLimit);
            }

            return new SuccessResult();
        }

        private IResult CheckIfCarImagesId(int Id)
        {
            if (_carImageDal.Get(p => p.Id == Id) == null)
            {
                return new ErrorResult(Messages.CarImageNotFound);
            }

            return new SuccessResult();
        }

        #endregion Car Image Business Rules

        //public IResult Add(IFormFile file, int carId)
        //{
        //    IResult result = BusinessRules.Run(CheckIfCarImagesLimitExceded(carId));

        //    if (result != null)
        //    {
        //        return result;
        //    }
        //    CarImage carImage = new CarImage();
        //    carImage.CarId = carId;
        //    carImage.ImagePath = FileHelper.Add(file);
        //    carImage.Date = DateTime.Now;
        //    _carImageDal.Add(carImage);

        //    return new SuccessResult();
        //}

        //[ValidationAspect(typeof(CarImageValidator))]
        //public IResult Update(IFormFile file, CarImage carImage)
        //{

        //    carImage.ImagePath = FileHelper.Update(_carImageDal.Get(p => p.Id == carImage.Id).ImagePath, file);
        //    carImage.Date = DateTime.Now;
        //    _carImageDal.Update(carImage);
        //    return new SuccessResult();

        //}

        //public IResult Delete(CarImage carImage)
        //{
        //    IResult result = BusinessRules.Run(CarImageDelete(carImage));

        //    if (result != null)
        //    {
        //        return result;
        //    }

        //    _carImageDal.Delete(carImage);
        //    return new SuccessResult();
        //}

        //public IDataResult<CarImage> Get(int id)
        //{
        //    return new SuccessDataResult<CarImage>(_carImageDal.Get(p => p.Id == id));
        //}

        //public IDataResult<List<CarImage>> GetAll()
        //{
        //    return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        //}

        //public IDataResult<List<CarImage>> GetImagesByCarId(int id)
        //{
        //    return new SuccessDataResult<List<CarImage>>(CheckIfCarImageNull(id));
        //}

        //private IResult CarImageDelete(CarImage carImage)
        //{
        //    try
        //    {
        //        FileHelper.Delete(carImage.ImagePath);
        //    }
        //    catch (Exception exception)
        //    {

        //        return new ErrorResult(exception.Message);
        //    }

        //    return new SuccessResult();
        //}

        //#region Business Rules Methods   
        //private IResult CheckIfCarImagesLimitExceded(int carId)
        //{
        //    var result = _carImageDal.GetAll(c => c.CarId == carId);
        //    if (result.Count >= 5)
        //    {
        //        return new ErrorResult(Messages.CarImageLimitExceded);
        //    }
        //    return new SuccessResult();
        //}

        //private List<CarImage> CheckIfCarImageNull(int id)
        //{
        //    string path = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).FullName + @"\UploadsCarImages\default.jpg");
        //    var result = _carImageDal.GetAll(c => c.CarId == id).Any();
        //    if (!result)
        //    {
        //        return new List<CarImage> { new CarImage { CarId = id, ImagePath = path, Date = DateTime.Now } };
        //    }
        //    return _carImageDal.GetAll(p => p.CarId == id);
        //}
        //#endregion

    }
}
