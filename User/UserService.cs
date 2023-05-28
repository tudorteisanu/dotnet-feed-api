namespace feedApi.Users
{
    public class UserService : GenericService<User>, IUserService
    {
        public UserService(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public User? FindByEmail(string email)
        {
            return this.repository.Single(user => user.Email == email);
        }
    }
}
