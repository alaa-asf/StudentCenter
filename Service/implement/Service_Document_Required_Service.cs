using StudentCenter.Entities;
using StudentCenter.Service.baseService;
using StudentCenter.Service.ServiceInterface;

namespace StudentCenter.Service.implement
{
    public class Service_Document_Required_Service : RepositoryBase<Service_Document_Required>, IService_Document_Required_Service
    {
        public Service_Document_Required_Service(StudentCenterContext context) : base(context)
        {

        }
    }
}
