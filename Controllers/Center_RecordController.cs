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
    public class Center_RecordController : ControllerBase
    {
        private readonly Center_Record_Service service;

        public Center_RecordController(ICenter_Record_Service  _repository)
        {
            this.service = _repository as Center_Record_Service;
        }




        [HttpGet]
        public async Task<IActionResult> List()
        {
            var objecs = await service.List();
            return Ok(objecs);
        }



        [HttpPost("Search")]
        public async Task<IActionResult> Search(Center_Record_Request Center_Record_Request)
        {
            var objecs = await service.Search(Center_Record_Request);
            return Ok(objecs);
        }



        [HttpPost]
        public async Task<IActionResult> Add([FromBody]  Center_Record Center_Record)
        {
            Center_Record.Center_Record_ID = null;
            var objecs = await service.Add(Center_Record);
            return Ok(objecs);
        }


        [HttpPut("{id?}")]
        public async Task<IActionResult> Update(long id, [FromBody] Center_Record Center_Record)
        {
            var objecs = await service.Update(id, Center_Record);
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
