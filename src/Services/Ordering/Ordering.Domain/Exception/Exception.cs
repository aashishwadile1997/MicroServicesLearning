using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.Exception
{
    public class DomainException : IOException
    {
        public DomainException(string message)
            : base($"Domain Exception: \"{message}\" throws from Domain Layer.")
        {
        }
    }
}
