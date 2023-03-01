using System;
namespace Meridia.Domain.Exceptions
{
    public class WrongPasswordException : Exception
    {
        public WrongPasswordException() : base("Username or password is wrong!")
        {

        }
    }
}

