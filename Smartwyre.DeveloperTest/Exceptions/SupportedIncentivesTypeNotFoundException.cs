using System;

namespace Smartwyre.DeveloperTest.Exceptions
{
    public sealed class SupportedIncentivesTypeNotFoundException : Exception
    {
        public SupportedIncentivesTypeNotFoundException(string message) : base(message) { }
    }
}
