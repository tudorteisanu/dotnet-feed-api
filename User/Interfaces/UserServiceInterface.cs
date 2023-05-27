using System;
using feedApi.User.dto;
using Microsoft.AspNetCore.Mvc;

namespace feedApi.User

{
	public interface UserServiceInterface
    {

        public IEnumerable<UserResponseDto> Find();

        public UserResponseDto Create(CreateUserDto user);

        public UserResponseDto FindOne(int userId);

        public UserResponseDto Update(int userId, UpdateUserDto user);

        public bool Delete(int userId);
    }
}

