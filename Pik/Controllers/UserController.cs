using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pik.Services;
using Pik.Models;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Configuration;


namespace Pik.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        private IConfiguration _config;

        public UserController(UserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _config = configuration;
        }

        // GET: api/values
        [HttpGet(Name = "GetUSers")]
        public ActionResult<List<User>> Get()
        {
            return _userService.Get();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        [Route("create")]
        public ActionResult<User> Create(User user)
        {
            user.DateTime = DateTime.Now.ToString();

            _userService.Create(user);
            return CreatedAtRoute("GetUsers", new { id = user.Id.ToString() }, user);
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(User user)
        {
            var userData = _userService.GetByEmail(user.Email);
            var token = GenerateJSONWebToken(userData);
            return Ok(new { token });
        }


        // Generate JWT tokens
        private string GenerateJSONWebToken(User userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);


            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, "sjknjkd"),
                new Claim(JwtRegisteredClaimNames.NameId, "Aron")
            };

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public class Nedd
        {
            public string token { get; set; }
        }
        // Decode JWT Token
        [HttpPost]
        [Route("validate")]
        public IActionResult ValidateToken(Nedd nedd)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(nedd.token);
            var tokenS = handler.ReadToken(nedd.token) as JwtSecurityToken;
            var email = tokenS.Claims.First(claim => claim.Type == "email").Value;
            return Ok(new { email });
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
