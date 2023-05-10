using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoAppBL.Repositories;
using TodoAppBL.Models;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileServiceController : ControllerBase
    {
        private readonly IProfileBLServices _profileServices;

        public ProfileServiceController(IProfileBLServices profileServices)
        {
            this._profileServices = profileServices;
        }

        [HttpGet]
        [Route("GetUser/{id}")]
        public ActionResult<ProfileBL> GetUser(int id)
        {
            try
            {
                ProfileBL prof = _profileServices.GetUser(id);
                if (prof is null)
                    return NotFound();
                return Ok(prof);
            }
            catch (Exception e)
            {
                return BadRequest("Unexpected Error");
            }
        }

        [HttpPost]
        [Route("LoginUser")]
        public ActionResult<CredentialsBL> LoginUser(CredentialsBL cred)
        {
            try
            {
                cred = _profileServices.LoginUser(cred);
                if (cred is null)
                    return BadRequest("Invalid User credentials");
                return Ok(cred);
            }
            catch (Exception e)
            {
                return BadRequest("Unexpected Error");
            }
        }

        [HttpPost]
        [Route("RegisterUser")]
        public ActionResult RegisterUser([FromBody] JsonElement model)
        {
            try
            {
                model.TryGetProperty("name", out var nameElement);
                model.TryGetProperty("email", out var emailElement);
                model.TryGetProperty("password", out var passwordElement);
                model.TryGetProperty("phoneNo", out var phoneNoElement);
                if (_profileServices.RegisterUser(nameElement.GetString(), emailElement.GetString(), passwordElement.GetString(), phoneNoElement.GetString()))
                    return Ok(new { message = "User registered successfully!" });
                return BadRequest("Registration Failed");
            }
            catch (Exception e)
            {
                return BadRequest("Unexpected Error");
            }
        }
        [HttpPut]
        [Route("EditUser/{userId}")]
        public ActionResult<ProfileBL> UpdateUser(ProfileBL user)
        {
            try
            {
                ProfileBL updatedProf = _profileServices.UpdateUser(user.Id, user.Name);
                if (updatedProf is null)
                    return BadRequest("Not updated");
                return Ok(updatedProf);

            }
            catch (Exception e)
            {
                return BadRequest("Unexpected Error");
            }
        }

    }
}
