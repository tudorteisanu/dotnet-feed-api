using feedApi.Shared;

namespace feedApi.Users
{
	public interface IUserService : IGenericService<User>
    {
        public User FindByEmail(string email);
    }
}

