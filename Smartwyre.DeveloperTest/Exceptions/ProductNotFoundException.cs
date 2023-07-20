using System;

namespace Smartwyre.DeveloperTest.Exceptions
{
    public sealed class ProductNotFoundException : Exception
    {
        public ProductNotFoundException(string message) : base(message) { }
    }
}
