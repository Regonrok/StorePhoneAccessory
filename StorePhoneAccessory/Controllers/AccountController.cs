using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using StorePhoneAccessory.Models;

namespace StorePhoneAccessory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        ApplicationContext db;
        
        public AccountController(ApplicationContext context)
        {
            db = context;
        }

        [HttpPost("login")]
        public async Task Login(DTO.LoginJson json)
        {
            var identity = GetIdentity(json.Phone, json.Password);
            if (identity == null)
            {
                Response.StatusCode = 400;
                await Response.WriteAsync("Invalid phone number or passwords");
                return;
            }
            var now = DateTime.Now;
            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                notBefore: now,
                claims: identity.Claims,
                expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                signingCredentials: new Microsoft.IdentityModel.Tokens.
                SigningCredentials(AuthOptions.GetSymmetricSecurityKey(),
                SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            var response = new
            {
                access_token = encodedJwt,
                phone = identity.Name
            };

            Response.ContentType = "application/json";
            await Response.WriteAsync(JsonConvert.SerializeObject(response,
                new JsonSerializerSettings() { Formatting = Formatting.Indented }));
        } 

        [HttpPost("registration")]
        public async Task Registration(DTO.RegistrJson json)
        {
            if (json == null)
            {
                Response.StatusCode = 400;
                await Response.WriteAsync("Error");
                return;
            }
            Person pers = new Person()
            {
                FirstName = json.FirstName,
                LastName = json.LastName,
                MiddleName = json.MiddleName,
                PhoneNumber = json.PhoneNumber,
                Pass = json.Pass,
                IdRole = json.IdRole
            };
            db.People.Add(pers);
            await db.SaveChangesAsync();
            Response.StatusCode = 200;
            return;
        }

        public ClaimsIdentity GetIdentity(string phone, string pass)
        {
            Person person = db.People.FirstOrDefault(x => x.PhoneNumber == phone && x.Pass == pass);
            if (person == null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, person.PhoneNumber),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, person.Role.Name)
                };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Token",
                    ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }
            return null;
        }
    }
}