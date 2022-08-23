using Dapper;
using Microsoft.EntityFrameworkCore;
using StudentCenter.Entities;
using StudentCenter.Entities.help;
using StudentCenter.Service.baseService;
using StudentCenter.Service.ServiceInterface;
using System.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace StudentCenter.Service.implement
{
    public class Demand_Service : RepositoryBase<Demand>, IDemand_Service
    {
        public  IConfiguration configuration;
        public Demand_Service(StudentCenterContext context, IConfiguration configuration) : base(context)
        {
            this.configuration = configuration;
        }

        
              public async Task<Operation_Result> Search(Demand_Request Demand_Request)
        {
            Operation_Result operation_Result = new Operation_Result();
            operation_Result.Result = null;
            operation_Result.SUCCESS = false;
            List<Demand> student_Demands = new List<Demand>();

            try
            {

                var result = await _context.Demands.Include(x=>x.Student_Demand).Include(x=>x.Destination_Collage).Where(
                    u =>
                u.Destination_Collage_FK  == (Demand_Request.Destination_Collage_FK != null  ? Demand_Request.Destination_Collage_FK  : u.Destination_Collage_FK) &&
               
                u.Demand_Barcode.Contains((!string.IsNullOrEmpty(Demand_Request.Demand_Barcode)) ? Demand_Request.Demand_Barcode : u.Demand_Barcode) &&

                u.Demand_Applicant_Type.Contains((!string.IsNullOrEmpty(Demand_Request.Demand_Applicant_Type)) ? Demand_Request.Demand_Applicant_Type : u.Demand_Applicant_Type) &&
                u.Demand_Date >= (Demand_Request.First_Demand_Date!= null ? Demand_Request.First_Demand_Date : u.Demand_Date) &&
                u.Demand_Date <= (Demand_Request.Last_Demand_Date != null ? Demand_Request.Last_Demand_Date : u.Demand_Date) 
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


        public async Task<Operation_Result> TrackingDemand(decimal id)
        {
            Operation_Result operation_Result = new Operation_Result();
            operation_Result.Result = null;
            operation_Result.SUCCESS = false;
            List<Demand_Tracking> student_Demands = new List<Demand_Tracking>();

            try
            {

                using (var con = new SqlConnection(this.configuration.GetConnectionString("ConnectionString")))
                {
                    string SQL = @"select * From 
(
select    Center_Record.Center_Record_ID as  'Record_ID'  ,
          'مركز خدمة المواطن' as 'Record_Type'  ,
          Center_Record.Demand_FK  ,
          Demand.Demand_Date  ,
          Demand.Demand_Barcode,  
          Demand.Demand_Status  ,
          Demand.Demand_Result  ,
          Demand.Demand_Applicant_Type  ,
          Demand.Agency_No  ,
          Demand.Agency_Date , 
          Demand.Agency_Source,  
          Student_Demand.Student_Demand_FirstName  ,        
          Student_Demand.Student_Demand_LastName  ,        
          Student_Demand.Student_Demand_National_ID,          
          Student_Demand.Student_Demand_Univercity_Number  ,
          Center_Record.Collage_FK  ,
          Collage.Collage_Name , 
          Center_Record.[Type]  ,
          Center_Record.Diwan_NO , 
          Center_Record.Diwan_Date,  
          Center_Record.Reporter_Name  
		  from Center_Record inner join Demand on Center_Record .Demand_FK = Demand .Demand_ID
		  inner join Student_Demand on Demand .Student_Demand_FK = Student_Demand .Student_Demand_ID
		  left join Collage on Center_Record .Collage_FK = Collage .Collage_ID

union  

select 
		  Collage_Record.Collage_Records_ID as  'Record_ID'  ,
          'ديوان الكلية' as 'Record_Type'  ,
          Collage_Record.Demand_FK  ,
          Demand.Demand_Date  ,
          Demand.Demand_Barcode,  
          Demand.Demand_Status  ,
          Demand.Demand_Result  ,
          Demand.Demand_Applicant_Type  ,
          Demand.Agency_No  ,
          Demand.Agency_Date , 
          Demand.Agency_Source,  
          Student_Demand.Student_Demand_FirstName  ,        
          Student_Demand.Student_Demand_LastName  ,        
          Student_Demand.Student_Demand_National_ID,          
          Student_Demand.Student_Demand_Univercity_Number  ,
          Collage_Record.Collage_FK  ,
          Collage.Collage_Name , 
          Collage_Record.[Type]  ,
          Collage_Record.Diwan_NO , 
          Collage_Record.Diwan_Date,  
          Collage_Record.Reporter_Name  
		  from Collage_Record inner join Demand on Collage_Record .Demand_FK = Demand .Demand_ID
		  inner join Student_Demand on Demand .Student_Demand_FK = Student_Demand .Student_Demand_ID
		  left join Collage on Collage_Record .Collage_FK = Collage .Collage_ID
) as Query
order by Query.Diwan_Date asc 
";


                    var result = await  con.QueryAsync<Demand_Tracking>(SQL);


                    if (result != null && result.Count() > 0)
                    {
                        operation_Result.SUCCESS = true;
                        operation_Result.Result = result.ToList();

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
