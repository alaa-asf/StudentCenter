using Microsoft.EntityFrameworkCore;
using StudentCenter.Entities;
using StudentCenter.Entities.help;
using StudentCenter.Service.baseService;
using StudentCenter.Service.ServiceInterface;
using System.Linq.Expressions;

namespace StudentCenter.Service.implement
{
    public class Collage_Record_Service :RepositoryBase<Collage_Record> , ICollage_Record_Service
    {
        

        public Collage_Record_Service(StudentCenterContext context) : base(context)
        {
        }

        public async Task<Operation_Result> Search(Collage_Record_Request Demand_Request)
        {
            Operation_Result operation_Result = new Operation_Result();
            operation_Result.Result = null;
            operation_Result.SUCCESS = false;
            List<Collage_Record> student_Demands = new List<Collage_Record>();

            try
            {

                var result = await _context.Collage_Records.Include(x => x.Demand).Include(x => x.Collage).Where(
                    u =>
                u.Collage_FK == (Demand_Request.Collage_FK != null ? Demand_Request.Collage_FK : u.Collage_FK) &&

                u.Diwan_NO.Contains((!string.IsNullOrEmpty(Demand_Request.Diwan_NO)) ? Demand_Request.Diwan_NO : u.Diwan_NO) &&

                u.Reporter_Name.Contains((!string.IsNullOrEmpty(Demand_Request.Reporter_Name)) ? Demand_Request.Reporter_Name : u.Reporter_Name) &&
                u.Diwan_Date >= (Demand_Request.First_Diwan_Date != null ? Demand_Request.First_Diwan_Date : u.Diwan_Date) &&
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
