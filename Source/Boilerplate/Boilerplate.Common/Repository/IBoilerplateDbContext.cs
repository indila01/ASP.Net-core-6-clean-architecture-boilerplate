using System;
namespace Boilerplate.Common.Repository
{
	public interface IBoilerplateDbContext: IUserRepository, IUnitOfWork
	{
	}
}

