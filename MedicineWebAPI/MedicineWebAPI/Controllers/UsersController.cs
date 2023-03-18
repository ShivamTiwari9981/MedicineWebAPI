using MedicineWebAPI.Models;
using MedicineWebAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicineWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;
        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }
        [HttpPost(Name = "login")]
        public IActionResult Login(LoginModel model)
        {

            ResponseModel response = new ResponseModel();
            try
            {
                if (!ModelState.IsValid)
                {
                    response.Status = false ;
                    response.Message = "Please Enter User Name or Password";
                }
                int errNo = userService.Login(model);
                if(errNo>0)
                {
                    response.Status = false;
                    response.Message = "Invalid User";
                }
                else
                {
                    response.Status = false;
                    response.Message = "Login Successfull";
                }
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }
        [HttpPost(Name = "register")]
        public IActionResult Register(UserModel model)
        {

            ResponseModel response = new ResponseModel();
            try
            {
                if (!ModelState.IsValid)
                {

                }
                response=userService.Register(model);
            }
            catch(Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }

        [HttpGet(Name = "user")]
        public IActionResult GetUser(int userId)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                response = userService.ViewUser(userId);
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }

        [HttpGet(Name = "update")]
        public IActionResult UpdateUser(UserModel model)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                //response = userService.UpdateUser(model);
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }
    }
}
