using System;

namespace feedApi.User

{
	public class UserService
    {

        private readonly UserRepository userRepository;

        public UserService(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public IEnumerable<UserModel> GetAll()
        {
            return this.userRepository.GetAll();
        }
    }
}

