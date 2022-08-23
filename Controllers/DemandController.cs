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
    public class DemandController : ControllerBase
    {
        private readonly Demand_Service service;

        public DemandController(IDemand_Service _repository)
        {
            this.service = _repository as Demand_Service;
        }




        [HttpGet]
        public async Task<IActionResult> List()
        {
            var objecs = await service.List();
            return Ok(objecs);
        }


        [HttpGet("DemandTracking")]
        public async Task<IActionResult> DemandTracking(decimal id)
        {
            var objecs = await   service.TrackingDemand(id);
            return Ok(objecs);
        }


        [HttpPost("Search")]
        public async Task<IActionResult> Search([FromBody] Demand_Request demand_Request)
        {
            var objecs = await service.Search(demand_Request);
            return Ok(objecs);
        }
        

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Demand Demand)
        {
            Demand.Demand_ID = null;
            var objecs = await service.Add(Demand);
            return Ok(objecs);
        }


        [HttpPut("{id?}")]
        public async Task<IActionResult> Update(long id, [FromBody] Demand Demand)
        {
            var objecs = await service.Update(id, Demand);
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
