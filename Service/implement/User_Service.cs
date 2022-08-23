using Microsoft.EntityFrameworkCore;
using StudentCenter.Entities;
using StudentCenter.Entities.help;
using StudentCenter.Service.baseService;
using StudentCenter.Service.ServiceInterface;

namespace StudentCenter.Service.implement
{
    public class User_Service : RepositoryBase<User>, IUser_Service
    {

        public User_Service(StudentCenterContext context) : base(context)
        {
        }

        public async Task<Operation_Result> Login (Login_Request login_Request )
        {
            Operation_Result operation_Result = new Operation_Result();
            operation_Result.Result = null;
            operation_Result.SUCCESS = false;
            try {
               


                var result = await _context.Users.Where(u =>
                u.User_Name == login_Request.User_Name &&
                u.User_Password == login_Request.User_Password).ToListAsync();
                if (result!= null && result.Count()>0)
                {
                    operation_Result.SUCCESS = true;
                    operation_Result.Result = result.FirstOrDefault();
                    
                }else
                {
                    operation_Result.ERROR = "اسم المستخدم وكلمكة الشسر خاطئة";
                }
                return operation_Result;
            }
            catch(Exception ex)
            {
                operation_Result.ERROR = ex.Message;
            }
            return operation_Result;
        }


    }
}
