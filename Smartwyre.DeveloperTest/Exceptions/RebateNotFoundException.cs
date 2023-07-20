using System;

namespace Smartwyre.DeveloperTest.Exceptions
{
    public sealed class RebateNotFoundException : Exception
    {
        public RebateNotFoundException(string message) : base(message) { }
    }
}
