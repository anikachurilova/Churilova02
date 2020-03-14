using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Churilova02.Tools.Exceptions
{
    internal class InvalidNameException : Exception
    {
        public InvalidNameException(string name) : base($"Error! Entered name {name} is invalid. You must use a-z letters of both registers.")
        {

        }
    }
}
