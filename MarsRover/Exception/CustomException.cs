using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Exception
{
    public class CustomException : BaseException
    {
        public CustomException()
        {

        }

        public CustomException(int errorCode) : base(errorCode)
        {

        }

        public CustomException(string message) : base(message)
        {

        }
    }
}
