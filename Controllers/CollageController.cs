using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentCenter.Entities;
using StudentCenter.Service.implement;
using StudentCenter.Service.ServiceInterface;

namespace StudentCenter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollageController : ControllerBase
    {
        private readonly Collage_Service service;

        public CollageController(ICollage_Service _repository)
        {
            this.service = _repository as Collage_Service;
        }




        [HttpGet]
        public async Task<IActionResult> List()
        {
            var objecs = await service.List();
            return Ok(objecs);
        }


        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Collage collage)
        {
            collage.Collage_ID = null;
            var objecs = await service.Add(collage);
            return Ok(objecs);
        }


        [HttpPut("{id?}")]
        public async Task<IActionResult> Update(long id, [FromBody] Collage collage)
        {
            var objecs = await service.Update(id, collage);
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
