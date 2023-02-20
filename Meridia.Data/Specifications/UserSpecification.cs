using System;
using System.Linq.Expressions;
using Meridia.Domain.Core.Specifications;
using Meridia.Domain.Entities.Users;

namespace Meridia.Domain.Specifications
{
	public static class UserSpecification
	{
        public static BaseSpecification<Users> GetUserByEmailAndPasswordSpec(string email, string password)
        {
            return new BaseSpecification<Users>(x => x.Email == email && x.Password == password);
        }

    }
}

