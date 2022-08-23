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
    public class Collage_RecordController : ControllerBase
    {
        private readonly Collage_Record_Service service;

        public Collage_RecordController(ICollage_Record_Service _repository)
        {
            this.service = _repository as Collage_Record_Service;
        }



        [HttpPost("Search")]
        public async Task<IActionResult> Search([FromBody] Collage_Record_Request Collage_Record_Request)
        {
            var objecs = await service.Search(Collage_Record_Request);
            return Ok(objecs);
        }



        [HttpGet]
        public async Task<IActionResult> List()
        {
            var objecs = await service.List();
            return Ok(objecs);
        }


        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Collage_Record collage_Record)
        {
            collage_Record.Collage_Records_ID= null;
            var objecs = await service.Add(collage_Record);
            return Ok(objecs);
        }


        [HttpPut("{id?}")]
        public async Task<IActionResult> Update(long id, [FromBody] Collage_Record collage_Record)
        {
            var objecs = await service.Update(id, collage_Record);
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
