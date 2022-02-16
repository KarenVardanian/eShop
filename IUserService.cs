using System;

public interface IUserService
{
	Task AddUser(User user);
	Task GetUser(int id);
}
