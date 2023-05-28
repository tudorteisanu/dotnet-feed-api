using feedApi.AppDbContextNS;
using feedApi.Shared;

namespace feedApi.Roles
{
    public class RoleService : GenericService<Role>, IRoleService
    {
        public RoleService(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
