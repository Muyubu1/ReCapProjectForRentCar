using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult("Kullanıcı başarıyla eklendi.");
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult("Kullanıcı başarıyla silindi.");
        }

        public IDataResult<List<User>> GetAll()
        {
            var users = _userDal.GetAll();
            return new SuccessDataResult<List<User>>(users, "Kullanıcılar başarıyla listelendi.");
        }

        public IDataResult<User> GetById(int id)
        {
            var user = _userDal.Get(u => u.UserId == id);
            return user != null
                ? new SuccessDataResult<User>(user, "Kullanıcı başarıyla getirildi.")
                : new ErrorDataResult<User>("Kullanıcı bulunamadı.");
        }

        public IDataResult<User> GetByMail(string email)
        {
            var user = _userDal.Get(u => u.Email == email);
            return user != null
                ? new SuccessDataResult<User>(user, "Kullanıcı başarıyla bulundu.")
                : new ErrorDataResult<User>("Kullanıcı bulunamadı.");
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            var claims = _userDal.GetClaims(user);
            return new SuccessDataResult<List<OperationClaim>>(claims, "Kullanıcının yetkileri başarıyla getirildi.");
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult("Kullanıcı başarıyla güncellendi.");
        }
    }
}
