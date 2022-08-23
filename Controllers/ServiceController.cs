using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentCenter.Entities;
using StudentCenter.Service.implement;
using StudentCenter.Service.ServiceInterface;

namespace StudentCenter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly Service_Service service;

        public ServiceController(IService_Service _repository)
        {
            this.service = _repository as Service_Service;
        }




        [HttpGet]
        public async Task<IActionResult> List()
        {
            var objecs = await service.List();
            return Ok(objecs);
        }

        [HttpGet("List_By_Serice_FK/{Service_FK}")]
        public async Task<IActionResult> List_By_Serice_FK(int Service_FK)
        {
            var objecs = await service.List_By_Serice_FK(Service_FK);
            return Ok(objecs);
        }


        
        [HttpPost]
        public async Task<IActionResult> Add([FromBody]  Entities.Service Service)
        {
            Service.Service_ID = null;
            var objecs = await service.Add(Service);
            return Ok(objecs);
        }


        [HttpPut("{id?}")]
        public async Task<IActionResult> Update(long id, [FromBody] Entities.Service Service)
        {
            var objecs = await service.Update(id, Service);
            return Ok(objecs);
        }


        [HttpDelete("{id?}")]
        public async Task<IActionResult> Delete(int id)
        {
            var objecs = await service.Delete(id);
            return Ok(objecs);
        }

    }
}
