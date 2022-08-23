using Microsoft.EntityFrameworkCore;
using StudentCenter.Entities;
using StudentCenter.Entities.help;
using StudentCenter.Service.baseService;
using StudentCenter.Service.ServiceInterface;

namespace StudentCenter.Service.implement
{
    public class Center_Record_Service : RepositoryBase<Center_Record>, ICenter_Record_Service
    {
        public Center_Record_Service(StudentCenterContext context) : base(context)
        {
        }


        public async Task<Operation_Result> Search(Center_Record_Request Demand_Request)
        {
            Operation_Result operation_Result = new Operation_Result();
            operation_Result.Result = null;
            operation_Result.SUCCESS = false;
            List<Center_Record> student_Demands = new List<Center_Record>();

            try
            {

                var result = await _context.Center_Records.Include(x=>x.Demand).Include(x=>x.Collage).Where(
                    u =>
                u.Collage_FK== (Demand_Request.Collage_FK != null ? Demand_Request.Collage_FK : u.Collage_FK) &&
                
                u.Diwan_NO.Contains((!string.IsNullOrEmpty(Demand_Request.Diwan_NO)) ? Demand_Request.Diwan_NO : u.Diwan_NO) &&

                u.Reporter_Name.Contains((!string.IsNullOrEmpty(Demand_Request.Reporter_Name)) ? Demand_Request.Reporter_Name : u.Reporter_Name) &&
                u.Diwan_Date>= (Demand_Request.First_Diwan_Date != null ? Demand_Request.First_Diwan_Date : u.Diwan_Date) &&
                u.Diwan_Date <= (Demand_Request.Last_Diwan_Date != null ? Demand_Request.Last_Diwan_Date : u.Diwan_Date)

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
