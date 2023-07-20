using System;

namespace Smartwyre.DeveloperTest.Exceptions
{
    public sealed class NumberException : Exception
    {
        public NumberException(string message) : base(message) { }
    }
}
