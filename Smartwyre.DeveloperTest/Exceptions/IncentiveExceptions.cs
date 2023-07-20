using System;

namespace Smartwyre.DeveloperTest.Exceptions
{
    public sealed class IncentiveException : Exception
    {
        public IncentiveException(string message) : base(message) { }
    }
}
