using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Churilova02.Tools.Exceptions
{
    internal class PersonTooOldException : Exception
    {
        public PersonTooOldException(DateTime date) : base($"Error! Entered birthdate {date.ToShortDateString()} is invalid. You are too old!")
        {

        }
    }
}
