using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentCenter.Entities;
using StudentCenter.Entities.help;
using StudentCenter.Service.implement;
using StudentCenter.Service.ServiceInterface;

namespace StudentCenter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly User_Service service ;

        public UserController(IUser_Service  _repository)
        {
            this.service= _repository as User_Service;
        }



        [HttpPost("login")]
        public async Task<IActionResult> login(Login_Request login_Request)
        {
            var objecs = await service.Login(login_Request);

            return Ok(objecs);

        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var objecs = await service.List();

            return Ok(objecs);

        }


        [HttpPost]
        public async Task<IActionResult> Add([FromBody] User user)
        {
            var objecs = await service.Add(user);
            return Ok(objecs);
        }


        [HttpPut("{id?}")]
        public async Task<IActionResult> Update(long id, [FromBody] User user)
        {
            var objecs = await service.Update(id,user);
            return Ok(objecs);
        }


        [HttpDelete("{id?}")]
        public async Task<IActionResult> Delete(int id )
        {
            var objecs = await service.Delete(id);
            return Ok(objecs);
        }

    }
}
