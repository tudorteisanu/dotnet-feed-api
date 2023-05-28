namespace feedApi.Users
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext learnDb) : base(learnDb)
        {
        }
    }
}
