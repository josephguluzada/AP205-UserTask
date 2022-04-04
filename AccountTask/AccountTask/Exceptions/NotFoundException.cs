using System;
using System.Collections.Generic;
using System.Text;

namespace AccountTask.Exceptions
{
    class NotFoundException:Exception
    {
        public NotFoundException(string message):base(message)
        {

        }
    }
}
