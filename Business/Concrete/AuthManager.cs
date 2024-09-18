using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.DTOs;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IUserService _userService;
        private readonly ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            // Şifre hash ve salt oluşturma
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            // Yeni kullanıcı oluşturma
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true // Kullanıcı aktif mi
            };

            // Kullanıcıyı sisteme ekle
            _userService.Add(user);
            return new SuccessDataResult<User>(user, "Kullanıcı başarıyla kaydedildi.");
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            // Email'e göre kullanıcıyı kontrol et
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>("Kullanıcı bulunamadı.");
            }

            // Şifreyi kontrol et
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.Data.PasswordHash, userToCheck.Data.PasswordSalt))
            {
                return new ErrorDataResult<User>("Şifre hatalı.");
            }

            return new SuccessDataResult<User>(userToCheck.Data, "Başarıyla giriş yapıldı.");
        }

        public IResult UserExists(string email)
        {
            // Kullanıcının var olup olmadığını kontrol et
            if (_userService.GetByMail(email) != null)
            {
                return new ErrorResult("Bu email ile kayıtlı bir kullanıcı zaten mevcut.");
            }
            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            // Kullanıcının yetkilerini al ve token oluştur
            var claims = _userService.GetClaims(user).Data;
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, "Access token başarıyla oluşturuldu.");
        }
    }
}
