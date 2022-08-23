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
    public class Student_DemandController : ControllerBase
    {
        private readonly Student_Demand_Service service;

        public Student_DemandController(IStudent_Demand_Service _repository)
        {
            this.service = _repository as Student_Demand_Service;
        }




        [HttpGet]
        public async Task<IActionResult> List()
        {
            var objecs = await service.List();
            return Ok(objecs);
        }


        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Student_Demand Student_Demand)
        {
            Student_Demand.Student_Demand_ID = null;
            var objecs = await service.Add(Student_Demand);
            return Ok(objecs);
        }


        [HttpPut("{id?}")]
        public async Task<IActionResult> Update(long id, [FromBody] Student_Demand Student_Demand)
        {
            var objecs = await service.Update(id, Student_Demand);
            return Ok(objecs);
        }


        [HttpDelete("{id?}")]
        public async Task<IActionResult> Delete(int id)
        {
            var objecs = await service.Delete(id);
            return Ok(objecs);
        }


        [HttpPost("Search")]
        public async Task<IActionResult> Search([FromBody] Student_Demand_Request student_Demand_Request)
        {
            var objecs = await service.Search(student_Demand_Request);
            return Ok(objecs);
        }

        [HttpPost("CheckifNationalNumberExist")]
        public async Task<IActionResult> CheckifNationalNumberExist([FromBody]  Student_Demand_Request student_Demand_Request)
        {
            var objecs = await service.CheckExistByNational(student_Demand_Request);
            return Ok(objecs);
        }

        [HttpPost("CheckifUnivercityNumberExist")]
        public async Task<IActionResult> CheckifUnivercityNumberExist([FromBody] Student_Demand_Request student_Demand_Request)
        {
            var objecs = await service.CheckExistByUnvercityNum(student_Demand_Request);
            return Ok(objecs);
        }
    }
}
