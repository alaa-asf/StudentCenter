using StudentCenter.Entities;
using StudentCenter.Service.baseService;
using StudentCenter.Service.ServiceInterface;

namespace StudentCenter.Service.implement
{
    public class Collage_Service : RepositoryBase<Collage>, ICollage_Service
    {
        public Collage_Service(StudentCenterContext context) : base(context)
        {
        }
    }
}
