﻿using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
//using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetById(int id);
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);

        IDataResult<User> GetByMail(string email); // Email ile kullanıcıyı bulmak için
        IDataResult<List<OperationClaim>> GetClaims(User user); // Kullanıcının yetkilerini almak için
    }
}
