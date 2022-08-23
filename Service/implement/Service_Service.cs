using Microsoft.EntityFrameworkCore;
using StudentCenter.Entities;
using StudentCenter.Service.baseService;
using StudentCenter.Service.ServiceInterface;

namespace StudentCenter.Service.implement
{
    public class Service_Service : RepositoryBase<Entities.Service>, IService_Service
    {
        public Service_Service(StudentCenterContext context) : base(context)
        {

        }

        


        public async Task<Operation_Result> List_By_Serice_FK (int Service_FK )
        {
            Operation_Result operation_Result = new Operation_Result();
            operation_Result.Result = null;
            operation_Result.SUCCESS = false;
            List<Service_Document_Required> student_Demands = new List<Service_Document_Required>();

            try
            {

                var result = await _context.Service_Document_Requireds.Where(
                    u =>
                u.Service_FK== Service_FK

                )?.ToListAsync();


                if (result != null && result.Count() > 0)
                {
                    operation_Result.SUCCESS = true;
                    operation_Result.Result = result;

                }
                else
                {
                    operation_Result.ERROR = "لا يوجد بيانات";
                }
                return operation_Result;
            }
            catch (Exception ex)
            {
                operation_Result.ERROR = ex.Message;
            }
            return operation_Result;
        }

    }
}
