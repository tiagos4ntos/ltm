using AutoMapper;
using LTM.Application.ServiceDomain;
using LTM.WebApi.Models;
using LTM.WebApi.Security;
using System.Net;
using System.Web.Http;

namespace LTM.WebApi.Controllers
{
    public class UsersController : ApiController
    {
        private readonly IUserProfileService _userProfileService;
        private readonly IMapper _mapper;

        public UsersController(IUserProfileService userProfileService, IMapper mapper)
        {
            _userProfileService = userProfileService;
            _mapper = mapper;
        }
        
        [HttpPost]
        [Route("api/v1/users/login")]
        public IHttpActionResult Login([FromBody] LoginModel loginInfo)
        {
            if (string.IsNullOrWhiteSpace(loginInfo.Login))
                return BadRequest("Login is required!");

            if (string.IsNullOrWhiteSpace(loginInfo.Password))
                return BadRequest("Password is required!");


            var user = _userProfileService.Login(loginInfo.Login, loginInfo.Password);

            if (user == null)
                throw new HttpResponseException(HttpStatusCode.Unauthorized);

            var token = JwtManager.GenerateToken(user.Id, user.Name, 1);

            var userInfo = _mapper.Map<UserProfileModel>(user);
            userInfo.Token = token;

            return Ok(userInfo);
        }
    }
}
