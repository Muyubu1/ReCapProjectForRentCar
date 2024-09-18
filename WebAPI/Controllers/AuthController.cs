using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Security.JWT;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public IActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            // Kullanıcı var mı kontrolü
            var userExists = _authService.UserExists(userForRegisterDto.Email);
            if (!userExists.Success)
            {
                return BadRequest(userExists.Message);
            }

            // Kayıt işlemi
            var registerResult = _authService.Register(userForRegisterDto, userForRegisterDto.Password);
            var result = _authService.CreateAccessToken(registerResult.Data);

            if (result.Success)
            {
                return Ok(result.Data); // AccessToken başarıyla oluşturulursa
            }

            return BadRequest(result.Message); // Bir hata durumunda
        }

        [HttpPost("login")]
        public IActionResult Login(UserForLoginDto userForLoginDto)
        {
            // Giriş işlemi
            var userToLogin = _authService.Login(userForLoginDto);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message); // Giriş başarısızsa hata mesajı gönder
            }

            // AccessToken oluşturma
            var result = _authService.CreateAccessToken(userToLogin.Data);
            if (result.Success)
            {
                return Ok(result.Data); // AccessToken başarıyla oluşturulursa
            }

            return BadRequest(result.Message); // Bir hata durumunda
        }
    }
}
