using Microsoft.EntityFrameworkCore;
using StudentCenter.Entities;
using StudentCenter.Entities.help;
using StudentCenter.Service.baseService;
using StudentCenter.Service.ServiceInterface;

namespace StudentCenter.Service.implement
{
    public class Student_Demand_Service : RepositoryBase<Student_Demand>, IStudent_Demand_Service
    {
        public Student_Demand_Service(StudentCenterContext context) : base(context)
        {

            
        }


        public async Task<Operation_Result> Search(Student_Demand_Request Student_Demand_Request)
        {
            Operation_Result operation_Result = new Operation_Result();
            operation_Result.Result = null;
            operation_Result.SUCCESS = false;
            List<Student_Demand> student_Demands = new List<Student_Demand>();

            try
            {

                var result = await _context.Student_Demands.Include(x=>x.Collage).Where(
                    u =>
                u.Student_Demand_FirstName.Contains((!string.IsNullOrEmpty(Student_Demand_Request.Student_Demand_FirstName)) ? Student_Demand_Request.Student_Demand_FirstName : u.Student_Demand_FirstName) &&
                u.Student_Demand_LastName.Contains((!string.IsNullOrEmpty(Student_Demand_Request.Student_Demand_LastName)) ? Student_Demand_Request.Student_Demand_FirstName : u.Student_Demand_LastName) &&
                u.Student_Demand_National_ID.Contains((!string.IsNullOrEmpty(Student_Demand_Request.Student_Demand_National_ID)) ? Student_Demand_Request.Student_Demand_National_ID : u.Student_Demand_National_ID)&&
                u.Student_Demand_Univercity_Number.Contains((!string.IsNullOrEmpty(Student_Demand_Request.Student_Demand_Univercity_Number)) ? Student_Demand_Request.Student_Demand_Univercity_Number : u.Student_Demand_Univercity_Number) &&
                u.Collage_FK == (Student_Demand_Request.Collage_FK != null ? Student_Demand_Request.Collage_FK : u.Collage_FK )

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


        public async Task<Operation_Result> CheckExistByNational (Student_Demand_Request Student_Demand_Request)
        {
            Operation_Result operation_Result = new Operation_Result();
            operation_Result.Result = null;
            operation_Result.SUCCESS = false;
            List<Student_Demand> student_Demands = new List<Student_Demand>();

            try
            {

                if (!string.IsNullOrWhiteSpace(Student_Demand_Request.Student_Demand_National_ID))
                {
                    var result = await _context.Student_Demands.Where(u => u.Student_Demand_National_ID.Contains(Student_Demand_Request.Student_Demand_National_ID))?.ToListAsync();

                    if (result != null && result.Count() > 0)
                    {
                        operation_Result.SUCCESS = true;
                        operation_Result.Result = result;

                    }
                    else
                    {
                        operation_Result.ERROR = "اسم المستخدم وكلمكة الشسر خاطئة";
                    }
                }
                return operation_Result;
            }
            catch (Exception ex)
            {
                operation_Result.ERROR = ex.Message;
            }
            return operation_Result;
        }


        public async Task<Operation_Result> CheckExistByUnvercityNum(Student_Demand_Request Student_Demand_Request)
        {
            Operation_Result operation_Result = new Operation_Result();
            operation_Result.Result = null;
            operation_Result.SUCCESS = false;
            List<Student_Demand> student_Demands = new List<Student_Demand>();
            try
            {

                if (!string.IsNullOrWhiteSpace(Student_Demand_Request.Student_Demand_Univercity_Number))
                {
                    var result = await _context.Student_Demands.Where(
                                        u => u.Student_Demand_Univercity_Number.Contains(Student_Demand_Request.Student_Demand_Univercity_Number))?.ToListAsync();

                    if (result != null && result.Count() > 0)
                    {
                        operation_Result.SUCCESS = true;
                        operation_Result.Result = result;

                    }
                    else
                    {
                        operation_Result.ERROR = "لا يوجد بيانات";
                    }
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
