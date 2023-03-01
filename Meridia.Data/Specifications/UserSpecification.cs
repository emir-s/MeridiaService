using System;
using System.Linq.Expressions;
using Meridia.Domain.Core.Specifications;
using Meridia.Domain.Entities.Users;

namespace Meridia.Domain.Specifications
{
	public static class UserSpecification
	{
        public static BaseSpecification<Users> GetUserByEmail(string email)
        {
            return new BaseSpecification<Users>(x => x.Email == email);
        }
    }
}

