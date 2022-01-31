using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Exception
{
    public abstract class BaseException : System.Exception
    {
        public BaseException()
        {

        }

        public BaseException(string message) : base(message)
        {

        }

        public BaseException(int errorCode) : base(errorCode.ToString())
        {

        }
    }
}
