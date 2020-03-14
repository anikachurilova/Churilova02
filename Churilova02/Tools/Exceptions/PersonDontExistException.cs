using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Churilova02.Tools.Exceptions
{
    internal class PersonDontExistException : Exception
    {
        public PersonDontExistException(DateTime date) : base($"Error! Entered birthdate {date.ToShortDateString()} is invalid. You don't exist yet!")
        {

        }
    }
}
